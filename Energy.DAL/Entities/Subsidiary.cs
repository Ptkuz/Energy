﻿using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class Subsidiary : Organization
    {
        public Subsidiary(string name, string address) :
            base(name, address)
        {

        }
    }
}
