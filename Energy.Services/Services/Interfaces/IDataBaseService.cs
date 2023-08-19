using Energy.DAL.Entities;
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
        Task<MeasuringPoint> AddNewPoint();

        Task<IEnumerable<SettlementMeter>> GetSettlementMeters();

        Task<IEnumerable<CounterEnergy>> GetCounterEnergies(string consumptionObjectName);

        Task<IEnumerable<CurrentTransformer>> GetCurrentTransformers(string consumptionObjectName);


        Task<IEnumerable<VoltageTransformer>> GetVoltageTransformers(string consumptionObjectName);
    }
}
