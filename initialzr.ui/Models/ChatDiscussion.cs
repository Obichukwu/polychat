using System;

namespace initialzr.ui.Models {

    public class ChatDiscussion {

        public int Id { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}