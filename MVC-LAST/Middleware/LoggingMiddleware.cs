using System.Diagnostics;

namespace MVC.Middleware
{
    public class LoggingMiddleware
    {
        private RequestDelegate next;

        public LoggingMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine($"Request ==> {context.Request.Path} ,  Method => {context.Request.Method}");
            await next(context);
            sw.Stop();
            Console.WriteLine($"Response => CODE :{context.Response.StatusCode},{sw.ElapsedMilliseconds } MS ");
        }
    }
}
