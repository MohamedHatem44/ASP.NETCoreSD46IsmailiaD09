namespace CompanySystem.BLL
{
    public interface IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        // Get All Employees (View Model)
        IEnumerable<EmployeeReadVM> GetEmployees();
        /*------------------------------------------------------------------*/
        // Get Employee By Id (View Model)
        EmployeeReadVM? GetEmployeeById(int id);
        /*------------------------------------------------------------------*/
        // Create Employee (View Model)
        EmployeeCreateVM ReturnListDepartment();
        /*------------------------------------------------------------------*/
        // Create New Employee
        void CreateEmployee(EmployeeCreateVM employeeCreateVM);
        /*------------------------------------------------------------------*/
    }
}
