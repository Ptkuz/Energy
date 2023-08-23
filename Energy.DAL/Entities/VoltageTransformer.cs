using Energy.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Трансформатор напряжения 
    /// </summary>
    public class VoltageTransformer : Transformer
    {

        /// <summary>
        /// КТН (Коэффициент трансформации)
        /// </summary>
        [Column("CTV", Order = 4)]
        public double CTV { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="Entity.MeasuringPoint"/>
        /// </summary>
        public MeasuringPoint? MeasuringPoint { get; set; }


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public VoltageTransformer()
           : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="verificationDate">Дата поверки</param>
        /// <param name="transformerType">Тип трансформатора</param>
        /// <param name="cTV">КТН (Коэффициент трансформации)</param>
        public VoltageTransformer(string number, string transformerType, DateTime verificationDate, double cTV)
            : base(number, verificationDate, transformerType)
        {
            CTV = cTV;
        }
    }
}
