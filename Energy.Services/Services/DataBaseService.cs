using Energy.DAL.Context;
using Energy.DAL.Entities;
using Energy.Services.Services.Interfaces;

namespace Energy.Services.Services
{
    public class DataBaseService : IDataBaseService
    {

        private readonly EnergyContext _energyContext;

        public DataBaseService(EnergyContext energyContext)
        {
            _energyContext = energyContext;
        }

        public Task AddNewPoint()
        {
            throw new Exception();

            
        }

    }
}
