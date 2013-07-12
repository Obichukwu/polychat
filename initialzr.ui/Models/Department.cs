using System.Collections.Generic;

namespace initialzr.ui.Models {

    public class Department {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public virtual ICollection<ChatDiscussion> Discussion { get; set; }

        public Department() { 
            Profiles = new List<Profile>();
            Discussion = new List<ChatDiscussion>();
        }
    }
}