using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.GroupTable;
using WebApplication1.Service.Groups;

namespace WebApplication1.Controllers
{
    public class GroupController : Controller
    {
        private IGroupService _groupService;

        private string _listGroup = "~/Views/Group/Index.cshtml";
        private string _createGroup = "~/Views/Group/Create.cshtml";
        private string _getById = "~/Views/Group/GetById.cshtml";
        private string _editGroup = "~/Views/Group/Edit.cshtml";

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var groupList = _groupService.List();

            var model = new GroupListViewModel
            {
                GroupList = groupList
            };
            return View(_listGroup, model);
        }
        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            var group = _groupService.GetById(id);
            return View(_getById, group);
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            var model = new Group();
            return View(_createGroup, model);
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            try
            {
                _groupService.Create(group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            var currentGroup = _groupService.GetById(id);
            return View(_editGroup, currentGroup);
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Group group)
        {
            try
            {
                _groupService.Update(id, group);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            _groupService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: GroupController/Delete/5
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
