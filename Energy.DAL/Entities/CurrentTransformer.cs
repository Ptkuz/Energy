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
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformer : Transformer
    {

        public string CTC { get; set; } = null!;

        [ForeignKey("MeasuringPointId")]
        public MeasuringPoint MeasuringPoint { get; set; } = null!;

        public CurrentTransformer()
           : base()
        {

        }

        public CurrentTransformer(uint number, DateTime verificationDate, string transformerType, string cTC)
            : base(number, verificationDate, transformerType)
        {
            CTC = cTC;
        }
    }
}
