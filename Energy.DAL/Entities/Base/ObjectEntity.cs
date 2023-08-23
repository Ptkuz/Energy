using System.ComponentModel.DataAnnotations.Schema;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Информация об организации
    /// </summary>
    public class ObjectEntity : NamedEntity
    {

        /// <summary>
        /// Адрес
        /// </summary>
        [Column("Address", Order = 2)]
        public string Address { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ObjectEntity()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="address">Адрес</param>
        public ObjectEntity(string name, string address)
            : base(name)
        {
            Address = address;
        }
    }
}
