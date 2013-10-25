using initialzr.ui.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace initialzr.ui {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            System.Data.Entity.Database.SetInitializer(new Initializer());

            GlobalConfiguration.Configuration.MessageHandlers.Add(new AuthHandler());
        }
    }

    public class AuthHandler : DelegatingHandler {
        public const string BasicScheme = "Basic";
        public const string ChallengeAuthenticationHeaderName = "WWW-Authenticate";
        public const char AuthorizationHeaderSeparator = ':';

        private readonly InitialzrContext store;

        public AuthHandler() {
            store = new InitialzrContext();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var authHeader = request.Headers.Authorization;
            if (authHeader == null) return base.SendAsync(request, cancellationToken);
            if (authHeader.Scheme != BasicScheme) return base.SendAsync(request, cancellationToken);
            var encodedCredentials = authHeader.Parameter;
                    
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AuthorizationHeaderSeparator);
            if (credentialParts.Length != 2) {
                return CreateUnauthorizedResponse();
            }
            var username = credentialParts[0].Trim();
            var password = credentialParts[1].Trim();

            lock (this)
            {
                if (!store.Profiles.Any(el => el.Email == username && el.Password == password)) {
                    return CreateUnauthorizedResponse();
                }
                SetPrincipal(store.Profiles.First(el => el.Email == username && el.Password == password));
            }

            return base.SendAsync(request, cancellationToken);
        }

        protected override void Dispose(bool disposing) {
            using (store) { store.SaveChanges(); }
            base.Dispose(disposing);
        }

        private Task<HttpResponseMessage> CreateUnauthorizedResponse() {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            response.Headers.Add(ChallengeAuthenticationHeaderName, BasicScheme);
            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);
            return taskCompletionSource.Task;
        }

        private void SetPrincipal(Profile user) {
            var identity = CreateIdentity(user);
            string[] roles = { user.RoleId == 1 ? "admin" : "user" };
            var principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null) {
                HttpContext.Current.User = principal;
            }
        }

        private GenericIdentity CreateIdentity(Profile modelUser) {
            var identity = new GenericIdentity(modelUser.Email, BasicScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, modelUser.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, modelUser.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, modelUser.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Email, modelUser.Email));
            return identity;
        }
    }
}