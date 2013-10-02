using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers
{
    public class PostDiscussionController : SecureBaseApiController
    {
        // POST api/Post
        public HttpResponseMessage PostPostDiscussion(PostDiscussionDto postDiss) {
            if (ModelState.IsValid) {
                Profile curUser = DbContext.Profiles.Find(PrincipalId) ;
                var dbPostDiss = new PostDiscussion {
                    Note=postDiss.Note,
                    Date= DateTime.Now,
                    PostId = postDiss.PostId,
                    Poster = curUser.FirstName + " " + curUser.LastName
                };
                DbContext.Posts.Find(postDiss.PostId).Discussion.Add(dbPostDiss);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new PostDiscussionDto(dbPostDiss));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbPostDiss.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
