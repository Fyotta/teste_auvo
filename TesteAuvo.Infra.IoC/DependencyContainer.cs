using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteAuvo.Application.Interfaces;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Domain.Interfaces.Abstractions;
using TesteAuvo.Infra.Data;
using TesteAuvo.Infra.Data.Repositories;
using TesteAuvo.Infra.Storage.Services;

namespace TesteAuvo.Infra.IoC;

public static class DependencyContainer
{
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseSqlite(configuration.GetConnectionString("Default")));
            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICsvParserService<,>), typeof(CsvParserService<,>));
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IBookEmployeeTimeRecordRepository, BookEmployeeTimeRecordRepository>();
            services.AddScoped<IEmployeeTimeRecordRepository, EmployeeTimeRecordRepository>();

            services.AddScoped<IRepositoryBase<Employee>, EmployeeRepository>();
            services.AddScoped<IRepositoryBase<Department>, DepartmentRepository>();
            services.AddScoped<IRepositoryBase<BookEmployeeTimeRecord>, BookEmployeeTimeRecordRepository>();
            services.AddScoped<IRepositoryBase<EmployeeTimeRecord>, EmployeeTimeRecordRepository>();
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITimeSheetClosureService, TimeSheetClosureService>();
            services.AddScoped<IBookEmployeeTimeRecordService, BookEmployeeTimeRecordService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeTimeRecordService, EmployeeTimeRecordService>();
            services.AddScoped<IImportCsvDataService, ImportCsvDataService>();
            return services;
        }
}