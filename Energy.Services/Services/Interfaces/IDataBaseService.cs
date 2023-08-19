using Energy.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Services.Services.Interfaces
{
    public interface IDataBaseService
    {
        Task AddNewPoint();
    }
}
