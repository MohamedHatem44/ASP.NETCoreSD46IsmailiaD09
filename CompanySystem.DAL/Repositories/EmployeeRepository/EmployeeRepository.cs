using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class EmployeeRepository : GenericRepository<Employee> ,IEmployeeRepository
    {
        /*------------------------------------------------------------------*/
        public EmployeeRepository(AppDbContext context): base(context)
        {
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<Employee> GetAllWithDepartment()
        {
            //return _context.Set<Employee>.Include(e => e.Department).ToList();
            return _context.Employees
                .Include(e => e.Department).ToList();
        }
        /*------------------------------------------------------------------*/
        public Employee? GetByIdWithDepartment(int EmployeeID)
        {
            return _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == EmployeeID);
        }
        /*------------------------------------------------------------------*/
        //public int Save()
        //{
        //    return _context.SaveChanges();
        //}
        /*------------------------------------------------------------------*/
    }
}
