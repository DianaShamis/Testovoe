using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.StudentTable;
using WebApplication1.Service.Groups;
using WebApplication1.Service.Students;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IGroupService _groupService;
       
        private string _listStudent = "~/Views/Student/Index.cshtml";
        private string _createStudent = "~/Views/Student/Create.cshtml";
        private string _getById = "~/Views/Student/GetById.cshtml";
        private string _editStudent = "~/Views/Student/Edit.cshtml";

        public StudentController(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var studentList = _studentService.List();

            var model = new StudentListViewModel
            {
                StudentList = studentList
            };
            return View(_listStudent, model);
        }

        // GET: StudentController1/Details/5
        public ActionResult Details(int id)
        {
            var student = _studentService.GetById(id);
            return View(_getById, student);
        }

        // GET: StudentController1/Create
        public ActionResult Create()
        {
            var groupList = _groupService.List();
            var selectListItem = groupList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            selectListItem.Insert(0, new SelectListItem { Text = "", Value = "" });

            var model = new StudentViewModel();
            model.GroupList = selectListItem;

            return View(_createStudent, model);
        }

        // POST: StudentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, IFormFile uploadedFile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _studentService.Create(student, uploadedFile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController1/Edit/5
        public ActionResult Edit(int id)
        {
            var groupList = _groupService.List();
            var selectListItem = groupList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            selectListItem.Insert(0, new SelectListItem { Text = "", Value = "" });

            var student = _studentService.GetById(id);
            student.GroupList = selectListItem;

            return View(_editStudent, student);
        }

        // POST: StudentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student, IFormFile uploadedFile)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _studentService.Update(id, student, uploadedFile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController1/Delete/5
        public ActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: StudentController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
