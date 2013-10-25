using initialzr.ui.Models;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Security.Claims;

namespace initialzr.ui.Controllers {

    public class BaseApiController : ApiController {

        public InitialzrContext DbContext { get; set; }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext) {
            if (DbContext == null)
                DbContext = new InitialzrContext();

            base.Initialize(controllerContext);
        }

        protected override void Dispose(bool disposing) {
            using (DbContext) {
                if (DbContext != null)
                    DbContext.SaveChanges();
            }
            base.Dispose(disposing);
        }
    }

    [Authorize]
    public class SecureBaseApiController : BaseApiController {
        public int PrincipalId { get; set; }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext) {
            if (HttpContext.Current != null) {
                var principal = (GenericPrincipal)HttpContext.Current.User;
                var identity = (GenericIdentity)principal.Identity;
                PrincipalId = System.Convert.ToInt32(identity.Claims.First(el => el.Type == ClaimTypes.Sid).Value);
            }
            base.Initialize(controllerContext);
        }
    }
}