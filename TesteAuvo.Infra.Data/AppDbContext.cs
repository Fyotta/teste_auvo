using Microsoft.EntityFrameworkCore;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Infra.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(employee => employee.EmployeeTimeRecords)
            .WithOne(employeeTimeRecord => employeeTimeRecord.Employee)
            .HasForeignKey(employeeTimeRecord => employeeTimeRecord.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(employee => employee.PaymentOrders)
            .WithOne(paymentOrders => paymentOrders.Employee)
            .HasForeignKey(paymentOrder => paymentOrder.EmployeeId);

        modelBuilder.Entity<Department>()
            .HasMany(department => department.BookEmployeeTimeRecords)
            .WithOne(betr => betr.Department)
            .HasForeignKey(betr => betr.DepartmentId);

        modelBuilder.Entity<BookEmployeeTimeRecord>()
            .HasMany(bookEmployeeTimeRecord => bookEmployeeTimeRecord.EmployeeTimeRecords)
            .WithOne(employeeTimeRecords => employeeTimeRecords.BookEmployeeTimeRecord)
            .HasForeignKey(employeeTimeRecords => employeeTimeRecords.BookEmployeeTimeRecordId);

        modelBuilder.Entity<BookEmployeeTimeRecord>()
            .HasOne(bookEmployeeTimeRecord => bookEmployeeTimeRecord.TimeSheetClosure)
            .WithOne(timeSheetClosure => timeSheetClosure.BookEmployeeTimeRecord)
            .HasForeignKey<TimeSheetClosure>(timesheetClosure => timesheetClosure.BookEmployeeTimeRecordId);

        modelBuilder.Entity<TimeSheetClosure>()
            .HasMany(timeSheetClosure => timeSheetClosure.PaymentOrders)
            .WithOne(paymentOrders => paymentOrders.TimeSheetClosure)
            .HasForeignKey(paymentOrders => paymentOrders.TimeSheetClosureId);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeTimeRecord> EmployeeTimeRecords { get; set; }
    public DbSet<BookEmployeeTimeRecord> BookEmployeeTimeRecords { get; set; }
    public DbSet<TimeSheetClosure> TimeSheetClosures { get; set; }
    public DbSet<PaymentOrder> PaymentOrders { get; set; }
}