using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BubberDinner.WebApi.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var errorResult = new { error = "An error occurred when processing your request" };
            
            context.Result = new ObjectResult(errorResult)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}