using Energy.DAL.Entities;
using Energy.Services.Models;

namespace Energy.Services.Services.Interfaces
{
    /// <summary>
    /// Сервис работы с базой данных
    /// </summary>
    public interface IDataBaseService
    {

        /// <summary>
        /// Добавляет новую точку измерения
        /// </summary>
        /// <param name="addNewPointDto">Модель для добавления счетчика</param>
        /// <returns>Экземпляр добавленного объекта <see cref="MeasuringPoint"/></returns>
        Task<MeasuringPoint> AddNewPoint(AddNewPointDto addNewPointDto);

        /// <summary>
        /// Выбирает все расчетные приборы в 2018 году
        /// </summary>
        /// <returns>Коллекция расчетных приборов <see cref="SettlementMeter"/></returns>
        Task<IEnumerable<SettlementMeter>> GetSettlementMeters();

        /// <summary>
        /// Выбрать все счетчики с заканчившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объекта потребления</param>
        /// <returns>Коллекция счетчиков <see cref="CounterEnergy"/></returns>
        Task<IEnumerable<CounterEnergy>> GetCounterEnergies(string consumptionObjectName);

        /// <summary>
        /// Выбрать все трансформаторы тока с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объекта потребления</param>
        /// <returns>Коллекция трансформаторов тока <see cref="CurrentTransformer"/></returns>
        Task<IEnumerable<CurrentTransformer>> GetCurrentTransformers(string consumptionObjectName);

        /// <summary>
        /// Выбрать все трансформаторы напряжения с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumptionObjectName">Наименование объект потребления</param>
        /// <returns>Коллекция трансформаторов напряжения <see cref="VoltageTransformer"/></returns>
        Task<IEnumerable<VoltageTransformer>> GetVoltageTransformers(string consumptionObjectName);
    }
}
