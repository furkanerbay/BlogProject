using Application.Features.ApplicationUsers.Commands.Create;
using Application.Features.ApplicationUsers.Commands.Delete;
using Application.Features.ApplicationUsers.Commands.Update;
using Application.Features.ApplicationUsers.Queries.GetById;
using Application.Features.ApplicationUsers.Queries.GetByUserId;
using Application.Features.ApplicationUsers.Queries.GetList;
using Core.Application.Request;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdApplicationUserQuery getByIdApplicationUserQuery)
        {
            GetByIdApplicationUserResponse result = await Mediator.Send(getByIdApplicationUserQuery);
            return Ok(result);
        }

        [HttpGet("ByAuth")]
        public async Task<IActionResult> GetByAuth()
        {
            GetByUserIdApplicationUserQuery getByUserIdCustomerQuery = new() { UserId = getUserIdFromRequest() };
            GetByUserIdApplicationUserResponse result = await Mediator.Send(getByUserIdCustomerQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListApplicationUserQuery getListApplicationUserQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListApplicationUserListItemDto> result = await Mediator.Send(getListApplicationUserQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateApplicationUserCommand createApplicationUserCommand)
        {
            CreatedApplicationUserResponse result = await Mediator.Send(createApplicationUserCommand);
            return Created(uri: "", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationUserCommand updateApplicationUserCommand)
        {
            UpdatedApplicationUserResponse result = await Mediator.Send(updateApplicationUserCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteApplicationUserCommand deleteApplicationUserCommand)
        {
            DeletedApplicationUserResponse result = await Mediator.Send(deleteApplicationUserCommand);
            return Ok(result);
        }
    }
}
