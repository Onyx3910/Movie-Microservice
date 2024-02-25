﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audit.Infrastructure.Configurations
{
    public partial class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> entity)
        {
            entity.ToTable("Log");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Message)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.Logs)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Status");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Log> entity);
    }
}
