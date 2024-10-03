using Frontliners.Assignment.Domain.Dtos;
using MediatR;

namespace Frontliners.Assignment.Domain.Commands.Driver
{
    public record CreateDriverCommand(string Name) : IRequest<AddedDriverDto>
    {
    }
}
