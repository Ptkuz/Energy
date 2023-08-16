﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Именованная сущность
    /// </summary>
    public class NamedEntity : Entity
    {

        public string Name { get; set; } = null!;

        public NamedEntity(string name)
            : base()
        {
            Name = name;
        }
    }
}
