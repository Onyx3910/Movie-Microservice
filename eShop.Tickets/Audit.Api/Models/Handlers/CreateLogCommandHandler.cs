using Audit.Api.Models.Commands;
using Audit.Domain.AggregatesModel.AuditLogAggregate;
using Audit.Domain.Entities;
using MediatR;

namespace Audit.Api.Models.Handlers
{
    public class CreateLogCommandHandler(ILogRepository logRepository, 
                                         ILogger<CreateLogCommandHandler> logger) : IRequestHandler<CreateLogCommand, bool>
    {
        private readonly ILogRepository _logRepository = logRepository;
        private readonly ILogger<CreateLogCommandHandler> _logger = logger;

        public async Task<bool> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            var log = new Log
            {
                CorrelationId = request.CorrelationId,
                Message = request.Message,
                StatusId = (int)request.Status,
                Timestamp = DateTime.Now,
                CreatedBy = nameof(CreateLogCommandHandler)
            };

            log = _logRepository.Add(log);

            await _logRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return !log.IsTransient();
        }
    }
}
