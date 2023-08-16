using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{

    /// <summary>
    /// Трансформатор напряжения 
    /// </summary>
    public class VoltageTransformer : Transformer
    {

        public string CTV { get; set; } = null!;


        public VoltageTransformer(uint number, DateTime verificationDate, string transformerType, string cTV) 
            : base(number, verificationDate, transformerType)
        {
            CTV = cTV;
        }
    }
}
