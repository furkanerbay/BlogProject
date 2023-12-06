using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreatedCategoryResponse result = await Mediator.Send(createCategoryCommand);
            return Created(uri: "", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdatedCategoryResponse result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeletedCategoryResponse result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCategoryListItemDto> result = await Mediator.Send(getListCategoryQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCatgoryQuery)
        {
            GetByIdCategoryResponse result = await Mediator.Send(getByIdCatgoryQuery);
            return Ok(result);
        }
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsert([FromBody] CreateBulkCategoryCommand bulkCategoryCommand)
        {
            List<CreatedCategoryResponse> result = await Mediator.Send(bulkCategoryCommand);
            return Created(uri: "", result);
        }
    }
}