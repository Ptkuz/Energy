using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class VoltageTransformer : Transformer
    {

        public string CTV { get; set; } = null!;

        public VoltageTransformer(string cTv, uint number, string transformerType, DateTime verificationDate)
            : base(number, transformerType, verificationDate)
        {
            CTV = cTv;
        }


    }
}
