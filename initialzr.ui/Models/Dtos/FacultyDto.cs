namespace initialzr.ui.Models.Dtos {

    public class FacultyDto {

        public int FacultyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public FacultyDto() {
        }

        public FacultyDto(Faculty faculty) {
            this.FacultyId = faculty.Id;
            this.Title = faculty.Title;
            this.Description = faculty.Description;
        }
    }
}