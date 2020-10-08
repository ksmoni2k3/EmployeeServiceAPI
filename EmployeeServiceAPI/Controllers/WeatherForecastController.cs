using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Entity.Modal;
using Employee.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        IEmployeeService _employeeService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            try
            {
                var employeeDetails = this._employeeService.GetEmployeeDetails();

                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
