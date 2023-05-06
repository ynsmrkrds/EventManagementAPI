using EventManagement.API.Extensions.Attributes;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword;
using EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetProfile;
using EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetToken;
using EventManagement.Application.DTOs.ResponseDTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getProfile")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> GetProfile()
        {
            GetProfileQueryResponse queryResponse = await _mediator.Send(new GetProfileQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Profile));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] GetTokenQueryRequest request)
        {
            GetTokenQueryResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccesful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse));
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserCommandRequest request)
        {
            CreateUserCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Route("updateProfile")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Route("updatePassword")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest request)
        {
            UpdatePasswordCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
