using Energy.DAL.Entities.Base;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Организация
    /// </summary>
    public class Organization : ObjectEntity
    {

        /// <summary>
        /// Внешний ключ <see cref="Subsidiary"/>
        /// </summary>
        public List<Subsidiary> Subsidiaries { get; set; } = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Organization()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="address">Адрес</param>
        public Organization(string name, string address)
            : base(name, address)
        {

        }
    }
}
