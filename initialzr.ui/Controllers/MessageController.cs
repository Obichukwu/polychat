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
            return DbContext.Messages.AsEnumerable().Select(item => new MessageDto(item)); ;
        }

        // GET api/message/5
        public MessageDto GetMessage(int id) {
            Message message = DbContext.Messages.Find(id);
            if (message == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new MessageDto(message);
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
        public HttpResponseMessage PostMessage(MessageDto message) {
            if (ModelState.IsValid) {
                var dbMessage = new Message { LastMessageDate = DateTime.Now };
                dbMessage.Participants = new List<Profile> {
                        DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(0))),
                        DbContext.Profiles.Find(Convert.ToInt32(message.Participants.ElementAt(1))) };

                DbContext.Messages.Add(dbMessage);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new MessageDto(dbMessage));
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