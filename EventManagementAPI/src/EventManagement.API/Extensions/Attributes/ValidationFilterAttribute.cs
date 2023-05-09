using EventManagement.Application.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Extensions.Attributes
{
    public class ValidatationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Dictionary<string, string> errorResponse = new();
                foreach (var item in context.ModelState)
                {
                    if (item.Value.Errors.Any())
                    {
                        string[] errorMessages = item.Value.Errors
                            .Select(error => error.ErrorMessage)
                            .ToArray();

                        errorResponse.Add(item.Key, errorMessages.Last());
                    }
                }

                context.Result = new BadRequestObjectResult(new APIResponseDTO(HttpStatusCode.BadRequest, errorResponse.Values.ToList()));
            }
        }
    }
}
