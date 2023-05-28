using EatZ.Domain.Commands.Reviews.Create;
using EatZ.Domain.Commands.Reviews.Delete;
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
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Consumer)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateReviewAsync([FromBody] CreateReviewCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotificationModel), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> DeleteReviewAsync(string id)
        {
            await _mediator.Send(new DeleteReviewCommand(id));
            return Ok();
        }
    }
}
