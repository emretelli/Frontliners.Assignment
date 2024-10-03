using Frontliners.Assignment.Domain.Commands.Truck;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Frontliners.Assignment.Api.Controllers
{
    [ApiController]
    [Route("api/trucks")]
    public class TrucksController : Controller
    {
        private readonly ISender _sender;

        public TrucksController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTruck([FromBody] CreateTruckCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
