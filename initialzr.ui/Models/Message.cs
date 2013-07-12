using System;
using System.Collections.Generic;

namespace initialzr.ui.Models {

    public class Message {

        public int Id { get; set; }

        public DateTime LastMessageDate { get; set; }

        public virtual ICollection<Profile> Participants { get; set; }

        public virtual ICollection<MessageDiscussion> Discussion { get; set; }

        public Message() {
            Participants = new List<Profile>(2);
            Discussion = new List<MessageDiscussion>();
        }
    }
}