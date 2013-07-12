using System;

namespace initialzr.ui.Models {

    public class PostDiscussion {

        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Poster { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}