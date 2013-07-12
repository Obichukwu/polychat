using System;

namespace initialzr.ui.Models {

    public class MessageDiscussion {

        public int Id { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int MessageId { get; set; }

        public virtual Message Message { get; set; }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}