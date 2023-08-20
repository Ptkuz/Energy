using System.ComponentModel.DataAnnotations.Schema;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Базовый трансформатор
    /// </summary>
    public class Transformer : BaseEnergyEntity
    {

        /// <summary>
        /// Тип трансформатора
        /// </summary>
        [Column("TransformerType", Order = 3)]
        public string TransformerType { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Transformer()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="verificationDate">Дата поверки</param>
        /// <param name="transformerType">Тип трансформатора</param>
        public Transformer(string number, DateTime verificationDate, string transformerType)
            : base(number, verificationDate)
        {
            TransformerType = transformerType;
        }

    }
}
