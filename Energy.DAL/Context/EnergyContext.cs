
using Energy.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Context
{
    public class EnergyContext : DbContext
    {

        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; } = null!;
        public DbSet<CounterEnergy> CounterEnergies { get; set; } = null!;  
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; } = null!;
        public DbSet<MeasuringPoint> MeasuringPoints { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<SettlementMeter> SettlementMeters { get; set; } = null!;
        public DbSet<Subsidiary> Subsidiaries { get; set; } = null!;
        public DbSet<SupplyPoint> SupplyPoints { get; set; } = null!;
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; } = null!;


        public EnergyContext() 
        {
            
        }

        public EnergyContext(DbContextOptions<EnergyContext> dbContext)
            : base(dbContext)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Один ко многим между Organization и Subsidiary
            modelBuilder.Entity<Subsidiary>()
                .HasOne(x => x.Organization)
                .WithMany(x => x.Subsidiaries)
                .OnDelete(DeleteBehavior.Cascade);

            // Один ко многим Subsidiary и ConsumptionObject
            modelBuilder.Entity<ConsumptionObject>()
                .HasOne(x => x.Subsidiary)
                .WithMany(x => x.ConsumptionObjects)
                .OnDelete(DeleteBehavior.Cascade);

            // Один ко многим ConsumptionObject и MeasuringPoint
            modelBuilder.Entity<MeasuringPoint>()
                .HasOne(x => x.ConsumptionObject)
                .WithMany(x => x.MeasuringPoints)
                .OnDelete(DeleteBehavior.Cascade);

            // Один ко многим ConsumptionObject и SupplyPoint
            modelBuilder.Entity<SupplyPoint>()
                .HasOne(x => x.ConsumptionObject)
                .WithMany(x => x.SupplyPoints)
                .OnDelete(DeleteBehavior.Cascade);

            // Один к одному MeasuringPoint и CounterEnergy
            modelBuilder.Entity<MeasuringPoint>()
                .HasOne(c => c.CounterEnergy)
                .WithOne(m => m.MeasuringPoint)
                .OnDelete(DeleteBehavior.Cascade);

            // Один к одному MeasuringPoint и CurrentTransformer
            modelBuilder.Entity<MeasuringPoint>()
                .HasOne(c => c.CurrentTransformer)
                .WithOne(m => m.MeasuringPoint)
                .OnDelete(DeleteBehavior.Cascade);

            // Один к одному MeasuringPoint и VoltageTransformer
            modelBuilder.Entity<MeasuringPoint>()
                .HasOne(c => c.VoltageTransformer)
                .WithOne(m => m.MeasuringPoint)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder
                .Entity<MeasuringPoint>()
                .HasMany(s => s.SupplyPoints)
                .WithMany(m => m.MeasuringPoints)
                .UsingEntity<SettlementMeter>(
                    sm => sm.HasOne<SupplyPoint>().WithMany().HasForeignKey(k => k.SupplyPointId).OnDelete(DeleteBehavior.NoAction),
                    sm => sm.HasOne<MeasuringPoint>().WithMany().HasForeignKey(k => k.MeasuringPointId).OnDelete(DeleteBehavior.NoAction),
                    sm =>
                    {
                        sm.Property(sd => sd.StartDate).HasDefaultValue(DateTime.Now);
                        sm.Property(ed => ed.EndDate).HasDefaultValue(DateTime.Now);
                    }
                );

            ContextInitializer contextInitializer = new ContextInitializer();
            modelBuilder.Entity<Organization>().HasData(contextInitializer.Organizations);
            modelBuilder.Entity<Subsidiary>().HasData(contextInitializer.Subsidiaries);
            modelBuilder.Entity<ConsumptionObject>().HasData(contextInitializer.ConsumptionObjects);
            modelBuilder.Entity<CounterEnergy>().HasData(contextInitializer.CounterEnergies);
            modelBuilder.Entity<CurrentTransformer>().HasData(contextInitializer.CurrentTransformers);
            modelBuilder.Entity<VoltageTransformer>().HasData(contextInitializer.VoltageTransformers);
            modelBuilder.Entity<MeasuringPoint>().HasData(contextInitializer.MeasuringPoints);
            modelBuilder.Entity<SupplyPoint>().HasData(contextInitializer.SupplyPoints);
            modelBuilder.Entity<SettlementMeter>().HasData(contextInitializer.SettlementMeters);
        }
    }
}
