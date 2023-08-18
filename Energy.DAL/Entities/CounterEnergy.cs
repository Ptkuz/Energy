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
    /// Счетчик электрической энергии
    /// </summary>
    public class CounterEnergy : BaseEnergyEntity
    {
        public string CounterType { get; set; } = null!;

        [ForeignKey("MeasuringPointId")]
        public MeasuringPoint MeasuringPoint { get; set; } = null!;

        public CounterEnergy()
           : base()
        {

        }

        public CounterEnergy(uint number, DateTime verificationDate, string counterType) 
            : base(number, verificationDate)
        {
            CounterType = counterType;  
        }
    }
}
