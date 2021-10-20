using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.SubjectTable;

namespace WebApplication1.Models.TeacherTable
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Speciality { get; set; }
        public ICollection<Subject> Subjects { get; set; }

    }
}
