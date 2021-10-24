using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.SubjectTable
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан куратор")]
        public int TeacherId { get; set; }
        public List<SelectListItem> TeacherList { get; set; }
        public Subject Subject { get; set; }
    }
}
