using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;

namespace initialzr.ui.Controllers
{
    public class Department2Controller : SecureBaseApiController {
        // GET api/Department/5
        public IEnumerable<ProfileDto> GetProfiles(int id)
        {
            var profs = id>0 ? 
                DbContext.Profiles.Where(el => el.DepartmentId == id).AsEnumerable() : 
                DbContext.Profiles.AsEnumerable();

            return profs.Select(item => new ProfileDto(item));
        }
    }
}
