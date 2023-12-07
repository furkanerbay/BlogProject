using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBlogCommand createBlogCommand)
        {
            CreatedBlogResponse result = await Mediator.Send(createBlogCommand);
            return Created(uri: "", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBlogCommand deleteBlogCommand)
        {
            DeletedBlogResponse result = await Mediator.Send(deleteBlogCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogCommand updateBlogCommand)
        {
            UpdatedBlogResponse result = await Mediator.Send(updateBlogCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogQuery getListBlogQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBlogListItemDto> result = await Mediator.Send(getListBlogQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBlogQuery getByIdBlogQuery)
        {
            GetByIdBlogResponse result = await Mediator.Send(getByIdBlogQuery);
            return Ok(result);
        }
    }
}
