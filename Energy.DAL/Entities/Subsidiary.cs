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
    /// Дочерняя организация
    /// </summary>
    public class Subsidiary : ObjectEntity
    {

        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; } = null!;

        public List<ConsumptionObject> ConsumptionObjects { get; set; } = new();

        public Subsidiary()
           : base()
        {

        }

        public Subsidiary(string name, string address) :
            base(name, address)
        {

        }
    }
}
