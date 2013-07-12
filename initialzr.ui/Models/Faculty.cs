using System.Collections.Generic;

namespace initialzr.ui.Models {

    public class Faculty {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public Faculty() {
            Departments = new List<Department>();
        }
    }
}