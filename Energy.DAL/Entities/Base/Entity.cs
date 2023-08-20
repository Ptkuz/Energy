using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class Entity
    {

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        [Column("Id", Order = 0)]
        public Guid Id { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
