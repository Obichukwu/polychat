using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;

namespace initialzr.ui.Controllers
{
    public class ChatController : BaseApiController
    {
        // GET api/message/5
        public IEnumerable<ChatDiscussionDto> GetMessage(int id)
        {
            var dept = DbContext.Departments.Find(id);
            if (dept == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return dept.Discussion.Where(el=> el.Date >= DateTime.Now.AddDays(-1)).Select(el => new ChatDiscussionDto(el));
        }

        // PUT api/Chat/5 == Abused
        public HttpResponseMessage PutMessage(int id, object dateUpdate) {
            var dept = DbContext.Departments.Find(id);
            var lastupdate = Convert.ToDateTime(dateUpdate);
            if (dept == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
             var res= dept.Discussion.Where(el => el.Date >= lastupdate).Select(el => new ChatDiscussionDto(el));
             return Request.CreateResponse(HttpStatusCode.OK, res);
        }


        // POST api/message
        public HttpResponseMessage PostMessage(ChatDiscussionDto chatDiscussion) {
            if (ModelState.IsValid) {
                var dbMessage = DbContext.Departments.Find(chatDiscussion.DepartmentId);

                var diss = new ChatDiscussion {
                    Date = DateTime.Now,
                    Note = chatDiscussion.Note,
                    ProfileId = chatDiscussion.ProfileId
                };

                dbMessage.Discussion.Add(diss);
                DbContext.SaveChanges();

                diss.Profile = DbContext.Profiles.Find(chatDiscussion.ProfileId);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new ChatDiscussionDto(diss));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbMessage.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
