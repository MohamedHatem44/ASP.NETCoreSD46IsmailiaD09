using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class EmployeeManager : IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<EmployeeReadVM> GetEmployees()
        {
            var employeesVM = _unitOfWork.EmployeeRepository.GetAllWithDepartment()
            .Select(e => new EmployeeReadVM
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department.Name
            });
            return employeesVM;
        }
        /*------------------------------------------------------------------*/
        public EmployeeReadVM? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByIdWithDepartment(id);
            if (employee == null)
            {
                return null;
            }
            var employeeReadVM = new EmployeeReadVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Department = employee.Department.Name
            };
            return employeeReadVM;
        }

        /*------------------------------------------------------------------*/
        public EmployeeCreateVM ReturnListDepartment()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentVMs = departments.Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            var employeeCreateVM = new EmployeeCreateVM
            {
                Departments = departmentVMs
            };
            return employeeCreateVM;
        }
        /*------------------------------------------------------------------*/
        public void CreateEmployee(EmployeeCreateVM employeeCreateVM)
        {
            var employeeDomainModel = new Employee
            {
                Name = employeeCreateVM.Name!,
                Age = employeeCreateVM.Age,
                Salary = employeeCreateVM.Salary,
                DepartmentId = employeeCreateVM.DepartmentId
            };
            _unitOfWork.EmployeeRepository.Add(employeeDomainModel);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
    }
}
