using System.Collections.Generic;

namespace initialzr.ui.Models {

    public class Profile {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public string About { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Post> Post { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public Profile() {
            Post = new List<Post>();
            Messages = new List<Message>();
        }
    }
}