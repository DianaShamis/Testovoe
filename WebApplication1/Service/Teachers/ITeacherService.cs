using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.TeacherTable;

namespace WebApplication1.Service.Teachers
{
    public interface ITeacherService
    {
        List<Teacher> List();
        void Create(Teacher teacher);
        Teacher GetById(int id);
        void Update(int id, Models.TeacherTable.Teacher teacher);
        void Delete(int id);
    }
}
