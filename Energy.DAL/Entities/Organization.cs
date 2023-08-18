using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Организация
    /// </summary>
    public class Organization : ObjectEntity
    {

        public List<Subsidiary> Subsidiaries { get; set; } = new();

        public Organization() 
            : base()
        {
            
        }

        public Organization(string name, string address) 
            : base(name, address)
        {

        }
    }
}
