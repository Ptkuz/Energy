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

        [HttpGet(Name = "AddNewMeasuringPoint")]
        public IActionResult AddNewMeasuringPoint()
        {
            _dataBaseService.AddNewPoint();
            return Ok();
        }
    }
}