using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class MeasuringPoint : Entity
    {
        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public MeasuringPoint(string name, DateTime startDate)
            : base()
        {
            Name = name;
            StartDate = startDate;
        }
    }
}
