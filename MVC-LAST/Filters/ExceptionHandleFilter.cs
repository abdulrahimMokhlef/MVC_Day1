using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    public class ExceptionHandleFilter :Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult  res = new ContentResult();
            //res.Content = $"An error occurred: {context.Exception.Message} => {context.ActionDescriptor.DisplayName} ";
            ViewResult res = new ViewResult();
            res.ViewName = "Error";
            context.Result = res;
        }
    }
}
