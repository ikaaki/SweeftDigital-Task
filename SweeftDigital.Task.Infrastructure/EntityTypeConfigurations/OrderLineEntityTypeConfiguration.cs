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
    public class OrderLineEntityTypeConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLines");

            builder.HasKey(u => u.Id);

            builder.HasOne(p => p.Order)
                .WithMany(c => c.OrderLines)
                .HasForeignKey(p => p.OrderId)
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(c => c.OrderLines)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();
        }
    }
}
