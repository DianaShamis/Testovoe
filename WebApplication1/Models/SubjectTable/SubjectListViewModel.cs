using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.TeacherTable;

namespace WebApplication1.Models.SubjectTable
{
    public class SubjectListViewModel
    {
        public IList<Subject> SubjectList { get; set; }
        public Teacher Teacher { get; set; }
    }
}
