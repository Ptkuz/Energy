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

        public int MaxPower { get; set; }

        public ConsumptionObject? ConsumptionObject { get; set; }

        public Guid ConsumptionObjectId { get; set; }   


        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        public SupplyPoint()
           : base()
        {

        }

        public SupplyPoint(Guid id, string name, int maxPower, Guid consumptionObjectId) 
            : base(id, name)
        {
            MaxPower = maxPower;
            ConsumptionObjectId = consumptionObjectId;
        }
    }
}
