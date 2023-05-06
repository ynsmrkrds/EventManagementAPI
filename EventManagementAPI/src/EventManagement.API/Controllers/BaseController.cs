using EventManagement.Application.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult(APIResponseDTO response)
        {
            return new ObjectResult(response.StatusCode == HttpStatusCode.NoContent ? null : response)
            {
                StatusCode = (int)response.StatusCode
            };
        }
    }
}
