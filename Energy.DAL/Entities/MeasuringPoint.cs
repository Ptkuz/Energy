using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class MeasuringPoint : NamedEntity
    {

        public DateTime StartDate { get; set; }

        public MeasuringPoint(string name, DateTime startDate) 
            : base(name)
        {
            StartDate = startDate;
        }
    }
}
