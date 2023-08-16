using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities.Base
{

    /// <summary>
    /// Базовый трансформатор
    /// </summary>
    public class Transformer : BaseEnergyEntity
    {

        public string TransformerType { get; set; }

        public Transformer(uint number, DateTime verificationDate, string transformerType) 
            : base(number, verificationDate)
        {
            TransformerType = transformerType;
        }

    }
}
