using EatZ.API.Models.Location;
using EatZ.API.Models.Location.Responses;
using EatZ.Domain.Commands.Location.GetCitiesByState;
using EatZ.Domain.Commands.Location.GetStatesByCountry;
using EatZ.Domain.Commands.Location.SearchCities;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EatZ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SearchCityResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> SearchCitiesAsync([FromQuery] SearchCitiesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(LocationMappers.Map(result));
        }

        [HttpGet("states")]
        [ProducesResponseType(typeof(IEnumerable<GetStatesByCountryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetStatesByCountryAsync([FromQuery] GetStatesByCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(LocationMappers.Map(result));
        }

        [HttpGet("cities")]
        [ProducesResponseType(typeof(IEnumerable<GetCitiesByStateResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetCitiesByStateAsync([FromQuery] GetCitiesByStateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(LocationMappers.MapCities(result));
        }
    }
}
