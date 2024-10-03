using Frontliners.Assignment.Domain.Commands.Truck;
using Frontliners.Assignment.Domain.Dtos;
using Entity = Frontliners.Assignment.Domain.Entities;
using Frontliners.Assignment.Domain.Interfaces;
using MediatR;

namespace Frontliners.Assignment.Application.CommandHandlers.Truck
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, AddedTruckDto>
    {
        private readonly IAppDbContext _db;

        public CreateTruckCommandHandler(IAppDbContext db)
        {
            _db = db;
        }

        public async Task<AddedTruckDto> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = MapToTruck(request);
            await _db.Trucks.InsertOneAsync(truck);
            return new AddedTruckDto(truck.Id);
        }

        private static Entity.Truck MapToTruck(CreateTruckCommand request)
        {
            return new Entity.Truck
            {
                Color = request.Color,
                LicensePlate = request.LicensePlate,
                Size = request.Size
            };
        }
    }
}
