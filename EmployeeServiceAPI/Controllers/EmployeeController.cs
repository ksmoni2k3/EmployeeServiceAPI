using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Employee.Entity.Modal;
using Employee.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            var employeeDetails = this._employeeService.GetEmployeeDetails();

            return Ok(employeeDetails);
        }

        [HttpGet("EditEmployee")]
        public IActionResult EditEmployeeDetails(List<EmployeeDetail> lstEmpDetails)
        {
            var employeeDetails = this._employeeService.EditEmployeeDetails(lstEmpDetails);

            return Ok(employeeDetails);
        }
    }
}
