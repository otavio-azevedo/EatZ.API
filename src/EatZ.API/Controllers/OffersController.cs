using System.Net;
using EatZ.API.Models.Offers;
using EatZ.API.Models.Offers.Responses;
using EatZ.Domain.Commands.Offers.Create;
using EatZ.Domain.Commands.Offers.Delete;
using EatZ.Domain.Commands.Offers.Edit;
using EatZ.Domain.Commands.Offers.List;
using EatZ.Domain.Commands.Offers.Search;
using EatZ.Domain.Entities;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EatZ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateOfferAsync([FromBody] CreateOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> DeleteOfferAsync(string id)
        {
            await _mediator.Send(new DeleteOfferCommand(id));
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> EditOfferAsync([FromBody] EditOfferCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("city")]
        [ProducesResponseType(typeof(IEnumerable<SearchOffersByCityResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> SearchOffersByCityAsync([FromQuery] SearchOffersByCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(OffersMappers.Map(result));
        }

        [HttpGet("store")]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType(typeof(IEnumerable<StoreOffers>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> ListOffersByStoreAsync([FromQuery] ListOffersByStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}