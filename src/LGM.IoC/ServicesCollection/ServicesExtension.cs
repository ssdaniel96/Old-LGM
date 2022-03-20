using LGM.Adapter.Repositories.HealthChecks;
using LGM.Application.Mappings.Groups;
using LGM.DTOS.Options;
using LGM.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace LGM.IoC.ServicesCollection
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration)
                .AddOptions(configuration)
                .AddMappers()
                .AddDependencies();

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);

        private static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.Scan(scan => {
                var assemblies = new Assembly[] {
                    Assembly.GetEntryAssembly(), // LGM.Api
                    typeof(IHealthCheckRepository).Assembly, //LGM.Adapter
                    typeof(DomainToDtoMappingProfile).Assembly, //LGM.Application
                    typeof(ApplicationDbContext).Assembly //LGM.Repository
                };

                scan.FromAssemblies(assemblies)
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

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information));

            return services;
        }
    }
}