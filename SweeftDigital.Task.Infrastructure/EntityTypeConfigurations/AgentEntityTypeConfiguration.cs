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
    public class AgentEntityTypeConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable("Agents");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.PersonalNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasOne(p => p.Parent)
                .WithOne(c => c.Child)
                .HasForeignKey<Agent>(p => p.ParentId);
        }
    }
}
