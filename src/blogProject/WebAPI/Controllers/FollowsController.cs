using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using Application.Features.Follows.Commands.Create;
using Application.Features.Follows.Commands.Update;
using Application.Features.Follows.Queries.GetById;
using Application.Features.Follows.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFollowCommand createFollowCommand)
        {
            CreatedFollowResponse result = await Mediator.Send(createFollowCommand);
            return Created(uri: "", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFollowCommand updateFollowCommand)
        {
            UpdatedFollowResponse result = await Mediator.Send(updateFollowCommand);
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
            GetListFollowQuery getListFollowQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListFollowListItemDto> result = await Mediator.Send(getListFollowQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFollowQuery getByIdFollowQuery)
        {
            GetByIdFollowResponse result = await Mediator.Send(getByIdFollowQuery);
            return Ok(result);
        }
    }
}