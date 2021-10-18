﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.CourseTable;
using WebApplication1.Models.GroupTable;
using WebApplication1.Models.Photo;
using WebApplication1.Models.StudentTable;
using WebApplication1.Models.TeacherTable;

namespace WebApplication1.Context
{
    public class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions<DbCtx> options, ModelBuilder builder)
            : base(options)
        {
            //builder.Entity<Student>().HasOne(s => s.StudentPhoto).WithOne(p => p.Student).HasForeignKey<StudentPhoto>(o => o.StudentId);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentPhoto> StudentPhotos { get; set; }

        public DbCtx()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestBD;Trusted_Connection=True;");
        }
    }
}