using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.DAL.Entities
{
    public class MainOrganization : Organization
    {
        public MainOrganization(string name, string address) 
            : base(name, address)
        {

        }
    }
}
