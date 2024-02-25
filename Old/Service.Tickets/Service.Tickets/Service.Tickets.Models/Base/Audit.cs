using System;

namespace Service.Tickets.Models.Base
{
    public abstract class Audit
    {
        public Guid ContextId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime CreatedDate => DateTime.Now;
    }
}
