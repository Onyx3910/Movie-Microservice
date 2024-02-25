using Audit.Domain.AggregatesModel.AuditLogAggregate;
using Audit.Domain.Base;
using Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Audit.Infrastructure.Repositories
{
    public class AuditLogRepository(AuditContext context) : ILogRepository
    {
        public AuditContext _context = context ?? throw new ArgumentNullException(nameof(context));
        public IUnitOfWork UnitOfWork => _context;

        public Log Add(Log log)
        {
            if(log.IsTransient())
            {
                return _context.Logs.Add(log).Entity;
            }

            return log;
        }

        public Log Update(Log log)
        {
            return _context.Logs.Update(log).Entity;
        }

        public async Task<IEnumerable<Log>> FindAsync(Guid correlationId)
        {
            var logs = await _context.Logs.Where(x => x.CorrelationId == correlationId)
                                          .ToListAsync();

            return logs;
        }
    }
}
