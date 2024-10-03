using Frontliners.Assignment.Domain.Commands.Driver;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Frontliners.Assignment.Api.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : Controller
    {
        private readonly ISender _sender;

        public DriversController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTruck([FromBody] CreateDriverCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
