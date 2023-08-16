using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{
    public class Organization : Entity
    {

        [Column("Name", Order = 3)]
        public string Name { get; set; } = null!;

        [Column("Address", Order = 4)]
        public string Address { get; set; } = null!;

        public Organization(string name, string address)
            : base()
        {
            Name = name;
            Address = address;
        }
    }
}
