using Audit.Domain.Base;
using Audit.Domain.Entities;

namespace Audit.Domain.AggregatesModel.AuditLogAggregate
{
    public interface ILogRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Log Add(Log log);
        Log Update(Log log);
        Task<IEnumerable<Log>> FindAsync(Guid correlationId);
    }
}
