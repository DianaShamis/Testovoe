using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.SubjectTable;

namespace WebApplication1.Models.TeacherTable
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана специальность")]
        public string Speciality { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
