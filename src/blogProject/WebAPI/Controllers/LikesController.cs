using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLikeCommand createLikeCommand)
        {
            CreatedLikeResponse result = await Mediator.Send(createLikeCommand);
            return Created(uri: "", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLikeCommand updateLikeCommand)
        {
            UpdatedLikeResponse result = await Mediator.Send(updateLikeCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLikeCommand deleteLikeCommand)
        {
            DeletedLikeResponse result = await Mediator.Send(deleteLikeCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLikeQuery getByIdLikeQuery)
        {
            GetByIdLikeResponse result = await Mediator.Send(getByIdLikeQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLikeQuery getListLikeQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListLikeListItemDto> result = await Mediator.Send(getListLikeQuery);
            return Ok(result);
        }
    }
}
