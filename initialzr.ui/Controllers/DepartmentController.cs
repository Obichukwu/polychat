using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class DepartmentController : SecureBaseApiController {

        // GET api/Department
        public IEnumerable<DepartmentDto> GetDepartments() {
            return DbContext.Departments.AsEnumerable().Select(item => new DepartmentDto(item)); ;
        }

        // GET api/Department/5
        public DepartmentDto GetDepartment(int id) {
            Department department = DbContext.Departments.Find(id);
            if (department == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new DepartmentDto(department);
        }

        // PUT api/Department/5
        public HttpResponseMessage PutDepartment(int id, DepartmentDto department) {
            if (!ModelState.IsValid) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != department.DepartmentId) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var dbDepartment = DbContext.Departments.Find(id);
            if (dbDepartment == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            dbDepartment.Title = department.Title;
            dbDepartment.Description = department.Description;

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Department
        public HttpResponseMessage PostDepartment(DepartmentDto department) {
            if (ModelState.IsValid) {
                var dbDepartment = new Department {
                    Title = department.Title,
                    Description = department.Description,
                    FacultyId = department.FacultyId
                };
                DbContext.Departments.Add(dbDepartment);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new DepartmentDto(dbDepartment));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbDepartment.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Department/5
        public HttpResponseMessage DeleteDepartment(int id) {
            Department department = DbContext.Departments.Find(id);
            if (department == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            DbContext.Departments.Remove(department);
            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new DepartmentDto(department));
        }
    }
}