using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class SupplyPoint : Entity
    {
        public string Name { get; set; }

        public string MaxPower { get; set; }

        public DateTime EndDate { get; set; }

        public SupplyPoint(string name, string maxPower, DateTime endDate)
            : base()
        {
            Name = name;
            MaxPower = maxPower;
            EndDate = endDate;
        }
    }
}
