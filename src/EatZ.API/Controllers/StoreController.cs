using EatZ.API.Models.Stores;
using EatZ.API.Models.Stores.Responses;
using EatZ.Domain.Commands.Stores.Create;
using EatZ.Domain.Commands.Stores.Delete;
using EatZ.Domain.Commands.Stores.Get;
using EatZ.Domain.Commands.Stores.GetStoreByUserId;
using EatZ.Domain.Commands.Stores.Search;
using EatZ.Domain.Entities;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EatZ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType(typeof(Store), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetStoreAsync(string id)
        {
            var result = await _mediator.Send(new GetStoreCommand(id));
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType(typeof(Store), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetStoreByCurrentUserAsync()
        {
            var result = await _mediator.Send(new GetStoreByAdminIdCommand());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> DeleteStoreAsync(string id)
        {
            await _mediator.Send(new DeleteStoreCommand(id));
            return Ok();
        }

        [HttpGet("city")]
        [ProducesResponseType(typeof(IEnumerable<SearchStoresByCityResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> SearchStoresByCityAsync([FromQuery] SearchStoresByCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(StoresMappers.Map(result));
        }
    }
}