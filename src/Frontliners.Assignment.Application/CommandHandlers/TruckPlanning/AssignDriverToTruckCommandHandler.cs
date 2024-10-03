using Frontliners.Assignment.Domain.Dtos;
using Frontliners.Assignment.Domain.Commands.TruckPlanning;
using Frontliners.Assignment.Domain.DomainEvents;
using Frontliners.Assignment.Domain.Exceptions;
using Frontliners.Assignment.Domain.Interfaces;
using Entity = Frontliners.Assignment.Domain.Entities;
using Microsoft.Extensions.Logging;
using MediatR;
using MongoDB.Driver;

namespace Frontliners.Assignment.Application.CommandHandlers.TruckPlanning
{
    public class AssignDriverToTruckCommandHandler : IRequestHandler<AssignDriverToTruckCommand, DriverAssignedToTruckDto>
    {
        private readonly IAppDbContext _db;
        private readonly IKafkaProxy _kafkaProxy;
        private readonly ILogger<AssignDriverToTruckCommandHandler> _logger;

        public AssignDriverToTruckCommandHandler(IAppDbContext db, IKafkaProxy kafkaProxy, ILogger<AssignDriverToTruckCommandHandler> logger)
        {
            _db = db;
            _kafkaProxy = kafkaProxy;
            _logger = logger;
        }

        public async Task<DriverAssignedToTruckDto> Handle(AssignDriverToTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = await _db.Trucks.Find(t => t.Id == request.TruckId).FirstOrDefaultAsync();
            if (truck == null)
                throw new BusinessException("Truck not found");

            var driver = await _db.Drivers.Find(t => t.Id == request.DriverId).FirstOrDefaultAsync();
            if (driver == null)
                throw new BusinessException("Driver not found");

            var truckPlanning = MapToTruckPlanning(truck, driver);
            await _db.TruckPlannings.InsertOneAsync(truckPlanning);
            _logger.LogInformation($"driver {request.DriverId} is assigned to truck {request.TruckId}");
            var domainEvent = MapToDomainEvent(truckPlanning);
            _kafkaProxy.Produce("frontliners-assignment-truck-planning", domainEvent);
            return new DriverAssignedToTruckDto(truckPlanning.Id);
        }

        private static Entity.TruckPlanning MapToTruckPlanning(Entity.Truck truck, Entity.Driver driver)
        {
            return new Entity.TruckPlanning
            {
                TruckId = truck.Id,
                TruckLicensePlate = truck.LicensePlate,
                DriverId = driver.Id,
                DriverName = driver.Name
            };
        }

        private static DriverAssignedToTruckDomainEvent MapToDomainEvent(Entity.TruckPlanning truckPlanning)
        {
            return new DriverAssignedToTruckDomainEvent
            {
                TruckPlanningId = truckPlanning.Id,
                TruckId = truckPlanning.TruckId,
                TruckLicensePlate = truckPlanning.TruckLicensePlate,
                DriverId = truckPlanning.DriverId,
                DriverName = truckPlanning.DriverName
            };
        }
    }
}
