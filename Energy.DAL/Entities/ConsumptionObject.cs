using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
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

        public ConsumptionObject(string name, string address)
            : base(name, address)
        {

        }
    }
}
