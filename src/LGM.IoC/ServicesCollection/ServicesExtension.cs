using LGM.Application.Mappings.Groups;
using LGM.DTOS.Options;
using LGM.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Scrutor;

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
                .AddAdaptersDependencies();

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);

            return services;
        }

        private static IServiceCollection AddAdaptersDependencies(this IServiceCollection services)
        {
            services.Scan(scan => {
                scan.FromDependencyContext(DependencyContext.Default)
                    .AddClasses(classes => classes.Where(
                        c => c.Name.EndsWith("Repository")
                          || c.Name.EndsWith("Service")
                             && c.AssemblyQualifiedName!.Contains("LGM")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
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