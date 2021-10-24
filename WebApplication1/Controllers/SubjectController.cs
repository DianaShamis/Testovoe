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
        private ISubjectService _subjectService;
        private ITeacherService _teacherService;

        private string _listSubject = "~/Views/Subject/Index.cshtml";
        private string _createSubject = "~/Views/Subject/Create.cshtml";
        private string _getById = "~/Views/Subject/GetById.cshtml";
        private string _editSubject = "~/Views/Subject/Edit.cshtml";

        public SubjectController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            var subjectList = _subjectService.List();

            var model = new SubjectListViewModel
            {
                SubjectList = subjectList
            };
            return View(_listSubject, model);
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            var subject = _subjectService.GetById(id);
            return View(_getById, subject);
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

            var subject = new SubjectViewModel();
            subject.TeacherList = selectListItem;

            return View(_createSubject, subject);

        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _subjectService.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var groupList = _teacherService.List();
            var selectListItem = groupList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            selectListItem.Insert(0, new SelectListItem { Text = "", Value = "" });

            var subject = _subjectService.GetById(id);
            var model = new SubjectViewModel
            {
                Subject = subject,
                TeacherList = selectListItem
            };

            return View(_editSubject, model);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Subject collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NoContent();
                else
                    _subjectService.Update(id, collection);
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
