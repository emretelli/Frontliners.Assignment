using Frontliners.Assignment.Domain.Dtos;
using MediatR;

namespace Frontliners.Assignment.Domain.Commands.TruckPlanning
{
    public record AssignDriverToTruckCommand(string DriverId, string TruckId) : IRequest<DriverAssignedToTruckDto>
    {
    }
}
