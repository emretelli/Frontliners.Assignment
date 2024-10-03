using Frontliners.Assignment.Domain.Entities;
using Frontliners.Assignment.Domain.Interfaces;
using Frontliners.Assignment.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace Frontliners.Assignment.Infrastructure.Persistence
{
    public class AppDbContext : IAppDbContext
    {
        private readonly FrontlinersAssignmentDatabaseSettings _dbSettings;
        private readonly IMongoDatabase _database;

        public AppDbContext(IOptions<FrontlinersAssignmentDatabaseSettings> dbSettingsOptions,
            IMongoClient mongoClient)
        {
            _dbSettings = dbSettingsOptions.Value;
            _database = mongoClient.GetDatabase(_dbSettings.DatabaseName);
        }

        public IMongoCollection<Driver> Drivers => _database.GetCollection<Driver>(_dbSettings.DriverCollectionName);
        public IMongoCollection<Truck> Trucks => _database.GetCollection<Truck>(_dbSettings.TruckCollectionName);
        public IMongoCollection<TruckPlanning> TruckPlannings => _database.GetCollection<TruckPlanning>(_dbSettings.TruckPlanningCollectionName);
    }
}
