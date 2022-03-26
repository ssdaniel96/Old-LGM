using LGM.Api.Filters;
using LGM.IoC.ServicesCollection;

namespace LGM.Api;

public class Startup : IStartup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddInfrastructure(Configuration);

        services.AddMvcCore(config => {
            config.Filters.Add<ExceptionFilter>();
            config.Filters.Add<TransactionFilter>();
        });
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}

public interface IStartup
{
    IConfiguration Configuration { get; }
    void ConfigureServices(IServiceCollection services);
    void Configure(WebApplication app, IWebHostEnvironment environment);
}

public static class StartupExtesnsions
{
    public static WebApplicationBuilder UseStartup<TStartUp>(this WebApplicationBuilder webAppBuilder)
        where TStartUp : IStartup
    {
        var startup = Activator.CreateInstance(typeof(TStartUp), webAppBuilder.Configuration) as IStartup;
        if (startup == null) throw new ArgumentException("Startup.cs invalid!");

        startup.ConfigureServices(webAppBuilder.Services);

        var app = webAppBuilder.Build();
        startup.Configure(app, app.Environment);

        app.Run();

        return webAppBuilder;
    }
}