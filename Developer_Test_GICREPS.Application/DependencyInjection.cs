using Developer_Test_GICREPS.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Developer_Test_GICREPS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IActualService, ActualService>();
            services.AddTransient<IEstimateService, EstimateSerive>();
            services.AddTransient<IGicService, GicService>();
            return services;
        }
    }
}
