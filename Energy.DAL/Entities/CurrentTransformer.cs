using Energy.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{
    /// <summary>
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformer : Transformer
    {

        /// <summary>
        /// КТТ (коэффициент трансформации)
        /// </summary>
        [Column("CTC", Order = 4)]
        public double CTC { get; set; }

        /// <summary>
        /// Навигационное свойство <see cref="Entity.MeasuringPoint"/>
        /// </summary>
        public MeasuringPoint? MeasuringPoint { get; set; }

        /// <summary>
        /// Конструтор по умолчанию
        /// </summary>
        public CurrentTransformer()
           : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="transformerType">Тип трансформатора</param>
        /// <param name="verificationDate">Дата поверки</param>
        /// <param name="cTC">КТТ (коэффициент трансформации)</param>
        public CurrentTransformer(string number, string transformerType, DateTime verificationDate, double cTC)
            : base(number, verificationDate, transformerType)
        {
            CTC = cTC;
        }
    }
}
