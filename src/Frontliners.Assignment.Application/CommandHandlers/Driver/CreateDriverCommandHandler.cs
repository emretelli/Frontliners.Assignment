using Frontliners.Assignment.Domain.Dtos;
using Entity = Frontliners.Assignment.Domain.Entities;
using MediatR;
using Frontliners.Assignment.Domain.Commands.Driver;
using Frontliners.Assignment.Domain.Interfaces;

namespace Frontliners.Assignment.Application.CommandHandlers.Driver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, AddedDriverDto>
    {
        private readonly IAppDbContext _db;

        public CreateDriverCommandHandler(IAppDbContext db)
        {
            _db = db;
        }

        public async Task<AddedDriverDto> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = MapToDriver(request);
            await _db.Drivers.InsertOneAsync(driver);
            return new AddedDriverDto(driver.Id);
        }

        private static Entity.Driver MapToDriver(CreateDriverCommand request)
        {
            return new Entity.Driver
            {
                Name = request.Name
            };
        }
    }
}
