using Energy.DAL.Entities.Base;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Объект потребления
    /// </summary>
    public class ConsumptionObject : ObjectEntity
    {

        /// <summary>
        /// Навигационное свойсто <see cref="Entity.Subsidiary"/>
        /// </summary>
        public Subsidiary? Subsidiary { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="Entity.Subsidiary"/>
        /// </summary>
        public Guid SubsidiaryId { get; set; }

        /// <summary>
        /// Навигационное свойсто <see cref="Entity.SupplyPoint"/>
        /// </summary>
        public List<SupplyPoint> SupplyPoints { get; set; } = new();

        /// <summary>
        /// Навигационное свойсто <see cref="Entity.MeasuringPoint"/>
        /// </summary>
        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ConsumptionObject()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Наименование объекта</param>
        /// <param name="address">Адрес</param>
        /// <param name="subsidiaryId">Внешний ключ <see cref="Subsidiary"/></param>
        public ConsumptionObject(string name, string address, Guid subsidiaryId)
            : base(name, address)
        {
            SubsidiaryId = subsidiaryId;
        }
    }
}
