using Energy.DAL.Entities;
using Energy.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Energy.DAL.Context
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class EnergyContext : DbContext
    {

        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<EnergyContext> _logger;

        /// <summary>
        /// Объекты потребления DbSet<see cref="ConsumptionObject"/>>
        /// </summary>
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; } = null!;

        /// <summary>
        /// Счетчики электрической энергии DbSet<see cref="CounterEnergy"/>>
        /// </summary>
        public DbSet<CounterEnergy> CounterEnergies { get; set; } = null!;

        /// <summary>
        /// Трансформаторы тока DbSet<see cref="CurrentTransformer"/>>
        /// </summary>
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; } = null!;

        /// <summary>
        /// Точки измерения электроэнергии DbSet<see cref="MeasuringPoint"/>>
        /// </summary>
        public DbSet<MeasuringPoint> MeasuringPoints { get; set; } = null!;

        /// <summary>
        /// Организации DbSet<see cref="Organization"/>>
        /// </summary>
        public DbSet<Organization> Organizations { get; set; } = null!;

        /// <summary>
        /// Расчетные приборы учета DbSet<see cref="SettlementMeter"/>>
        /// </summary>
        public DbSet<SettlementMeter> SettlementMeters { get; set; } = null!;

        /// <summary>
        /// Дочернии организации DbSet<see cref="Subsidiary"/>>
        /// </summary>
        public DbSet<Subsidiary> Subsidiaries { get; set; } = null!;

        /// <summary>
        /// Точки поставки электроэнергии DbSet<see cref="SupplyPoint"/>>
        /// </summary>
        public DbSet<SupplyPoint> SupplyPoints { get; set; } = null!;

        /// <summary>
        /// Трансформаторы напряжения DbSet<see cref="VoltageTransformer"/>>
        /// </summary>
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; } = null!;


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EnergyContext()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="dbContext"></param>
        public EnergyContext(DbContextOptions<EnergyContext> dbContext, ILogger<EnergyContext> logger)
            : base(dbContext)
        {
            _logger = logger;

            CheckEFConnection();

            Database.EnsureDeleted();
            Database.EnsureCreated();

            _logger.LogDebug("База данных создана и проинициализированна");
        }

        /// <summary>
        /// Конфигурирует связи и модели
        /// </summary>
        /// <param name="modelBuilder">API для настройки</param>
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

            // Многие ко многим между MeasuringPoint и SupplyPoint через SettlementMeter
            modelBuilder
                .Entity<MeasuringPoint>()
                .HasMany(s => s.SupplyPoints)
                .WithMany(m => m.MeasuringPoints)
                .UsingEntity<SettlementMeter>(
                    sm => sm.HasOne<SupplyPoint>().WithMany().HasForeignKey(k => k.SupplyPointId).OnDelete(DeleteBehavior.NoAction),
                    sm => sm.HasOne<MeasuringPoint>().WithMany().HasForeignKey(k => k.MeasuringPointId).OnDelete(DeleteBehavior.NoAction),
                    sm =>
                    {
                        sm.Property(sd => sd.StartDate).HasDefaultValue(default);
                        sm.Property(ed => ed.EndDate).HasDefaultValue(default);
                    }
                );


            // Инициализация базы начальными значениями
            modelBuilder.Entity<Organization>().HasData(ContextInitializer.Organizations);
            modelBuilder.Entity<Subsidiary>().HasData(ContextInitializer.Subsidiaries);
            modelBuilder.Entity<ConsumptionObject>().HasData(ContextInitializer.ConsumptionObjects);
            modelBuilder.Entity<CounterEnergy>().HasData(ContextInitializer.CounterEnergies);
            modelBuilder.Entity<CurrentTransformer>().HasData(ContextInitializer.CurrentTransformers);
            modelBuilder.Entity<VoltageTransformer>().HasData(ContextInitializer.VoltageTransformers);
            modelBuilder.Entity<MeasuringPoint>().HasData(ContextInitializer.MeasuringPoints);
            modelBuilder.Entity<SupplyPoint>().HasData(ContextInitializer.SupplyPoints);
            modelBuilder.Entity<SettlementMeter>().HasData(ContextInitializer.SettlementMeters);
        }

        private void CheckEFConnection() 
        {
            if (!Database.CanConnect())
            {
                string message = "Не удалось установить соединение с БД";
                var exception = new EFConnectionException(message);

                _logger.LogError(exception, message);
                throw new EFConnectionException(message);
            }
        }
    }
}
