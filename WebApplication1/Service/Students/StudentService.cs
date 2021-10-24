using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.Photo;
using WebApplication1.Models.StudentTable;

namespace WebApplication1.Service.Students
{
    public class StudentService : IStudentService
    {
        private DbCtx _context;
        private IWebHostEnvironment _appEnvironment;
        public StudentService(DbCtx context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public List<Student> List()
        {
            var list = _context.Students.ToList();
            return list;
        }
        public void Create(Student student, IFormFile uploadedFile)
        {
            var newStudent = new Student();

            if (student != null)
            {
                newStudent.Name = student.Name;
                newStudent.Phone = student.Phone;
                newStudent.GroupId = student.GroupId;

                _context.Add(newStudent);
                _context.SaveChanges();

                if (uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "/Files/" + uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        uploadedFile.CopyTo(fileStream);
                    }
                    StudentPhoto file = new StudentPhoto { Name = uploadedFile.FileName, Path = path, StudentId = newStudent.Id };
                    _context.StudentPhotos.Add(file);
                    _context.SaveChanges();
                }
            }
        }
       
        public void Update(int id, Models.StudentTable.Student student, IFormFile uploadedFile)
        {
            if (id != 0 && student != null)
            {
                var currentStudent = _context.Students.Where(_ => _.Id == id).Include(_ => _.StudentPhoto).FirstOrDefault();
                if (currentStudent == null && currentStudent.StudentPhoto == null)
                {
                    _context.Add(student);
                    _context.SaveChanges();
                    if (uploadedFile != null)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            uploadedFile.CopyTo(fileStream);
                        }
                        StudentPhoto file = new StudentPhoto { Name = uploadedFile.FileName, Path = path, StudentId = currentStudent.Id };
                        _context.StudentPhotos.Add(file);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    currentStudent.Name = student.Name;
                    currentStudent.Phone = student.Phone;
                    currentStudent.GroupId = student.GroupId;

                    _context.Update(currentStudent);
                    _context.SaveChanges();

                    if (uploadedFile != null && currentStudent.StudentPhoto != null)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            uploadedFile.CopyTo(fileStream);
                        }
                        var newPhoto = currentStudent.StudentPhoto;
                        newPhoto.Name = uploadedFile.Name;
                        newPhoto.Path = path;
                        
                        _context.StudentPhotos.Update(newPhoto);
                        _context.SaveChanges();
                    }
                }

            }
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                var student = _context.Students.Where(_ => _.Id == id).FirstOrDefault();
                _context.Remove(student);
                _context.SaveChanges();

            }
        }
        public StudentViewModel GetById(int id)
        {
            var student = new StudentViewModel();
            if (id > 0)
            {
                var currentStudent = _context.Students.Where(_ => _.Id == id).Include(p => p.StudentPhoto).FirstOrDefault();
                student.Name = currentStudent.Name;
                student.Phone = currentStudent.Phone;
                student.GroupId = currentStudent.GroupId;
                student.StudentPhoto = currentStudent.StudentPhoto;
            }
            else
            {
                return null;
            }
            return student;
        }
    }
}
    
   

