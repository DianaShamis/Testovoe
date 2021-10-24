using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.TeacherTable;
using WebApplication1.Service.Teachers;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;

        private string _listTeacher = "~/Views/Teacher/Index.cshtml";
        private string _createTeacher = "~/Views/Teacher/Create.cshtml";
        private string _getById = "~/Views/Teacher/GetById.cshtml";
        private string _editTeacher = "~/Views/Teacher/Edit.cshtml";

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var teacherList = _teacherService.List();

            var model = new TeacherListViewModel
            {
                TeacherList = teacherList
            };
            return View(_listTeacher, model);
        }
        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            var teacher = _teacherService.GetById(id);
            return View(_getById, teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            var model = new Teacher();
            return View(_createTeacher, model);
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _teacherService.Create(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var currentTeacher = _teacherService.GetById(id);
            return View(_editTeacher, currentTeacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _teacherService.Update(id, teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            _teacherService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: TeacherController/Delete/5
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
