using Microsoft.DotNet.Scaffolding.Shared.Messaging;


namespace MVC.Middleware
{
    public class GlobalExceptionHandleMiddleware
    {
        private RequestDelegate next;

        public GlobalExceptionHandleMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task Invoke(HttpContext contex)
        {
            try {
                await next(contex);
            }
           
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //OPEN INSTRUCTOR TO THROW ERROR IN TERMINAL
        }
    }
}
