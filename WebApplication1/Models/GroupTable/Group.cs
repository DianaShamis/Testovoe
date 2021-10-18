using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.StudentTable;

namespace WebApplication1.Models.GroupTable
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Speciality { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
