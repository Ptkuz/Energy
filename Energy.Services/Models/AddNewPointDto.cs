using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Services.Models
{
    public class AddNewPointDto
    {
        /// <summary>
        /// Номер счетчика энергии
        /// </summary>
        public string CounterEnergyNumber { get; set; } = null!;

        /// <summary>
        /// Номер трансформатора тока
        /// </summary>
        public string CurrentTransformerNumber { get; set; } = null!;

        /// <summary>
        /// Номер трансформатора напряжения
        /// </summary>
        public string VoltageTransformerNumber { get; set; } = null!;
    }
}
