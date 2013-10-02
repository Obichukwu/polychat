using initialzr.ui.Models;
using initialzr.ui.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace initialzr.ui.Controllers {

    public class PostController : SecureBaseApiController {

        // GET api/Post
        public IEnumerable<PostDto> GetPosts() {
            Profile curUser = DbContext.Profiles.Find(PrincipalId) ;
            var depMembers = curUser.Department.Profiles.Select(el => el.Id);
            return DbContext.Posts.Include("Discussion")
                .Where(el => depMembers.Contains(el.OwnerId) )
                .AsEnumerable().Select(item => new PostDto(item)); ;
        }

        // GET api/Post/5
        public PostDto GetPost(int id) {
            Post post = DbContext.Posts.Find(id);
            if (post == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new PostDto(post);
        }

        // PUT api/Post/5
        public HttpResponseMessage PutPost(int id, PostDto post) {
            if (!ModelState.IsValid) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != post.PostId) {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var dbPost = DbContext.Posts.Find(id);
            if (dbPost == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            dbPost.Content = post.Content;
            dbPost.ContentType = post.ContentType;
            dbPost.PostDate = post.PostDate;
            dbPost.OwnerId = post.OwnerId;

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Post
        public HttpResponseMessage PostPost(PostDto post) {
            if (ModelState.IsValid) {
                var dbPost = new Post {
                    Content = post.Content,
                    ContentType = post.ContentType,
                    PostDate = post.PostDate,
                    OwnerId = post.OwnerId
                };
                DbContext.Posts.Add(dbPost);
                DbContext.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new PostDto(dbPost));
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dbPost.Id }));
                return response;
            } else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Post/5
        public HttpResponseMessage DeletePost(int id) {
            Post post = DbContext.Posts.Find(id);
            if (post == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            DbContext.Posts.Remove(post);

            DbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new PostDto(post));
        }
    }
}