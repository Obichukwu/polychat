using initialzr.ui.Models;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class BaseApiController : ApiController {

        public InitialzrContext DbContext { get; set; }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext) {
            base.Initialize(controllerContext);
            if (DbContext == null)
                DbContext = new InitialzrContext(); ;
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            using (DbContext) {
                if (DbContext != null)
                    DbContext.SaveChanges();
            }
        }
    }

    //[Authorize]
    public class SecureBaseApiController : BaseApiController {
    }
}