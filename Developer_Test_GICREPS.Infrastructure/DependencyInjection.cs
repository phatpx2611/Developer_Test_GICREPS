using Developer_Test_GICREPS.Application.Common.Interfaces.Infratructure;
using Developer_Test_GICREPS.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Developer_Test_GICREPS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IActualDataService, ActualDataService>();
            services.AddTransient<IEstimateDataService, EstimateDataService>();
            return services;
        }
    }
}
