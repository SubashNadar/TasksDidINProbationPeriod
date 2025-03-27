using Microsoft.EntityFrameworkCore;

namespace JqueryAjaxWebApp.Models
{
    public class EmployeeApp:DbContext
    {
        public EmployeeApp(DbContextOptions<EmployeeApp>options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<EmployeeJobDetails> EmployeeJobDetails { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<RoleT> RoleT { get; set; }

        public DbSet<CState> CState { get; set; }
        public DbSet<department> Department { get; set; }
    }
}
