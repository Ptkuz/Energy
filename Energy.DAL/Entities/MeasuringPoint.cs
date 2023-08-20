using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class MeasuringPoint : NamedEntity
    {

        /// <summary>
        /// Навигационное свойство <see cref="ConsumptionObject"/>
        /// </summary>
        public ConsumptionObject? ConsumptionObject { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="ConsumptionObject"/>
        /// </summary>
        public Guid ConsumptionObjectId { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="CounterEnergy"/>
        /// </summary>
        public CounterEnergy? CounterEnergy { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="CounterEnergy"/>
        /// </summary>
        public Guid CounterEnergyId { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="CurrentTransformer"/>
        /// </summary>
        public CurrentTransformer? CurrentTransformer { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="CurrentTransformer"/>
        /// </summary>
        public Guid CurrentTransformerId { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="VoltageTransformer"/>
        /// </summary>
        public VoltageTransformer? VoltageTransformer { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="VoltageTransformer"/>
        /// </summary>
        public Guid VoltageTransformerId { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="SupplyPoint"/>
        /// </summary>
        public List<SupplyPoint> SupplyPoints { get; set; } = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MeasuringPoint()
           : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="consumptionObjectId">Внешний ключ <see cref="ConsumptionObject"/></param>
        /// <param name="counterEnergyId">Внешний ключ <see cref="CounterEnergy"/></param>
        /// <param name="currentTransformerId">Внешний ключ <see cref="CurrentTransformerId"/></param>
        /// <param name="voltageTransformerId">Внешний ключ <see cref="VoltageTransformerId"/></param>
        public MeasuringPoint(string name, Guid consumptionObjectId,
            Guid counterEnergyId, Guid currentTransformerId, Guid voltageTransformerId) 
            : base(name)
        {
            ConsumptionObjectId = consumptionObjectId;
            CounterEnergyId = counterEnergyId;
            CurrentTransformerId = currentTransformerId;
            VoltageTransformerId = voltageTransformerId;
        }
    }
}
