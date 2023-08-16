using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{
    public class Entity
    {
        [Key]
        [Column("Id", Order = 0)]
        public Guid Id { get; set; }

        [Column("DateAdded", Order = 1)]
        public DateTime DateAdded { get; set; }

        [Column("DateModified", Order = 2)]
        public DateTime DateUpdated { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            DateAdded = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }

        public Entity(Guid id)
        {
            Id = id;
            DateAdded = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }
    }
}
