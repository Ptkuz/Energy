using Energy.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class SupplyPoint : NamedEntity
    {

        /// <summary>
        /// Максимальная мощность, КВт
        /// </summary>
        [Column("MaxPower", Order = 2)]
        public int MaxPower { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="Entity.ConsumptionObject"/>
        /// </summary>
        public ConsumptionObject? ConsumptionObject { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="Entity.ConsumptionObject"/>
        /// </summary>
        public Guid ConsumptionObjectId { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="Entity.MeasuringPoints"/>
        /// </summary>
        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SupplyPoint()
           : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Наименование точки поставки</param>
        /// <param name="maxPower">Максимальная мощность, кВт</param>
        /// <param name="consumptionObjectId">Навигационное свойство <see cref="Entity.MeasuringPoints"/></param>
        public SupplyPoint(string name, int maxPower, Guid consumptionObjectId)
            : base(name)
        {
            MaxPower = maxPower;
            ConsumptionObjectId = consumptionObjectId;
        }
    }
}
