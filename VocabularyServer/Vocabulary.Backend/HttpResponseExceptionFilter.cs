using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vocabulary.Backend.Exceptions;

namespace Vocabulary.Backend
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public int Order { get; } = int.MaxValue - 10;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is HttpResponseException exception)) return;

            context.Result = new ObjectResult(exception.Value)
            {
                StatusCode = (int)exception.StatusCode
            };
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
}