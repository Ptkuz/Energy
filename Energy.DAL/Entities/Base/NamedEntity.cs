﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Именованная сущность
    /// </summary>
    public class NamedEntity : Entity
    {

        /// <summary>
        /// Наименование
        /// </summary>
        [Column("Name", Order = 1)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public NamedEntity()
            : base()
        {

        }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="name">Наименование</param>
        public NamedEntity(string name)
            : base()
        {
            Name = name;
        }
    }
}
