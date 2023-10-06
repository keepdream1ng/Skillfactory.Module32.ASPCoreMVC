namespace Skillfactory.Module32.ASPCoreMVC;

public class Startup
{
    // Метод вызывается средой ASP.NET.
    // Используйте его для подключения сервисов приложения
    // Документация:  https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // Метод вызывается средой ASP.NET.
    // Используйте его для настройки конвейера запросов
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsStaging())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context => { await context.Response.WriteAsync($"Hello World! Config: {env.EnvironmentName}"); });
        });
    }
}
