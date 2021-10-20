using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.SubjectTable;
using WebApplication1.Service.Subjects;
using WebApplication1.Service.Teachers;

namespace WebApplication1.Controllers
{
    public class SubjectController : Controller
    {
        private ITeacherService _teacherService;
        private  ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _subjectService = subjectService;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            var subjectList = _subjectService.List();
           

            var model = new SubjectListViewModel
            {
                SubjectList = subjectList
            };
            return View(model);
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            var teacherList = _teacherService.List();
            var selectListItem = teacherList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            selectListItem.Insert(0, new SelectListItem { Text = "", Value = "" });
            
            var model = new SubjectViewModel();
            model.TeacherList = selectListItem;
            return View( model);
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel model)
        {
           
          

        
            var subject = new Subject()
            {
                Id = model.Id,
                Name = model.Name,
                TeacherId = model.TeacherId,
                Teacher=model.Teacher

            };
           
            _subjectService.Create(subject);
            return View("Index");
           
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var currentSubject = _subjectService.GetById(id);
            return View( currentSubject);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var subject = _subjectService.GetById(id);

            try
            {
                _subjectService.Update(id, subject);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            _subjectService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: SubjectController/Delete/5
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
