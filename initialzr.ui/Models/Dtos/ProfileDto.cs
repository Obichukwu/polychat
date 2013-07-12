namespace initialzr.ui.Models.Dtos {

    public class ProfileDto {

        public int ProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public string About { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public string AuthToken { get; set; }

        public ProfileDto() {
        }

        public ProfileDto(Profile entity) {
            this.ProfileId = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.Sex = entity.Sex;
            this.About = entity.About;
            this.Email = entity.Email;
            this.Password = entity.Password;

            this.AuthToken = System.Convert.ToBase64String(
                System.Text.Encoding.ASCII.GetBytes(entity.Email + ":" + entity.Password)
            );
            this.RoleId = entity.RoleId;
            this.DepartmentId = entity.DepartmentId;
        }
    }
}