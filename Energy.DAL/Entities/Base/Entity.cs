using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
