using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Pokemon
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<MyExceptionFilter> ilogger;

        public MyExceptionFilter(ILogger<MyExceptionFilter> ilogger)
        {
            this.ilogger = ilogger;
        }

        public override void OnException(ExceptionContext context)
        {
            ilogger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }

    }
}
