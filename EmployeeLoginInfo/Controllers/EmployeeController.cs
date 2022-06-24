using EmployeeLoginInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLoginInfo.Models;
using System.Web;

namespace EmployeeLoginInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeeDetails _employeeService;
        public EmployeeController(
            IEmployeeeDetails employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("getemployee")]
        public IActionResult GetEmployeeDetail(int Id)
        {
            EmployeeDetail employeeDetail = _employeeService.GetEmployeeDetailById(Id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            return Ok(employeeDetail);
        }
        [HttpGet]
        [Route("getemployees/")]
        public IActionResult GetAllEmployeeDetails()
        {
            var employeeDetail = _employeeService.GetAllEmployeeDetail();

            return Ok(employeeDetail);
        }
        [HttpPost]
        [Route("saveemployee")]
        public IActionResult UpdateEmployeesDetail([FromBody] EmployeeDetail employeeDetail)
        {
            EmployeeDetail existingStudentDetail = _employeeService.GetEmployeeDetailById(employeeDetail.Id);
            if (existingStudentDetail != null || employeeDetail.Id == 0)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _employeeService.Post(employeeDetail, existingStudentDetail);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            else
            {
                return NotFound("For new employeeDetail, id need to be zero(0)");
            }
            return Ok(employeeDetail);
        }
        [HttpDelete]
        [Route("deleteemployee")]
        public IActionResult DeleteStudentDetail(int Id)
        {
            _employeeService.DeleteStudentDetail(Id);
            return Ok();
        }
    }
}
