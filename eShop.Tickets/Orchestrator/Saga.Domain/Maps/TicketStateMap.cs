using Saga.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Saga.Domain.Maps
{
    public class TicketStateMap : SagaClassMap<TicketState>
    {
        protected override void Configure(EntityTypeBuilder<TicketState> entity, ModelBuilder model)
        {
            base.Configure(entity, model);

            entity.Property(e => e.CurrentState).HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastUpdatedDate);
        }
    }
}
