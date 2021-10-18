using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.GroupTable;
using WebApplication1.Models.Photo;

namespace WebApplication1.Models.StudentTable
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public StudentPhoto StudentPhoto { get; set; }

    }
}
