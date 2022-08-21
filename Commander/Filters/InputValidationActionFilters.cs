using System;
using System.Linq;
using Commander.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountBalance.Filters
{
    public class InputValidationActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // need logic only for OnActionExecuting
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = string.Join("; ",context. ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                
                var notification = new NotificationDto()
                {
                    Message = messages,
                    Timestamp = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss"),
                    Uuid = Guid.NewGuid().ToString()
                };
                
                context.Result = new JsonResult(notification)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
