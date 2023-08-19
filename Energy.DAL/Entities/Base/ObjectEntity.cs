using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Базовая организация
    /// </summary>
    public class ObjectEntity : NamedEntity
    {

        public string Address { get; set; } = null!;

        public ObjectEntity() 
            : base()
        {
            
        }

        public ObjectEntity(Guid id, string name, string address) 
            : base(id, name)
        {
            Address = address;
        }
    }
}
