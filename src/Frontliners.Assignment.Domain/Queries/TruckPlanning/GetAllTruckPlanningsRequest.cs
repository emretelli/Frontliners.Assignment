using MediatR;

namespace Frontliners.Assignment.Domain.Queries.TruckPlanning
{
    public record GetAllTruckPlanningsRequest : IRequest<IEnumerable<Entities.TruckPlanning>>
    {
    }
}
