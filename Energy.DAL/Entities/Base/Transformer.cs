using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{
    public class Transformer : Entity
    {
        public uint Number { get; set; }

        public string TransformerType { get; set; }

        public DateTime VerificationDate { get; set; }

        public Transformer(uint number, string transformerType, DateTime verificationDate) 
            : base()
        {
            Number = number;
            TransformerType = transformerType;
            VerificationDate = verificationDate;
        }

    }
}
