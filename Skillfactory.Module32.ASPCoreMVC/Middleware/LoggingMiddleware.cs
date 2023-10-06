namespace Skillfactory.Module32.ASPCoreMVC.Middleware;
public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";
        Console.WriteLine(logMessage);

        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RequestLog.txt");
        await File.AppendAllTextAsync(logFilePath, logMessage);

        await _next.Invoke(context);
    }
}
