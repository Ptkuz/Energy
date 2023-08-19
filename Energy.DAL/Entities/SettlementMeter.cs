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
    /// Расчетный прибор учета
    /// </summary>
    public class SettlementMeter : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid SupplyPointId { get; set; }

        public Guid MeasuringPointId { get; set; }

        public SettlementMeter() 
            : base()
        {
            
        }

        public SettlementMeter(Guid supplyPointId, Guid measuringPointId,
            DateTime startDate, DateTime endDate)
            : base() 
        {
            SupplyPointId = supplyPointId;
            MeasuringPointId = measuringPointId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
