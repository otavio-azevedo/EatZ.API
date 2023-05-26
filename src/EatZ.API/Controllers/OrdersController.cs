using EatZ.API.Models.Orders;
using EatZ.API.Models.Orders.Reponses;
using EatZ.Domain.Commands.Orders.Create;
using EatZ.Domain.Commands.Orders.List;
using EatZ.Domain.Commands.Orders.Update;
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
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Consumer)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = Roles.Company)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListOrdersByCurrentUserResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> ListOrdersByCurrentUserAsync()
        {
            var result = await _mediator.Send(new ListOrdersByCurrentUserCommand());
            var mappedResult = OrdersMappers.Map(result);
            
            return Ok(mappedResult);
        }
    }
}
