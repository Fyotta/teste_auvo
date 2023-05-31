using Microsoft.Extensions.DependencyInjection;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Infra.Data;

namespace TesteAuvo.Infra.IoC;

public static class DependencyContainer
{
        public static IServiceCollection AddTesteAuvoDataServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICsvParserService<>), typeof(CsvParser<>));
            return services;
        }
        
}