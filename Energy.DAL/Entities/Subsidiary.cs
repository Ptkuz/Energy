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

        public Organization? Organization { get; set; }

        public Guid OrganizationId { get; set; }

        public List<ConsumptionObject> ConsumptionObjects { get; set; } = new();

        public Subsidiary()
           : base()
        {

        }

        public Subsidiary(Guid id, string name, string address, Guid organizationId) :
            base(id, name, address)
        {
            OrganizationId = organizationId;
        }
    }
}
