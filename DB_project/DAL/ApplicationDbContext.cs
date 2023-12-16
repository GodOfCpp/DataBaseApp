using System.Data.Entity;
using DB_project.BLL.Entities;

namespace DB_project.DAL
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().ToTable("schools", "public");
            modelBuilder.Entity<Employee>().ToTable("employees", "public");
            modelBuilder.Entity<Teacher>().ToTable("teachers", "public");
            modelBuilder.Entity<Class>().ToTable("classes", "public");
            modelBuilder.Entity<Student>().ToTable("students", "public");
            modelBuilder.Entity<Subject>().ToTable("subjects", "public");
            
            
            
            modelBuilder.Entity<School>()
                .HasMany(s => s.Employees)
                .WithRequired(e => e.School)
                .HasForeignKey(e => e.SchoolId);

            /*modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Teacher)
                .WithRequired(t => t.Employee)
                .Map(m => m.MapKey("employee_id"));*/

            modelBuilder.Entity<Teacher>()
                .HasRequired(t => t.Employee)
                .WithMany(e => e.Teacher)
                .HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithMany(c => c.Teachers)
                .Map(m =>
                {
                    m.ToTable("teachers_classes", "public");
                    m.MapLeftKey("teacher_id");
                    m.MapRightKey("class_id");
                });

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .Map(m =>
                {
                    m.ToTable("teachers_subjects", "public");
                    m.MapLeftKey("teacher_id");
                    m.MapRightKey("subject_id");
                });

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithRequired(s => s.Class)
                .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<Class>()
                .HasRequired(c => c.ClassTeacher)
                .WithOptional();
                //.Map(m => m.MapKey("class_teacher_id"));

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Subjects)
                .WithMany(s => s.Students)
                .Map(m =>
                {
                    m.ToTable("students_subjects", "public");
                    m.MapLeftKey("student_id");
                    m.MapRightKey("subject_id");
                });
        }

    }
}