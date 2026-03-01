using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class DepartmentManager : IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<DepartmentReadVM> GetDepartments()
        {
            var departmentsVM = _unitOfWork.DepartmentRepository.GetAll().Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            });
            return departmentsVM;
        }
        /*------------------------------------------------------------------*/
        public DepartmentReadVM? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }

            // Map From Domain Model To View Model
            var departmentReadVM = new DepartmentReadVM
            {
                Id = department.Id,
                Name = department.Name
            };

            return departmentReadVM;
        }
        /*------------------------------------------------------------------*/
        public DepartmentEditVM? GetDepartmentByIdForEdit(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }
            var departmentEditVM = new DepartmentEditVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return departmentEditVM;
        }
        /*------------------------------------------------------------------*/
        public void Insert(DepartmentCreateVM departmentCreateVM)
        {
            var department = new Department
            {
                Name = departmentCreateVM.Name
            };

            _unitOfWork.DepartmentRepository.Add(department);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
        public void Delete(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if(department == null)
            {
                return;
            }
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
        public void Edit(DepartmentEditVM departmentEditVM)
        {
           var departmentInDB = _unitOfWork.DepartmentRepository.GetById(departmentEditVM.Id);
            if (departmentInDB == null)
            {
                return;
            }
            // Map From VM To Domain Model
            departmentInDB.Name = departmentEditVM.Name;
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
    }
}
