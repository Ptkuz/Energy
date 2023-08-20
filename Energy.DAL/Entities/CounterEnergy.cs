using Energy.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Счетчик электрической энергии
    /// </summary>
    public class CounterEnergy : BaseEnergyEntity
    {

        /// <summary>
        /// Тип счетчика
        /// </summary>
        [Column("CounterType", Order = 3)]
        public string CounterType { get; set; } = null!;

        /// <summary>
        /// Навигационное свойство <see cref="Entity.MeasuringPoint"/>
        /// </summary>
        public MeasuringPoint? MeasuringPoint { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CounterEnergy()
           : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="counterType">Тип счетчика</param>
        /// <param name="verificationDate">Дата поверки</param>
        public CounterEnergy(string number, string counterType, DateTime verificationDate)
            : base(number, verificationDate)
        {
            CounterType = counterType;
        }
    }
}
