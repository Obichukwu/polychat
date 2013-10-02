using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class MessageController : SecureBaseApiController {

        // GET api/message
        public IEnumerable<MessageDto> GetMessages() {
            //Profile curUser = DbContext.Profiles.Find(PrincipalId);
            var msgs = DbContext.Messages.Where(el => el.Participants.Any(l => l.Id == PrincipalId)).ToList();
            return msgs.Select(item => new MessageDto(item)); ;
        }

        // GET api/message/5
        public IEnumerable<MessageDiscussionDto> GetMessage(int id) {
            Message message = DbContext.Messages.Find(id);
            if (message == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return message.Discussion.Select(el => new MessageDiscussionDto(el));
        }

        // PUT api/message/5
        public HttpResponseMessage PutMessage(int id, MessageDto message) {
            if (!ModelState.IsValid) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != message.MessageId) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //get the database version and change only the properties i want
            var dbmessage = DbContext.Messages.Find(id);
            if (dbmessage == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            dbmessage.LastMessageDate = message.LastMessageDate;

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/message
        public HttpResponseMessage PostMessage(MessageDiscussionDto messageDiscussion) {
            //var dbMessage = new Message { LastMessageDate = DateTime.Now };
            //dbMessage.Participants = new List<Profile> {
            //            DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(0))),
            //            DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(1))) };

            //DbContext.Messages.Add(dbMessage);
            //DbContext.SaveChanges();
            if (ModelState.IsValid) {
                var dbMessage = DbContext.Messages.Find(messageDiscussion.MessageId);

                var diss = new MessageDiscussion {
                    Date = DateTime.Now,
                    Note = messageDiscussion.Note,
                    ProfileId = messageDiscussion.PosterId
                };

                dbMessage.Discussion.Add(diss);

                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new MessageDiscussionDto(diss));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbMessage.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/message/5
        public HttpResponseMessage DeleteMessage(int id) {
            Message message = DbContext.Messages.Find(id);
            if (message == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            DbContext.Messages.Remove(message);
            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new MessageDto(message));
        }
    }
}