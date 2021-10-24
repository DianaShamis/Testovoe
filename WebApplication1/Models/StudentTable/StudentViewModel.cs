using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.GroupTable;
using WebApplication1.Models.Photo;

namespace WebApplication1.Models.StudentTable
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Некорректный номер")]
        public long Phone { get; set; }
        public byte[] Photo { get; set; }
        [Required(ErrorMessage = "Не указанна группа")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }
        public StudentPhoto StudentPhoto { get; set; }
        public List<SelectListItem> GroupList { get; set; }
    }
}
