using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class CurrentTransformer : Transformer
    {

        public string CTC { get; set; } = null!;

        public CurrentTransformer(string cTC, uint number, string transformerType, DateTime verificationDate) 
            : base(number, transformerType, verificationDate)
        {
            CTC = cTC;
        }
    }
}
