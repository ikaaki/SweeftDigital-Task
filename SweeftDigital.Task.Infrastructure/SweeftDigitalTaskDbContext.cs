using Microsoft.EntityFrameworkCore;
using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Infrastructure
{
    public class SweeftDigitalTaskDbContext : DbContext
    {
        public SweeftDigitalTaskDbContext(DbContextOptions<SweeftDigitalTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgentEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
