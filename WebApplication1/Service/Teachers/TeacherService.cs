using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.TeacherTable;

namespace WebApplication1.Service.Teachers
{
    public class TeacherService : ITeacherService
    {
        private DbCtx _context;

        public TeacherService(DbCtx context)
        {
            _context = context;
        }
        public List<Teacher> List()
        {
            var list = _context.Teachers.ToList();
            return list;
        }
        public void Create(Teacher teacher)
        {
            var newTeacher = new Teacher();

            if (teacher != null)
            {
                newTeacher.Name = teacher.Name;
                newTeacher.Speciality = teacher.Speciality;
                _context.Add(newTeacher);
                _context.SaveChanges();
            }
        }
        public void Update(int id, Models.TeacherTable.Teacher teacher)
        {
            if (id != 0 && teacher != null)
            {
                var currentTeacher = _context.Teachers.Where(_ => _.Id == id).FirstOrDefault();
                if (currentTeacher == null)
                {
                    _context.Add(teacher);
                    _context.SaveChanges();
                }
                else
                {
                    currentTeacher.Name = teacher.Name;
                    currentTeacher.Speciality = teacher.Speciality;
                    

                    _context.Update(currentTeacher);
                    _context.SaveChanges();
                }

            }
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                var teacher = _context.Teachers.Where(_ => _.Id == id).FirstOrDefault();
                _context.Remove(teacher);
                _context.SaveChanges();

            }
        }
        public Models.TeacherTable.Teacher GetById(int id)
        {
            var teacher = new Models.TeacherTable.Teacher();
            if (id > 0)
            {
               teacher = _context.Teachers.Where(_ => _.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
            return teacher;
        }
    }
}
