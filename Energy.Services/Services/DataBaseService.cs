using Energy.DAL.Context;
using Energy.DAL.Entities;
using Energy.Services.Models;
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

        public async Task<MeasuringPoint> AddNewPoint(AddNewPointDto addNewPointDto)
        {
            CounterEnergy counterEnergy = await _energyContext.CounterEnergies.FirstOrDefaultAsync(x => x.Number == addNewPointDto.CounterEnergyNumber);
            CurrentTransformer currentTransformer = await _energyContext.CurrentTransformers.FirstOrDefaultAsync(x => x.Number == addNewPointDto.CurrentTransformerNumber);
            VoltageTransformer voltageTransformer = await _energyContext.VoltageTransformers.FirstOrDefaultAsync(x => x.Number == addNewPointDto.VoltageTransformerNumber);

            ConsumptionObject? consumptionObject = await _energyContext.ConsumptionObjects.FirstOrDefaultAsync();

            MeasuringPoint measuringPoint = new MeasuringPoint("Новая точка изменения", consumptionObject.Id, counterEnergy.Id, currentTransformer.Id, voltageTransformer.Id);

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
                && x.CounterEnergy.VerificationDate <= DateTime.Now)
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
                && x.CurrentTransformer.VerificationDate <= DateTime.Now)
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
                && x.VoltageTransformer.VerificationDate <= DateTime.Now)
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
