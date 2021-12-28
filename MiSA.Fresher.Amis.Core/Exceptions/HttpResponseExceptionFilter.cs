using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiSA.Fresher.Amis.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                var result = new
                {
                    devMsg = Properties.VNResources.BadRequest,
                    userMgs = Properties.VNResources.ExceptionError,
                    data = httpResponseException.Value,
                    status = (int)StatusError.BadRequest,
                    moreInfo = ""
                };
                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)StatusError.BadRequest
                };

                context.ExceptionHandled = true;
            }
            else if(context.Exception != null)
            {
                var result = new
                {
                    devMsg = Properties.VNResources.Internal_Server_Error,
                    userMgs = Properties.VNResources.ExceptionError,
                    data = DBNull.Value,
                    status = (int)StatusError.Internal_Server_Error,
                    moreInfo = ""
                };
                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)StatusError.Internal_Server_Error,
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
