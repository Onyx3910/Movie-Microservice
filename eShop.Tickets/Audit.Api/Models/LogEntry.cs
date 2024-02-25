using Audit.Api.Models.Enums;

namespace Audit.Api.Models
{
    public record LogEntry(Guid CorrelationId,
                           string Status,
                           string Message);
}
