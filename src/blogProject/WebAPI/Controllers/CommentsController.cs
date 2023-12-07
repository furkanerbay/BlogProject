using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
        {
            CreatedCommentResponse result = await Mediator.Send(createCommentCommand);
            return Created(uri: "", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCommentCommand deleteCommentCommand)
        {
            DeletedCommentResponse result = await Mediator.Send(deleteCommentCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            UpdatedCommentResponse result = await Mediator.Send(updateCommentCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCommentListItemDto> result = await Mediator.Send(getListCommentQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentQuery getByIdCommentQuery)
        {
            GetByIdCommentResponse result = await Mediator.Send(getByIdCommentQuery);
            return Ok(result);
        }
    }
}
