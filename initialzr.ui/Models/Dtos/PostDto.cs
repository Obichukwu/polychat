using System;
using System.Collections.Generic;

namespace initialzr.ui.Models.Dtos {

    public class PostDto {

        public int PostId { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public int ContentType { get; set; }

        public int OwnerId { get; set; }

        public virtual ICollection<PostDiscussionDto> Discussion { get; set; }

        public PostDto() {
        }

        public PostDto(Post entity) {
            this.PostId = entity.Id;
            this.PostDate = entity.PostDate;
            this.Content = entity.Content;
            this.ContentType = entity.ContentType;
            this.OwnerId = entity.OwnerId;
            this.Discussion = new List<PostDiscussionDto>();

            foreach (var dis in entity.Discussion) {
                this.Discussion.Add(new PostDiscussionDto(dis));
            }
        }
    }
}