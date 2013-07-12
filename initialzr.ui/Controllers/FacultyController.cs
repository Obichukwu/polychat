using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class FacultyController : SecureBaseApiController {

        // GET api/Faculty
        public IEnumerable<FacultyDto> GetFaculties() {
            return DbContext.Faculties.AsEnumerable().Select(item => new FacultyDto(item));
        }

        // GET api/Faculty/5
        public FacultyDto GetFaculty(int id) {
            Faculty faculty = DbContext.Faculties.Find(id);
            if (faculty == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new FacultyDto(faculty);
        }

        // PUT api/Faculty/5
        public HttpResponseMessage PutFaculty(int id, FacultyDto faculty) {
            if (!ModelState.IsValid) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != faculty.FacultyId) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //get the database version and change only the properties i want
            var dbFaculty = DbContext.Faculties.Find(id);
            if (dbFaculty == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            dbFaculty.Title = faculty.Title;
            dbFaculty.Description = faculty.Description;

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Faculty
        public HttpResponseMessage PostFaculty(FacultyDto faculty) {
            if (ModelState.IsValid) {
                var dbFaculty = new Faculty { Title = faculty.Title, Description = faculty.Description };
                DbContext.Faculties.Add(dbFaculty);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new FacultyDto(dbFaculty));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbFaculty.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Faculty/5
        public HttpResponseMessage DeleteFaculty(int id) {
            Faculty faculty = DbContext.Faculties.Find(id);
            if (faculty == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            DbContext.Faculties.Remove(faculty);
            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new FacultyDto(faculty));
        }
    }
}