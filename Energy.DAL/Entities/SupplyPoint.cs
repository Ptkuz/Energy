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
    /// Точка поставки электроэнергии
    /// </summary>
    public class SupplyPoint : NamedEntity
    {

        public string MaxPower { get; set; }

        [ForeignKey("ConsumptionObjectId")]
        public ConsumptionObject ConsumptionObject { get; set; }


        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        public SupplyPoint()
           : base()
        {

        }

        public SupplyPoint(string name, string maxPower, DateTime endDate) 
            : base(name)
        {
            MaxPower = maxPower;
        }
    }
}
