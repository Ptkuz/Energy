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
    /// Объект потребления
    /// </summary>
    public class ConsumptionObject : ObjectEntity
    {

        public Subsidiary? Subsidiary { get; set; }
        public Guid SubsidiaryId { get; set; }


        public List<SupplyPoint> SupplyPoints { get; set; } = new();

        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        public ConsumptionObject() 
            : base()
        {
            
        }

        public ConsumptionObject(Guid id, string name, string address, Guid subsidiaryId)
            : base(id, name, address)
        {
            SubsidiaryId = subsidiaryId;
        }
    }
}
