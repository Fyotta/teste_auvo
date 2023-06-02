using Microsoft.EntityFrameworkCore;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Infra.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeTimeRecord> EmployeeTimeRecords { get; set; }
}