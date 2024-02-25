using Audit.Domain.Entities;
using MediatR;

namespace Audit.Api.Models.Commands
{
    public record GetLogsByCorrelationIdCommand(Guid CorrelationId) : IRequest<IEnumerable<Log>>
    { }
}
