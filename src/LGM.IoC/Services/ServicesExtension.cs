using LGM.DTOS.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LGM.IoC.Services
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions(configuration)
                .AddDependencies();

            return services;
        }

        private static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.Scan(scan => {
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime();
            });

            return services;
        }

        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiVersionOptionDto>(v => {
                v.Version = configuration.GetSection("ApiVersion").Value;
            });

            return services;
        }
    }
}