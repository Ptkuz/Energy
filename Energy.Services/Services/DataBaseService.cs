using Energy.DAL.Context;
using Energy.DAL.Entities;

namespace Energy.Services.Services
{
    public class DataBaseService<T>
    {

        private readonly EnergyContext _energyContext;

        public DataBaseService(EnergyContext energyContext)
        {
            _energyContext = energyContext;

            if (!_energyContext.Organizations.Any())
            {

            }
        }

        public Task AddNewPoint()
        {
            throw new Exception();
        }

    }
}
