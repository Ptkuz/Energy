using Energy.DAL.Context;
using Energy.DAL.Entities;
using Energy.Services.Models;
using Energy.Services.Services.Interfaces;
using Energy.Validations;
using Microsoft.EntityFrameworkCore;

namespace Energy.Services.Services
{

    /// <summary>
    /// Сервис работы с базой данных
    /// </summary>
    public class DataBaseService : IDataBaseService
    {

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly EnergyContext _energyContext;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="energyContext">Контекст базы данных</param>
        public DataBaseService(EnergyContext energyContext)
        {
            _energyContext = energyContext;
        }

        /// <summary>
        /// Добавляет новую точку измерения
        /// </summary>
        /// <param name="addNewPointDto">Модель для добавления счетчика</param>
        /// <returns>Экземпляр добавленного объекта <see cref="MeasuringPoint"/></returns>
        public async Task<MeasuringPoint> AddNewPoint(AddNewPointDto addNewPointDto)
        {
            try
            {
                CounterEnergy? counterEnergy = await _energyContext.CounterEnergies.FirstOrDefaultAsync(x => x.Number == addNewPointDto.CounterEnergyNumber);
                CurrentTransformer? currentTransformer = await _energyContext.CurrentTransformers.FirstOrDefaultAsync(x => x.Number == addNewPointDto.CurrentTransformerNumber);
                VoltageTransformer? voltageTransformer = await _energyContext.VoltageTransformers.FirstOrDefaultAsync(x => x.Number == addNewPointDto.VoltageTransformerNumber);
                ConsumptionObject? consumptionObject = await _energyContext.ConsumptionObjects.FirstOrDefaultAsync();

                counterEnergy.CheckArgumentNull(nameof(counterEnergy), $"Счетчик электической энергии по номеру \"{addNewPointDto.CounterEnergyNumber}\" не найден!");
                currentTransformer.CheckArgumentNull(nameof(currentTransformer), $"Трансформатор тока по номеру \"{addNewPointDto.CurrentTransformerNumber}\" не найден!");
                voltageTransformer.CheckArgumentNull(nameof(voltageTransformer), $"Трансформатор напряжения по номеру \"{addNewPointDto.VoltageTransformerNumber}\" не найден!");
                consumptionObject.CheckArgumentNull(nameof(consumptionObject), $"Не найден ни один объект потребления!");

                MeasuringPoint measuringPoint = new MeasuringPoint("Новая точка изменения", consumptionObject.Id, counterEnergy.Id, currentTransformer.Id, voltageTransformer.Id);

                _energyContext.Add(measuringPoint);
                await _energyContext.SaveChangesAsync();

                return measuringPoint;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// Выбирает все расчетные приборы в 2018 году
        /// </summary>
        /// <returns>Коллекция расчетных приборов <see cref="SettlementMeter"/></returns>
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

        /// <summary>
        /// Выбрать все счетчики с заканчившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объекта потребления</param>
        /// <returns>Коллекция счетчиков <see cref="CounterEnergy"/></returns>
        public async Task<IEnumerable<CounterEnergy>> GetCounterEnergies(string consumptionObjectName)
        {
            try
            {
                ConsumptionObject consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

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
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// Выбрать все трансформаторы тока с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объекта потребления</param>
        /// <returns>Коллекция трансформаторов тока <see cref="CurrentTransformer"/></returns>
        public async Task<IEnumerable<CurrentTransformer>> GetCurrentTransformers(string consumptionObjectName)
        {
            try
            {
                ConsumptionObject consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

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
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// Выбрать все трансформаторы напряжения с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объект потребления</param>
        /// <returns>Коллекция трансформаторов напряжения <see cref="VoltageTransformer"/></returns>
        public async Task<IEnumerable<VoltageTransformer>> GetVoltageTransformers(string consumptionObjectName)
        {
            try
            {
                ConsumptionObject consumptionObject = await GetConsumptionObjectByName(consumptionObjectName);

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
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// Получить объект потребления по наименованию объекта
        /// </summary>
        /// <param name="consumptionObjectName">Наименования объекта потребления</param>
        /// <returns>Объект потребления <see cref="ConsumptionObject"/></returns>
        private async Task<ConsumptionObject> GetConsumptionObjectByName(string consumptionObjectName)
        {
            try
            {
                var consumptionObject = await
                    _energyContext.ConsumptionObjects
                    .FirstOrDefaultAsync(x => x.Name == consumptionObjectName);

                consumptionObject.CheckArgumentNull(nameof(consumptionObject), $"Объект потребления по названию \"{consumptionObjectName}\" не найден!");

                return consumptionObject;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
