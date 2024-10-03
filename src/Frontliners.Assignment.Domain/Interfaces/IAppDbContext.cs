using Frontliners.Assignment.Domain.Entities;
using MongoDB.Driver;

namespace Frontliners.Assignment.Domain.Interfaces
{
    public interface IAppDbContext
    {
        public IMongoCollection<Driver> Drivers { get; }
        public IMongoCollection<Truck> Trucks { get; }
        public IMongoCollection<TruckPlanning> TruckPlannings { get; }
    }
}
