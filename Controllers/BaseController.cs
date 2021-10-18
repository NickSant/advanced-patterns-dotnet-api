using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MongoShop2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async Task<IActionResult> ExecuteCommand<TValue>(IRequest<TValue> command)
        {
            var result = await _mediator.Send(command);
            return new OkObjectResult(result);
        }
        protected async Task<IActionResult> ExecuteCommand(IRequest command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}