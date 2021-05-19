using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweeftDigital.Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure.EntityTypeConfigurations
{
    class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(u => u.Id);

            builder.HasOne(p => p.Agent)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.AgentId)
                .IsRequired();
        }
    }
}
