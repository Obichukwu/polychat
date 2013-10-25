using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class ProfileController : SecureBaseApiController {

        public IEnumerable<ProfileDto> GetProfiles() {
            return DbContext.Profiles.AsEnumerable().Select(item => new ProfileDto(item)); ;
        }

        // GET api/Profile/5
        public ProfileDto GetProfile(int id) {
            Profile profile = DbContext.Profiles.Find(id);
            if (profile == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ProfileDto(profile);
        }

        // PUT api/Profile/5
        public HttpResponseMessage PutProfile(int id, ProfileDto profile) {
            if (!ModelState.IsValid) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != profile.ProfileId) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var dbProfile = DbContext.Profiles.Find(id);
            if (dbProfile == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            dbProfile.FirstName = profile.FirstName;
            dbProfile.LastName = profile.LastName;
            dbProfile.Sex = profile.Sex;
            dbProfile.About = profile.About;
            dbProfile.Email = profile.Email;
            dbProfile.Password = profile.Password;
            dbProfile.DepartmentId = profile.DepartmentId;

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new ProfileDto(dbProfile));
        }

        // POST api/Profile
        public HttpResponseMessage PostProfile(ProfileDto profile) {
            if (ModelState.IsValid) {
                var dbProfile = new Profile {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Sex = profile.Sex,
                    About = profile.About,
                    Email = profile.Email,
                    Password = profile.Password,
                    RoleId = profile.RoleId,
                    DepartmentId = profile.DepartmentId,
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

        // DELETE api/Profile/5
        public HttpResponseMessage DeleteProfile(int id) {
            Profile profile = DbContext.Profiles.Find(id);
            if (profile == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            DbContext.Profiles.Remove(profile);
            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new ProfileDto(profile));
        }
    }
}