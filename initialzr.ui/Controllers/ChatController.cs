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

        // POST api/message
        public HttpResponseMessage PostMessage(ChatDiscussionDto chatDiscussion) {
            //var dbMessage = new Message { LastMessageDate = DateTime.Now };
            //dbMessage.Participants = new List<Profile> {
            //            DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(0))),
            //            DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(1))) };

            //DbContext.Messages.Add(dbMessage);
            //DbContext.SaveChanges();
            if (ModelState.IsValid) {
                var dbMessage = DbContext.Departments.Find(chatDiscussion.DepartmentId);

                var diss = new ChatDiscussion {
                    Date = DateTime.Now,
                    Note = chatDiscussion.Note,
                    ProfileId = chatDiscussion.ProfileId
                };

                dbMessage.Discussion.Add(diss);

                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new ChatDiscussionDto(diss));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbMessage.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

    }
}
