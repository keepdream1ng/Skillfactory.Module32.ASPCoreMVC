namespace Skillfactory.Module32.ASPCoreMVC;

public class Startup
{
    public IWebHostEnvironment WebHotsEnviroment { get; }

    public Startup(IWebHostEnvironment env)
    {
       WebHotsEnviroment = env;
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

        app.Map("/about", About);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/config", async context =>
            {
                await context.Response.WriteAsync($"App name: {env.ApplicationName}. App running configuration: {env.EnvironmentName}");
            });
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!");
        });
    }

    private void About(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync($"{WebHotsEnviroment.ApplicationName} - ASP.Net Core tutorial project");
        });
    }
}
