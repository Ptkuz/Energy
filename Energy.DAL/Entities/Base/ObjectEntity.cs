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

        [Column("Address", Order = 2)]
        public string Address { get; set; } = null!;

        public ObjectEntity(string name, string address) 
            : base(name)
        {
            Address = address;
        }
    }
}
