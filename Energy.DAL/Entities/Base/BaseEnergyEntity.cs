using System;
using System.Collections.Generic;
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
        public uint Number { get; set; }
        public DateTime VerificationDate { get; set; }

        public BaseEnergyEntity() 
            : base()
        {
            
        }

        public BaseEnergyEntity(uint number, DateTime verificationDate) 
            : base()
        {
            Number = number;
            VerificationDate = verificationDate;
        }
    }
}
