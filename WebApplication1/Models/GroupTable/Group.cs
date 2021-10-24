using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.StudentTable;

namespace WebApplication1.Models.GroupTable
{
    public class Group
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "Не указана специальность")]
        public string Speciality { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
