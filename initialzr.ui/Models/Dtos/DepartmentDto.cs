namespace initialzr.ui.Models.Dtos {

    public class DepartmentDto {

        public int DepartmentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int FacultyId { get; set; }

        public DepartmentDto() {
        }

        public DepartmentDto(Department department) {
            this.DepartmentId = department.Id;
            this.Title = department.Title;
            this.Description = department.Description;
            this.FacultyId = department.FacultyId;
        }
    }
}