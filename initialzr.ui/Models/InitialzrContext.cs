using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace initialzr.ui.Models {

    public class InitialzrContext : DbContext {

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Message> Messages { get; set; }

        //public DbSet<PostDiscussion> PostDiscussion { get; set; }

        //public DbSet<ChatDiscussion> ChatDiscussion { get; set; }

        //public DbSet<MessageDiscussion> MessageDiscussion { get; set; }

        public InitialzrContext() {
            //Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            setupFaculty(modelBuilder);
            setupDepartment(modelBuilder);
            setupProfile(modelBuilder);
            setupPost(modelBuilder);
            setupMessage(modelBuilder);
        }

        private static void setupFaculty(DbModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Faculty>();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(225);

            //Relationships
            entity.HasMany(e => e.Departments).WithRequired(e => e.Faculty).HasForeignKey(e => e.FacultyId);
        }

        private static void setupDepartment(DbModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Department>();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(225);

            //Relationships
            entity.HasMany(e => e.Profiles).WithRequired(e => e.Department).HasForeignKey(e => e.DepartmentId);
            entity.HasMany(e => e.Discussion).WithRequired(e => e.Department).HasForeignKey(e => e.DepartmentId);

            //Sub ChatDiscussion
            var entity2 = modelBuilder.Entity<ChatDiscussion>();
            entity2.HasKey(e => e.Id);
            entity2.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity2.Property(e => e.Note).IsRequired();
            entity2.Property(e => e.Note).HasMaxLength(225);

            entity2.Property(e => e.Date).IsRequired();

            entity2.HasRequired(e => e.Profile).WithMany().HasForeignKey(e => e.ProfileId).WillCascadeOnDelete(false); ;

        }

        private static void setupProfile(DbModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Profile>();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100);

            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.Property(e => e.Sex).IsRequired();
            entity.Property(e => e.Sex).HasMaxLength(20);

            entity.Property(e => e.About).IsRequired();
            entity.Property(e => e.About).HasMaxLength(225);

            entity.Property(e => e.RoleId).IsRequired();

            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100);

            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(100);

            //Relationships
            entity.HasMany(e => e.Post).WithRequired(e => e.Owner).HasForeignKey(e => e.OwnerId);
            entity.HasMany(e => e.Messages).WithMany(e => e.Participants);
        }

        private static void setupPost(DbModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Post>();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity.Property(e => e.PostDate).IsRequired();

            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.Content).IsMaxLength();

            entity.Property(e => e.ContentType).IsRequired();

            //Relationships
            entity.HasMany(e => e.Discussion).WithRequired(e => e.Post).HasForeignKey(e => e.PostId);

            //Sub PostDiscussion
            var entity2 = modelBuilder.Entity<PostDiscussion>();
            entity2.HasKey(e => e.Id);
            entity2.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity2.Property(e => e.Note).IsRequired();
            entity2.Property(e => e.Note).HasMaxLength(225);

            entity2.Property(e => e.Poster).IsRequired();
            entity2.Property(e => e.Poster).HasMaxLength(100);

            entity2.Property(e => e.Date).IsRequired();
        }

        private static void setupMessage(DbModelBuilder modelBuilder) {
            var entity = modelBuilder.Entity<Message>();
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity.Property(e => e.LastMessageDate).IsRequired();

            entity.HasMany(e => e.Discussion).WithRequired(e => e.Message).HasForeignKey(e => e.MessageId);

            //Sub MessageDiscussion
            var entity2 = modelBuilder.Entity<MessageDiscussion>();
            entity2.HasKey(e => e.Id);
            entity2.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            entity2.Property(e => e.Note).IsRequired();
            entity2.Property(e => e.Note).HasMaxLength(225);

            entity2.Property(e => e.Date).IsRequired();

            //Relationships
            entity2.HasRequired(e => e.Profile).WithMany().HasForeignKey(e => e.ProfileId).WillCascadeOnDelete(false); ;
        }
    }
}