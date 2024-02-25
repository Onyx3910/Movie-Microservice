using Audit.Api.Models.Enums;
using MediatR;

namespace Audit.Api.Models.Commands
{
    public record CreateLogCommand(
        Status Status,
        Guid CorrelationId,
        string Message) : IRequest<bool>
    { }
}
