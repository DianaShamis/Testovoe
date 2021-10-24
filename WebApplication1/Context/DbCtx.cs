using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.CourseTable;
using WebApplication1.Models.GroupTable;
using WebApplication1.Models.Photo;
using WebApplication1.Models.StudentTable;
using WebApplication1.Models.SubjectTable;
using WebApplication1.Models.TeacherTable;

namespace WebApplication1.Context
{
    public class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions<DbCtx> options)
            : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentPhoto> StudentPhotos { get; set; }
        public DbSet<Subject> Subjects { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestBD;Trusted_Connection=True;");
        }
    }
}
