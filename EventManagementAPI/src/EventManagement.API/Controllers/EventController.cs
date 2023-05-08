using EventManagement.API.Extensions.Attributes;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandCreateEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandReviewEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetAllEvents;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetEventByID;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetOrganizedEvents;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetParticipatedEvents;
using EventManagement.Application.DTOs.ResponseDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            GetEventByIDQueryResponse queryResponse = await _mediator.Send(new GetEventByIDQueryRequest(id));
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Event));
        }

        [HttpGet]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> GetAll()
        {
            GetAllEventsQueryResponse queryResponse = await _mediator.Send(new GetAllEventsQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Events));
        }

        [HttpGet]
        [Route("organized")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> GetOrganizedEvents()
        {
            GetOrganizedEventsQueryResponse queryResponse = await _mediator.Send(new GetOrganizedEventsQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Events));
        }

        [HttpGet]
        [Route("participated")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> GetParticipatedEvents()
        {
            GetParticipatedEventsQueryResponse queryResponse = await _mediator.Send(new GetParticipatedEventsQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Events));
        }

        [HttpPost]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateEventCommandRequest request)
        {
            CreateEventCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateEventCommandRequest request)
        {
            UpdateEventCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Route("cancel")]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Cancel([FromBody] CancelEventCommandRequest request)
        {
            CancelEventCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Route("review")]
        [Authority("Admin")]
        public async Task<IActionResult> Review([FromBody] ReviewEventCommandRequest request)
        {
            ReviewEventCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
