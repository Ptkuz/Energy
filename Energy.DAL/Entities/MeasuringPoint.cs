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
    /// Точка измерения электроэнергии
    /// </summary>
    public class MeasuringPoint : NamedEntity
    {

        public ConsumptionObject? ConsumptionObject { get; set; }

        public Guid ConsumptionObjectId { get; set; }

        public CounterEnergy CounterEnergy { get; set; }

        public Guid CounterEnergyId { get; set; }

        public CurrentTransformer CurrentTransformer { get; set; }

        public Guid CurrentTransformerId { get; set; }

        public VoltageTransformer VoltageTransformer { get; set; }
        public Guid VoltageTransformerId { get; set; }

        public List<SupplyPoint> SupplyPoints { get; set; } = new();

        public MeasuringPoint()
           : base()
        {

        }

        public MeasuringPoint(string name, Guid consumptionObjectId,
            Guid counterEnergyId, Guid currentTransformerId, Guid voltageTransformerId) 
            : base(name)
        {
            ConsumptionObjectId = consumptionObjectId;
            CounterEnergyId = counterEnergyId;
            CurrentTransformerId = currentTransformerId;
            VoltageTransformerId = voltageTransformerId;
        }
    }
}
