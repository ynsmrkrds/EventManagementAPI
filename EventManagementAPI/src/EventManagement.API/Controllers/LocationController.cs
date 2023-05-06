using EventManagement.API.Extensions.Attributes;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandDeleteCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation;
using EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation;
using EventManagement.Application.CQRSs.LocationContextCQRSs.QueryGetAllLocations;
using EventManagement.Application.DTOs.ResponseDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseController
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Get()
        {
            GetAllLocationsQueryResponse queryResponse = await _mediator.Send(new GetAllLocationsQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Locations));
        }

        [HttpPost]
        [Authority("Admin")]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommandRequest request)
        {
            CreateLocationCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommandRequest request)
        {
            UpdateLocationCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority("Admin")]
        public async Task<IActionResult> Update(int id)
        {
            DeleteLocationCommandResponse commandResponse = await _mediator.Send(new DeleteLocationCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
