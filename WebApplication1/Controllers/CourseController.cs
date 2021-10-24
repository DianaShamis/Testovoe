using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.CourseTable;
using WebApplication1.Service.Courses;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        private string _listCourse = "~/Views/Course/Index.cshtml";
        private string _createCourse = "~/Views/Course/Create.cshtml";
        private string _getById = "~/Views/Course/GetById.cshtml";
        private string _editCourse = "~/Views/Course/Edit.cshtml";

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var courseList = _courseService.List();

            var model = new CourseListViewModel
            {
                CourseList = courseList
            };
            return View(_listCourse, model);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = _courseService.GetById(id);
            return View(_getById, course);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            var model = new Course();
            return View(_createCourse, model);
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _courseService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var currentCourse = _courseService.GetById(id);
            return View(_editCourse, currentCourse);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _courseService.Update(id, course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: CourseController/Delete/5
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
