namespace Skillfactory.Module32.ASPCoreMVC;

public class Startup
{
    public IWebHostEnvironment WebHostEnv { get; }

    public Startup(IWebHostEnvironment env)
    {
        WebHostEnv = env;
    }
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsStaging())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.Use(async (context, next) =>
        {
            // Simple Logging http context.
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            await next.Invoke();
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!");
            });
        });

        app.Map("/about", About);
        app.Map("/config", ConfigInfo);

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync($"Page not found");
        });
    }

    private void About(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync($"{WebHostEnv.ApplicationName} - ASP.Net Core tutorial project");
        });
    }

    private void ConfigInfo(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync($"App name: {WebHostEnv.ApplicationName}. App running configuration: {WebHostEnv.EnvironmentName}");
        });
    }
}
