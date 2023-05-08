using EventManagement.API.Extensions.Attributes;
using EventManagement.Application.CQRSs.TicketContextCQRSs.CommandCheckTicket;
using EventManagement.Application.CQRSs.TicketContextCQRSs.CommandPurchaseTicket;
using EventManagement.Application.CQRSs.TicketContextCQRSs.QueryGetAllTickets;
using EventManagement.Application.DTOs.ResponseDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : BaseController
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Get()
        {
            GetAllTicketCommandResponse queryResponse = await _mediator.Send(new GetAllTicketCommandRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Tickets));
        }

        [HttpPost]
        [Route("check")]
        [Authority("Admin")]
        public async Task<IActionResult> Check([FromBody] CheckTicketCommandRequest request)
        {
            CheckTicketCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPost]
        [Route("purchase")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Purchase([FromBody] PurchaseTicketCommandRequest request)
        {
            PurchaseTicketCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
