using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class AppDbContext : DbContext
    {
        /*------------------------------------------------------------------*/
        public AppDbContext() : base() { }
        /*------------------------------------------------------------------*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        /*------------------------------------------------------------------*/
        public override int SaveChanges()
        {
            AuditLog();
            return base.SaveChanges();
        }
        /*------------------------------------------------------------------*/
        private void AuditLog()
        {
            var dateTime = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = dateTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = dateTime;
                }
            }
        }
        /*------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var createdDate = new DateTime(2026, 3, 1, 10, 30, 0);

            // Seeding
            var _departments = new List<Department>()
            {
                new Department {Id = 1, Name = "SD", CreatedAt = createdDate },
                new Department {Id = 2, Name = "UI", CreatedAt = createdDate},
                new Department {Id = 3, Name = "Mob", CreatedAt = createdDate },
                new Department {Id = 4, Name = "UX", CreatedAt = createdDate }
            };

            var _employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Ahmed", Age = 26 , Salary = 1234, CreatedAt = createdDate, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Mohamed", Age = 36 , Salary = 2234, CreatedAt = createdDate, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Sara", Age = 46 , Salary = 4234, CreatedAt = createdDate, DepartmentId = 3 },
                new Employee { Id = 4, Name = "Omar", Age = 25 , Salary = 5234, CreatedAt = createdDate, DepartmentId = 4 },
                new Employee { Id = 5, Name = "Ali", Age = 23 , Salary = 6234, CreatedAt = createdDate, DepartmentId = 1 },
                new Employee { Id = 6, Name = "Mai", Age = 36 , Salary = 7234, CreatedAt = createdDate, DepartmentId = 2 },
                new Employee { Id = 7, Name = "Ramy", Age = 49 , Salary = 8234, CreatedAt = createdDate, DepartmentId = 3 },
                new Employee { Id = 8, Name = "Hamada", Age = 18 , Salary = 9234, CreatedAt = createdDate, DepartmentId = 4 },
                new Employee { Id = 9, Name = "Hatem", Age = 26 , Salary = 10234, CreatedAt = createdDate, DepartmentId = 1 },
                new Employee { Id = 10, Name = "Osama", Age = 25 , Salary = 17234, CreatedAt = createdDate, DepartmentId = 2 },
            };

            modelBuilder.Entity<Department>().HasData(_departments);
            modelBuilder.Entity<Employee>().HasData(_employees);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        /*------------------------------------------------------------------*/
        // db.Employees = []; XXX
        // db.Employees.ToList(); => Get
        //public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<Employee> Employees { get; }
        public virtual DbSet<Employee> Employees => Set<Employee>();
        public virtual DbSet<Department> Departments => Set<Department>();
        /*------------------------------------------------------------------*/
    }
}
