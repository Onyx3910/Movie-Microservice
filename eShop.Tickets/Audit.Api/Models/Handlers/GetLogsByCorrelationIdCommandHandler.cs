using Audit.Api.Models.Commands;
using Audit.Domain.AggregatesModel.AuditLogAggregate;
using Audit.Domain.Entities;
using MediatR;

namespace Audit.Api.Models.Handlers
{
    public class GetLogsByCorrelationIdCommandHandler(ILogRepository logRepository, 
                                                      ILogger<GetLogsByCorrelationIdCommandHandler> logger) : IRequestHandler<GetLogsByCorrelationIdCommand, IEnumerable<Log>>
    {
        public ILogRepository _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        public ILogger<GetLogsByCorrelationIdCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<IEnumerable<Log>> Handle(GetLogsByCorrelationIdCommand request, CancellationToken cancellationToken)
        {
            var logs = await _logRepository.FindAsync(request.CorrelationId);

            return logs;
        }
    }
}
