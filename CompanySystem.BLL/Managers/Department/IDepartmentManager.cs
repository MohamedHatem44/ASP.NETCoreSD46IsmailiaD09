namespace CompanySystem.BLL
{
    public interface IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        // Get All Departments (View Model)
        IEnumerable<DepartmentReadVM> GetDepartments();
        /*------------------------------------------------------------------*/
        // Get Department By Id (View Model)
        DepartmentReadVM? GetDepartmentById(int id);
        /*------------------------------------------------------------------*/
        // Get Department By Id (View Model)
        DepartmentEditVM? GetDepartmentByIdForEdit(int id);
        /*------------------------------------------------------------------*/
        // Insert
        void Insert(DepartmentCreateVM departmentCreateVM);
        /*------------------------------------------------------------------*/
        // Edit
        void Edit(DepartmentEditVM departmentEditVM);
        /*------------------------------------------------------------------*/
        // Delete
        void Delete(int id);
        /*------------------------------------------------------------------*/
    }
}
