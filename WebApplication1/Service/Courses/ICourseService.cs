using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.CourseTable;

namespace WebApplication1.Service.Courses
{
    public interface ICourseService
    {
        List<Course> List();
        void Create(Course course);
        Course GetById(int id);
        void Update(int id, Models.CourseTable.Course course);
        void Delete(int id);
    }
}
