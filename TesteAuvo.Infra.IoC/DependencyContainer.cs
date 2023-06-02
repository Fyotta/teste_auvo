using Microsoft.Extensions.DependencyInjection;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services;
using TesteAuvo.Infra.Data;

namespace TesteAuvo.Infra.IoC;

public static class DependencyContainer
{
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICsvParserService<,>), typeof(CsvParser<,>));
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITimeSheetClosureService, TimeSheetClosureService>();
            return services;
        }
}