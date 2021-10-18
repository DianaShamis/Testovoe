using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.GroupTable;

namespace WebApplication1.Models.StudentTable
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public byte[] Photo { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }
        public List<SelectListItem> GroupList { get; set; }
    }
}
