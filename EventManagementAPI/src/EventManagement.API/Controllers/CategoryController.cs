using EventManagement.API.Extensions.Attributes;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandDeleteCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory;
using EventManagement.Application.DTOs.ResponseDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authority("Standard", "Admin")]
        public async Task<IActionResult> Get()
        {
            GetAllCategoriesQueryResponse queryResponse = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, queryResponse.Categories));
        }

        [HttpPost]
        [Authority("Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpPut]
        [Authority("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse commandResponse = await _mediator.Send(request);
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authority("Admin")]
        public async Task<IActionResult> Update(int id)
        {
            DeleteCategoryCommandResponse commandResponse = await _mediator.Send(new DeleteCategoryCommandRequest(id));
            if (commandResponse.IsSuccessful == false) return CreateActionResult(new APIResponseDTO(HttpStatusCode.BadRequest, commandResponse.Message));

            return CreateActionResult(new APIResponseDTO(HttpStatusCode.OK, commandResponse.Message));
        }
    }
}
