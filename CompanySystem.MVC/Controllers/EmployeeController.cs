using CompanySystem.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NETCoreD08.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly IEmployeeManager _employeeManager;
        /*------------------------------------------------------------------*/
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        /*------------------------------------------------------------------*/
       [HttpGet]
        public IActionResult Index()
        {
            var employeesReadVM = _employeeManager.GetEmployees();
            return View(employeesReadVM);
        }
        /*------------------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employeeReadVM = _employeeManager.GetEmployeeById(id);
            if (employeeReadVM == null)
            {
                return RedirectToAction("Index");
            }
            return View(employeeReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            var employeeCreateVM = _employeeManager.ReturnListDepartment();
            // To Do Map To SelectList Item
            ViewBag.Departments =  new SelectList(employeeCreateVM.Departments, "Id", "Name");
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateVM employeeCreateVM)
        {
            if(!ModelState.IsValid)
            {
                var employeeCreateVMWithDepartments = _employeeManager.ReturnListDepartment();
                employeeCreateVM.Departments = employeeCreateVMWithDepartments.Departments;
                ViewBag.Departments = new SelectList(employeeCreateVM.Departments, "Id", "Name");
                return View(employeeCreateVM);
            }
            _employeeManager.CreateEmployee(employeeCreateVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
