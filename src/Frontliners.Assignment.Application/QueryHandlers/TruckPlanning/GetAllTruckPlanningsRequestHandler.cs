using Entities = Frontliners.Assignment.Domain.Entities;
using Frontliners.Assignment.Domain.Queries.TruckPlanning;
using MediatR;
using MongoDB.Driver;
using Frontliners.Assignment.Domain.Interfaces;

namespace Frontliners.Assignment.Application.QueryHandlers.TruckPlanning
{
    public class GetAllTruckPlanningsRequestHandler : IRequestHandler<GetAllTruckPlanningsRequest, IEnumerable<Entities.TruckPlanning>>
    {
        private readonly IAppDbContext _db;

        public GetAllTruckPlanningsRequestHandler(IAppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Entities.TruckPlanning>> Handle(GetAllTruckPlanningsRequest request, CancellationToken cancellationToken)
        {
            return await _db.TruckPlannings.Find(_ => true).ToListAsync();
        }
    }
}
