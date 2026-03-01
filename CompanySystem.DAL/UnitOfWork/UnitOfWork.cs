namespace CompanySystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public UnitOfWork(AppDbContext context,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
