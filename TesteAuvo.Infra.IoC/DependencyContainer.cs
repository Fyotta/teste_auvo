using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services;
using TesteAuvo.Infra.Data;
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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITimeSheetClosureService, TimeSheetClosureService>();
            return services;
        }
}