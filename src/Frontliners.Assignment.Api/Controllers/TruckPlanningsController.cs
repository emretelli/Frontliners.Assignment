using Frontliners.Assignment.Domain.Commands.TruckPlanning;
using Frontliners.Assignment.Domain.Queries.TruckPlanning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Frontliners.Assignment.Api.Controllers
{
    [ApiController]
    [Route("api/truckplannings")]
    public class TruckPlanningsController : ControllerBase
    {
        private readonly ISender _sender;

        public TruckPlanningsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AssignDriverToTruck([FromBody] AssignDriverToTruckCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _sender.Send(new GetAllTruckPlanningsRequest());
            return Ok(response);
        }
    }
}
