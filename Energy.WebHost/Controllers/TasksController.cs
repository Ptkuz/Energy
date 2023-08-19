using Energy.DAL.Context;
using Energy.DAL.Entities;
using Energy.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Energy.WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> AddNewMeasuringPoint()
        {
            MeasuringPoint measuringPoint = 
                await _dataBaseService.AddNewPoint();
            return Ok(measuringPoint);
        }

        [HttpGet("GetSettlementMeters")]
        public async Task<IActionResult> GetSettlementMeters()
        {
            IEnumerable<SettlementMeter> settlementMeters = 
                await _dataBaseService.GetSettlementMeters();
            return Ok(settlementMeters);
        }

        [HttpGet("GetCounterEnergies")]
        public async Task<IActionResult> GetCounterEnergies(string consumptionObjectName) 
        {
            IEnumerable<CounterEnergy> counterEnergies =
                await _dataBaseService.GetCounterEnergies(consumptionObjectName);
            return Ok(counterEnergies);
        }

        [HttpGet("GetCurrentTransformers")]
        public async Task<IActionResult> GetCurrentTransformers(string consumptionObjectName) 
        {
            IEnumerable<CurrentTransformer> currentTransformers =
                await _dataBaseService.GetCurrentTransformers(consumptionObjectName);
            return Ok(currentTransformers);
        }

        [HttpGet("GetVoltageTransformers")]
        public async Task<IActionResult> GetVoltageTransformers(string consumptionObjectName) 
        {
            IEnumerable<VoltageTransformer> voltageTransformers =
                await _dataBaseService.GetVoltageTransformers(consumptionObjectName);
            return Ok(voltageTransformers);
        }

    }
}