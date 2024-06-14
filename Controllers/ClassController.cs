using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.Services.ClassService;

namespace MVCApplication.Controllers
{
    public class ClassController : Controller
    {
        IClassRepository _classRepo;
        public ClassController( IClassRepository classRepo)
        {
           _classRepo = classRepo;
        }
        public IActionResult Index()
        {
            List<Class> classList = _classRepo.GetAll();
            return View(classList);
        }
        [HttpGet]
        public IActionResult Create() 
        { 
            Class c = new Class();
            return View(c);
        }
        [HttpPost]
        public IActionResult Create(Class c) 
        { 
            if(ModelState.IsValid)
            {
                int id = _classRepo.CreateOrUpdate(c);
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return View(c);
            }
           
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            Class c = _classRepo.Get(id);
            return View("Create",c);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Class c= _classRepo.Get(id);
            if(c!=null)
            {
                int result = _classRepo.Delete(c);
                if(result>0)
                {
                    ViewBag.message = "Successfully Deleted!";
                }
            }
            return RedirectToAction("Index", "Class");
        }
    }
}
