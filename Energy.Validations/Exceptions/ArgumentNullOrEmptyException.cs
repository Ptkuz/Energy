using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Validations.Exceptions
{
    [Serializable]
    public class ArgumentNullOrEmptyException : Exception
    {

        public string ArgumentName { get; }

        public ArgumentNullOrEmptyException(string argumentName, string message)
            : base(message)
        {
            ArgumentName = argumentName;
        }
    }
}
