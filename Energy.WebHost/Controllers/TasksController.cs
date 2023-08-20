using Energy.DAL.Entities;
using Energy.Services.Models;
using Energy.Services.Services.Interfaces;
using Energy.WebHost.Models.Mapping;
using Energy.WebHost.Models.RequestModels;
using Energy.WebHost.Models.ResponseModels;
using Energy.WebHost.Models.ResponseModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Energy.WebHost.Controllers
{
    /// <summary>
    /// Контроллер задач из тестового задания
    /// </summary>
    [ApiController]
    [Route("Energy/api/[controller]")]
    public class TasksController : ControllerBase
    {

        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<TasksController> _logger;

        /// <summary>
        /// Сервис работы с базой данных
        /// </summary>
        private readonly IDataBaseService _dataBaseService;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="dataBaseService">Сервис работы с базой данных</param>
        public TasksController(ILogger<TasksController> logger, IDataBaseService dataBaseService)
        {
            _logger = logger;
            _dataBaseService = dataBaseService;
        }

        /// <summary>
        /// Добавить новую точку измерения с указанием счетчика,
        /// трансформатора тока и трансформатора напряжения.
        /// Поиск счетчика и трансформатора будет проходить по номерам, 
        /// который содержится в модели <see cref="AddNewMeasuringPointRequest"/>
        /// Для теста необходимо указать номера. Сущности по этим номерам уже добавлены в базу данных:
        /// Счетчик электрической энергии: 1111
        /// Трансформатор тока: 2222
        /// Трансформатор напряжения: 3333
        /// </summary>
        /// <param name="addNewMeasuringPointRequest">Модель, содержащая номера счетчика и трансформаторов</param>
        /// <returns><see cref="AddNewMeasuringPointResponse"/></returns>
        [HttpPost("AddNewMeasuringPoint")]
        public async Task<IActionResult> AddNewMeasuringPoint([FromBody] AddNewMeasuringPointRequest addNewMeasuringPointRequest)
        {
            try
            {
                AddNewPointDto addNewPointDto = MappingRequests.MapAddNewMeasuringPointRequestAndAddNewPointDto(addNewMeasuringPointRequest);
                MeasuringPoint measuringPoint = await _dataBaseService.AddNewPoint(addNewPointDto);
                return Ok(new AddNewMeasuringPointResponse(measuringPoint));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new AddNewMeasuringPointResponse(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new AddNewMeasuringPointResponse(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        /// <summary>
        /// Выбрать все расчетные приборы учета в 2018 году
        /// Выведутся все расчетные приборы, у которых дата старта или дата завершения
        /// находятся в пределах 2018 года
        /// </summary>
        /// <returns><see cref="CollectionResponse{T}"/></returns>
        [HttpGet("GetSettlementMeters")]
        public async Task<IActionResult> GetSettlementMeters()
        {
            try
            {
                IEnumerable<SettlementMeter> settlementMeters =
                    await _dataBaseService.GetSettlementMeters();
                return Ok(new CollectionResponse<SettlementMeter>(settlementMeters));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new CollectionResponse<SettlementMeter>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        /// <summary>
        /// По указанному объекту потребления выбрать все счетчики с закончившимся 
        /// сроком поверке
        /// Необходимо указать названия Объекта потребления. Для теста нужно указать:
        /// Тестовый объект потребления 6
        /// </summary>
        /// <param name="consumptionObjectName">Название объекта потребления <see cref="ConsumptionObject"/></param>
        /// <returns><see cref="CollectionResponse{T}"/></returns>
        [HttpGet("GetCounterEnergies{consumptionObjectName}")]
        public async Task<IActionResult> GetCounterEnergies(string consumptionObjectName)
        {
            try
            {
                IEnumerable<CounterEnergy> counterEnergies =
                    await _dataBaseService.GetCounterEnergies(consumptionObjectName);
                return Ok(new CollectionResponse<CounterEnergy>(counterEnergies));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new CollectionResponse<CounterEnergy>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CollectionResponse<CounterEnergy>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы 
        /// напряжения с закончившимся сроком поверке
        /// Необходимо указать названия Объекта потребления. Для теста нужно указать:
        /// Тестовый объект потребления 7
        /// </summary>
        /// <param name="consumptionObjectName">Название объекта потребления <see cref="ConsumptionObject"/></param>
        /// <returns><see cref="CollectionResponse{T}"/></returns>
        [HttpGet("GetCurrentTransformers{consumptionObjectName}")]
        public async Task<IActionResult> GetCurrentTransformers(string consumptionObjectName)
        {
            try
            {
                IEnumerable<CurrentTransformer> currentTransformers =
                    await _dataBaseService.GetCurrentTransformers(consumptionObjectName);
                return Ok(new CollectionResponse<CurrentTransformer>(currentTransformers));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new CollectionResponse<CurrentTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CollectionResponse<CurrentTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }


        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы тока
        /// с закончившимся сроком поверке
        /// Необходимо указать названия Объекта потребления. Для теста нужно указать:
        /// Тестовый объект потребления 6
        /// </summary>
        /// <param name="consumptionObjectName">Название объекта потребления <see cref="ConsumptionObject"/></param>
        /// <returns><see cref="CollectionResponse{T}"/></returns>
        [HttpGet("GetVoltageTransformers{consumptionObjectName}")]
        public async Task<IActionResult> GetVoltageTransformers(string consumptionObjectName)
        {
            try
            {
                IEnumerable<VoltageTransformer> voltageTransformers =
                    await _dataBaseService.GetVoltageTransformers(consumptionObjectName);
                return Ok(new CollectionResponse<VoltageTransformer>(voltageTransformers));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new CollectionResponse<VoltageTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CollectionResponse<VoltageTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }

        }

    }
}