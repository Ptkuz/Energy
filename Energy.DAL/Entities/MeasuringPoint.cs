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

        [ForeignKey("ConsumptionObjectId")]
        public ConsumptionObject ConsumptionObject { get; set; } = null!;

        [ForeignKey("CounterEnergyId")]
        public CounterEnergy CounterEnergy { get; set; } = null!;

        [ForeignKey("CurrentTransformerId")]
        public CurrentTransformer CurrentTransformer { get; set; } = null!;

        [ForeignKey("VoltageTransformerId")]
        public VoltageTransformer VoltageTransformer { get; set; } = null!;

        public List<SupplyPoint> SupplyPoints { get; set; } = new();

        public MeasuringPoint()
           : base()
        {

        }

        public MeasuringPoint(string name, DateTime startDate) 
            : base(name)
        {
        }
    }
}
