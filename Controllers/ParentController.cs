using Microsoft.AspNetCore.Mvc;
using MVCApplication.DataAccess;
using MVCApplication.Models;
using MVCApplication.Models.Common;
using MVCApplication.Services.ParentService;
using MVCApplication.Services.StudentService;
using System.Collections.Generic;

namespace MVCApplication.Controllers
{
    public class ParentController : Controller
    {
        IParentRepository _repo;
        //IRepository<Student> _studentRepository;
        public ParentController(IParentRepository parentRepository)
        {
            _repo = parentRepository;
        }
        public IActionResult Index()
        {
          
            List<Parent> parentList = new List<Parent>();
            parentList =_repo.GetAll();
            return View(parentList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Parent p = new Parent();
            return View(p);
        }
        [HttpPost]
        public IActionResult Create(Parent parent)
        {
            if (ModelState.IsValid)
            {
                //_studentRepository.CreateOrUpdate()
               int id= _repo.CreateOrUpdate(parent);
                return RedirectToAction("Index", "Parent");
            }
            else
            {
                return View();
            }            
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            Parent? p = _repo.Get(id);
            int result = _repo.Delete(p);
            return RedirectToAction("Index","Parent"); 
        }
        public IActionResult Edit(int id)
        {
            Parent? p = _repo.Get(id);
            return View("Create",p);
        }
    }
}

