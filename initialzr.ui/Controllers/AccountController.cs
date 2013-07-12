using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class AccountController : BaseApiController {

        public IEnumerable<DepartmentDto> GetDepartments() {
            return DbContext.Departments.AsEnumerable().Select(item => new DepartmentDto(item)); ;
        }

        // GET api/Faculty/5
        public ProfileDto GetAccount(string username, string password) {
            if (!DbContext.Profiles.Any(el => el.Email == username && el.Password == password)) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            var profile = DbContext.Profiles.First(el => el.Email == username && el.Password == password);

            if (profile == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ProfileDto(profile);
        }

        // POST api/Faculty
        public HttpResponseMessage PostAccount(ProfileDto profile) {
            if (ModelState.IsValid) {
                var dbProfile = new Profile {
                    Email = profile.Email,
                    Password = profile.Password,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Sex = profile.Sex,
                    About = profile.About,
                    DepartmentId = profile.DepartmentId,
                    RoleId = 2
                };

                DbContext.Profiles.Add(dbProfile);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new ProfileDto(dbProfile));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbProfile.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}