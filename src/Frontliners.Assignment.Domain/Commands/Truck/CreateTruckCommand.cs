using Frontliners.Assignment.Domain.Dtos;
using Frontliners.Assignment.Domain.Entities;
using MediatR;

namespace Frontliners.Assignment.Domain.Commands.Truck
{
    public record CreateTruckCommand(string LicensePlate, string Color, TruckSize Size) : IRequest<AddedTruckDto> 
    {
    }
}
