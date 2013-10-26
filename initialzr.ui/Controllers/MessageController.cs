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

            message.LastMessageDate = DateTime.Now;
            
            return message.Discussion.Select(el => new MessageDiscussionDto(el));
        }

        // PUT api/message/5
        public HttpResponseMessage PutMessage(int id, object dateUpdate) {
            //if (!ModelState.IsValid) {
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}

            //if (id != message.MessageId) {
            //    return Request.CreateResponse(HttpStatusCode.BadRequest);
            //}

            ////get the database version and change only the properties i want
            //var dbmessage = DbContext.Messages.Find(id);
            //if (dbmessage == null) {
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            //dbmessage.LastMessageDate = message.LastMessageDate;

            //DbContext.SaveChanges();

            //return Request.CreateResponse(HttpStatusCode.OK);


            var msg = DbContext.Messages.Find(id);
            var lastupdate = Convert.ToDateTime(dateUpdate);
            if (msg == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            msg.LastMessageDate = DateTime.Now;

            var res = msg.Discussion.Where(el => el.Date >= lastupdate && el.ProfileId != PrincipalId).Select(el => new MessageDiscussionDto(el));
            return Request.CreateResponse(HttpStatusCode.OK, res);
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
        public MessageDto DeleteMessage(int id)
        {
            if (DbContext.Profiles.Find(id) == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            Message message;
            if (DbContext.Messages.Any(el => el.Participants.Any(l => l.Id == PrincipalId) &&
                                             el.Participants.Any(l => l.Id == id)))
                message = DbContext.Messages
                    .First(el => el.Participants.Any(l => l.Id == PrincipalId) &&
                                 el.Participants.Any(l => l.Id == id));
            else {
                message = new Message {
                    LastMessageDate = DateTime.Now,
                    Participants = new List<Profile> { DbContext.Profiles.Find(PrincipalId), DbContext.Profiles.Find(id) }
                };
                DbContext.Messages.Add(message);
            }
            return new MessageDto(message);
        }
    }
}