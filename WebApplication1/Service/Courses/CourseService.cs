using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.CourseTable;

namespace WebApplication1.Service.Courses
{
    public class CourseService : ICourseService
    {
        private DbCtx _context;

        public CourseService(DbCtx context)
        {
            _context = context;
        }
        public List<Course> List()
        {
            var list = _context.Courses.ToList();
            return list;
        }
        public void Create (Course course)
        {
            var newCourse = new Course();

            if (course != null)
            {
                newCourse.Name = course.Name;
                _context.Add(newCourse);
                _context.SaveChanges();
            }
        }
 
        public void Update(int id, Models.CourseTable.Course course)
        {
            if (id != 0 && course != null)
            {
                var currentCourse = _context.Courses.Where(_ => _.Id == id).FirstOrDefault();
                if (currentCourse == null)
                {
                    _context.Add(course);
                    _context.SaveChanges();
                }
                else
                {
                    currentCourse.Name = course.Name;
                    

                    _context.Update(currentCourse);
                    _context.SaveChanges();
                }

            }
        }
        public void Delete(int id)
        {
            if(id != 0)
            {
                var course = _context.Courses.Where(_ => _.Id == id).FirstOrDefault();
                _context.Remove(course);
                _context.SaveChanges();

            }
        }
        public Models.CourseTable.Course GetById(int id)
        {
            var course = new Models.CourseTable.Course();
            if (id > 0)
            {
                course = _context.Courses.Where(_ => _.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
            return course;
        }
    }
}
