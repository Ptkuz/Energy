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
    [ApiController]
    [Route("Energy/api/[controller]")]
    public class TasksController : ControllerBase
    {


        private readonly ILogger<TasksController> _logger;
        private readonly IDataBaseService _dataBaseService;

        public TasksController(ILogger<TasksController> logger, IDataBaseService dataBaseService)
        {
            _logger = logger;
            _dataBaseService = dataBaseService;
        }

        [HttpPost("AddNewMeasuringPoint")]
        public async Task<IActionResult> AddNewMeasuringPoint([FromBody] AddNewMeasuringPointRequest addNewMeasuringPointRequest)
        {
            try
            {
                AddNewPointDto addNewPointDto = MappingRequests.MapAddNewMeasuringPointRequestAndAddNewPointDto(addNewMeasuringPointRequest);
                MeasuringPoint measuringPoint = await _dataBaseService.AddNewPoint(addNewPointDto);
                return Ok(new AddNewMeasuringPointResponse(measuringPoint));
            }
            catch (Exception ex)
            {
                return BadRequest(new AddNewMeasuringPointResponse(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

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
                return BadRequest(new CollectionResponse<SettlementMeter>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        [HttpGet("GetCounterEnergies{consumptionObjectName}")]
        public async Task<IActionResult> GetCounterEnergies(string consumptionObjectName)
        {
            try
            {
                IEnumerable<CounterEnergy> counterEnergies =
                    await _dataBaseService.GetCounterEnergies(consumptionObjectName);
                return Ok(new CollectionResponse<CounterEnergy>(counterEnergies));
            }
            catch (Exception ex)
            {
                return BadRequest(new CollectionResponse<CounterEnergy>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        [HttpGet("GetCurrentTransformers{consumptionObjectName}")]
        public async Task<IActionResult> GetCurrentTransformers(string consumptionObjectName)
        {
            try
            {
                IEnumerable<CurrentTransformer> currentTransformers =
                    await _dataBaseService.GetCurrentTransformers(consumptionObjectName);
                return Ok(new CollectionResponse<CurrentTransformer>(currentTransformers));
            }
            catch (Exception ex)
            {
                return BadRequest(new CollectionResponse<CurrentTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

        [HttpGet("GetVoltageTransformers{consumptionObjectName}")]
        public async Task<IActionResult> GetVoltageTransformers(string consumptionObjectName)
        {
            try
            {
                IEnumerable<VoltageTransformer> voltageTransformers =
                    await _dataBaseService.GetVoltageTransformers(consumptionObjectName);
                return Ok(new CollectionResponse<VoltageTransformer>(voltageTransformers));
            }
            catch (Exception ex)
            {
                return BadRequest(new CollectionResponse<VoltageTransformer>(new ErrorInfo(ex.Message, ex.StackTrace)));
            }
        }

    }
}