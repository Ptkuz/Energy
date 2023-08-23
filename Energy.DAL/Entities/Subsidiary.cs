using Energy.DAL.Entities.Base;
using Entity = Energy.DAL.Entities;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class Subsidiary : ObjectEntity
    {

        /// <summary>
        /// Навигационное свойство <see cref="Entity.Organization"/>
        /// </summary>
        public Organization? Organization { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="Entity.Organization"/>
        /// </summary>
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Внешний ключ <see cref="Entity.ConsumptionObject"/>
        /// </summary>
        public List<ConsumptionObject> ConsumptionObjects { get; set; } = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Subsidiary()
           : base()
        {

        }

        /// <summary>
        /// Конструтор инициализатор
        /// </summary>
        /// <param name="name">Наименовние</param>
        /// <param name="address">Адрес</param>
        /// <param name="organizationId">Внешний ключ <see cref="Entity.Organization"/></param>
        public Subsidiary(string name, string address, Guid organizationId) :
            base(name, address)
        {
            OrganizationId = organizationId;
        }
    }
}
