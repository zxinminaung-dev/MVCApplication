using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.Services.ClassService;
using MVCApplication.Services.ParentService;
using MVCApplication.Services.StudentService;
using MVCApplication.ViewModel;

namespace MVCApplication.Controllers
{
    public class StudentController : Controller
    {
        IParentRepository _parentRepo;
        IStudentRepository _studentRepo;
        IClassRepository _classRepo;
        public StudentController(IParentRepository parentRepository, IStudentRepository studentRepository,
            IClassRepository classRepository) 
        { 
            _parentRepo = parentRepository;
            _studentRepo = studentRepository;
            _classRepo = classRepository;
        }
        public IActionResult Index()
        {
            List<Student> list = new List<Student>();
            list = _studentRepo.GetAll();
            List<StudentViewModel> vmList = MapModelToViewModel(list);
            return View(vmList);
        }
        public IActionResult Create()
        {
            List<Parent> parentList =_parentRepo.GetAll();
            List<Class> classList = _classRepo.GetAll();
            ViewBag.ParentList = parentList;
            ViewBag.ClassList = classList;
            Student s = new Student();
            return View(s);
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                //_studentRepository.CreateOrUpdate()
                int id = _studentRepo.CreateOrUpdate(s);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View();
            }
        }
        private List<StudentViewModel> MapModelToViewModel(List<Student> list)
        {
           List<StudentViewModel> vmList = new List<StudentViewModel>();
            foreach(var student in list)
            {
                StudentViewModel vm = new StudentViewModel();
                vm.id = student.id;
                vm.name = student.name;
                vm.date_of_birth = student.dob;
                if (student.Class != null)
                {
                    vm.class_name = student.Class.name;
                    vm.education_year = student.Class.education_year;
                }
                if (student.Parent != null)
                {
                    vm.father_name = student.Parent.father_name;
                    vm.mother_name = student.Parent.mother_name;
                }
                vmList.Add(vm);
            }
            return vmList;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Parent> parentList = _parentRepo.GetAll();
            List<Class> classList = _classRepo.GetAll();
            ViewBag.ParentList = parentList;
            ViewBag.ClassList = classList;
            Student? p = _studentRepo.Get(id);
            return View("Create", p);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student? p = _studentRepo.Get(id);
            int result = _studentRepo.Delete(p);
            return RedirectToAction("Index", "Student");
        }
    }
}
