using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{
    /// <summary>
    /// Базовая сущность для счетчиков и трансформаторов
    /// </summary>
    public class BaseEnergyEntity : Entity
    {
        /// <summary>
        /// Номер
        /// </summary>
        [Column("Number", Order = 1)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// Дата поверки
        /// </summary>
        [Column("VerificationDate", Order = 2)]
        public DateTime VerificationDate { get; set; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        public BaseEnergyEntity() 
            : base()
        {
            
        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="verificationDate">Дата поверки</param>
        public BaseEnergyEntity(string number, DateTime verificationDate) 
            : base()
        {
            Number = number;
            VerificationDate = verificationDate;
        }
    }
}
