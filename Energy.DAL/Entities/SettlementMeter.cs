using Energy.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Energy.DAL.Entities
{
    /// <summary>
    /// Расчетный прибор учета
    /// </summary>
    public class SettlementMeter : Entity
    {

        /// <summary>
        /// Дата начала измеренния
        /// </summary>
        [Column("StartDate", Order = 1)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата завершения измерения
        /// </summary>
        [Column("EndDate", Order = 2)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="SupplyPoint"/>
        /// </summary>
        public Guid SupplyPointId { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="MeasuringPoint"/>
        /// </summary>
        public Guid MeasuringPointId { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SettlementMeter()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="startDate">Дата начала измерения</param>
        /// <param name="endDate">Дата завершения измерения</param>
        /// <param name="supplyPointId">Внешний ключ <see cref="SupplyPoint"/></param>
        /// <param name="measuringPointId">Внешний ключ <see cref="MeasuringPoint"/></param>
        public SettlementMeter(DateTime startDate, DateTime endDate,
            Guid supplyPointId, Guid measuringPointId)
            : base()
        {
            SupplyPointId = supplyPointId;
            MeasuringPointId = measuringPointId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
