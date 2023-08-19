using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public double CTV { get; set; }

        public MeasuringPoint MeasuringPoint { get; set; }



        public VoltageTransformer()
           : base()
        {

        }

        public VoltageTransformer(uint number, DateTime verificationDate, string transformerType, double cTV) 
            : base(number, verificationDate, transformerType)
        {
            CTV = cTV;
        }
    }
}
