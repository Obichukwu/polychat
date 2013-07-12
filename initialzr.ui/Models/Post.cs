using System;
using System.Collections.Generic;

namespace initialzr.ui.Models {

    public class Post {

        public int Id { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public int ContentType { get; set; }

        public int OwnerId { get; set; }

        public virtual Profile Owner { get; set; }

        public virtual ICollection<PostDiscussion> Discussion { get; set; }

        public Post() {
            Discussion = new List<PostDiscussion>();
        }
    }
}