using System;
using System.Collections.Generic;

namespace initialzr.ui.Models.Dtos {

    public class PostDto {

        public int PostId { get; set; }

        public string Smug { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public int ContentType { get; set; }

        public int OwnerId { get; set; }

        public virtual ICollection<string> Discussion { get; set; }

        public PostDto() {
        }

        public PostDto(Post entity) {
            this.PostId = entity.Id;
            this.PostDate = entity.PostDate;
            this.Content = entity.Content;
            this.ContentType = entity.ContentType;
            this.OwnerId = entity.OwnerId;
            this.Discussion = new List<string>();

            foreach (var dis in entity.Discussion) {
                var item = "\"date\":\"{0}\",\"note\":\"{1}\"";
                item = "{" + String.Format(item, dis.Date.ToString("G"), dis.Note) + "}";
                this.Discussion.Add(item);
            }
        }
    }
}