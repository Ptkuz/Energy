using Energy.DAL.Context;
using Energy.DAL.Entities;
using Energy.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Energy.Services.Services
{
    public class DataBaseService : IDataBaseService
    {

        private readonly EnergyContext _energyContext;

        public DataBaseService(EnergyContext energyContext)
        {
            _energyContext = energyContext;
        }

        public async Task<MeasuringPoint> AddNewPoint()
        {
            CounterEnergy counterEnergy = new CounterEnergy("45654654645654", "Первый тип счетчика", new DateTime(2018,05,23,00,00,00));
            CurrentTransformer currentTransformer  = new CurrentTransformer("45654654654654", "Первый тип трансформатора", new DateTime(2018,07,09,00,00,00), 1.5);
            VoltageTransformer voltageTransformer = new VoltageTransformer("546546546546", "Второй тип трансформатора", new DateTime(2019, 08, 09, 00, 00, 00), 1.6);

            ConsumptionObject? consumptionObject = await _energyContext.ConsumptionObjects.FirstOrDefaultAsync();

            MeasuringPoint measuringPoint = new MeasuringPoint("Новая точка изменения", consumptionObject.Id, counterEnergy.Id, currentTransformer.Id, voltageTransformer.Id);

            _energyContext.Add(counterEnergy);
            _energyContext.Add(currentTransformer);
            _energyContext.Add(voltageTransformer);
            _energyContext.Add(measuringPoint);
            await _energyContext.SaveChangesAsync();
            
            return measuringPoint;
        }

        public async Task<IEnumerable<SettlementMeter>> GetSettlementMeters()
        {
            IEnumerable<SettlementMeter> settlementMeters
                = await _energyContext.SettlementMeters
                .Where
                (x => (x.StartDate >= new DateTime(2018, 01, 01) 
                && x.StartDate < new DateTime(2019, 01, 01)) ||
                (x.EndDate >= new DateTime(2018, 01, 01) 
                && x.EndDate < new DateTime(2019, 01, 01))).ToListAsync();

            return settlementMeters;
        }

        public async Task<IEnumerable<CounterEnergy>> GetCounterEnergies(string consumptionObjectName)
        {

            var consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

            var counterEnergy = await
                _energyContext.MeasuringPoints
                .Include(x => x.ConsumptionObject)
                .Include(x => x.CounterEnergy)
                .Where(x => x.ConsumptionObject == consumptionObject 
                && x.CounterEnergy.VerificationDate >= DateTime.Now)
                .Select(x => x.CounterEnergy)
                .ToListAsync();

            return counterEnergy;
        }

        public async Task<IEnumerable<CurrentTransformer>> GetCurrentTransformers(string consumptionObjectName)
        {
            var consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

            var currentTransformer = await
                _energyContext.MeasuringPoints
                .Include(x => x.ConsumptionObject)
                .Include(x => x.CurrentTransformer)
                .Where(x => x.ConsumptionObject == consumptionObject
                && x.CurrentTransformer.VerificationDate >= DateTime.Now)
                .Select(x => x.CurrentTransformer)
                .ToListAsync();

            return currentTransformer;
        }

        public async Task<IEnumerable<VoltageTransformer>> GetVoltageTransformers(string consumptionObjectName)
        {
            var consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

            var voltageTransformer = await
                _energyContext.MeasuringPoints
                .Include(x => x.ConsumptionObject)
                .Include(x => x.VoltageTransformer)
                .Where(x => x.ConsumptionObject == consumptionObject
                && x.VoltageTransformer.VerificationDate >= DateTime.Now)
                .Select(x => x.VoltageTransformer)
                .ToListAsync();

            return voltageTransformer;
        }

        private async Task<ConsumptionObject> GetConsumptionObjectByName(string consumptionObjectName) 
        {
            var consumptionObject = await
                _energyContext.ConsumptionObjects
                .FirstOrDefaultAsync(x => x.Name == consumptionObjectName);

            return consumptionObject;
        }
    }
}
