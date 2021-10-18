using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.StudentTable;

namespace WebApplication1.Models.Photo
{
    public class StudentPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
