using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.StudentTable;

namespace WebApplication1.Service.Students
{
    public interface IStudentService
    {
        List<Student> List();
        void Create(Student student, IFormFile uploadFile);
        Student GetById(int id);
        void Update(int id, Models.StudentTable.Student student, IFormFile uploadedFile);
        void Delete(int id);
    }
}
