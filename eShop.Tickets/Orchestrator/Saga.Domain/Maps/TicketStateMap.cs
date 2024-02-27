using Saga.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Saga.Domain.Maps
{
    public class TicketStateMap : SagaClassMap<TicketOrderState>
    {
        protected override void Configure(EntityTypeBuilder<TicketOrderState> entity, ModelBuilder model)
        {
            base.Configure(entity, model);

            entity.Property(e => e.CurrentState).HasMaxLength(50).IsRequired();
            entity.Property(e => e.TheaterId);
            entity.Property(e => e.MovieId);
            entity.Property(e => e.Showtime);
            entity.Property(e => e.Seats).HasColumnType("xml");
            entity.Property(e => e.LastUpdatedDate);
            entity.Property(e => e.CreationDate);
        }
    }
}
