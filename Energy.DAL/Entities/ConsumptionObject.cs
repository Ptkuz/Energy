using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class ConsumptionObject : Entity
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public ConsumptionObject(string name, string address)
            : base()
        {
            
        }
    }
}
