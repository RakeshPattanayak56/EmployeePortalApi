using EmployeeLoginInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoginInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEmployeeController : ControllerBase
    {
        private IAddEmployeeDetails _addemployeeService;
        public AddEmployeeController(
            IAddEmployeeDetails employeeService)
        {
            _addemployeeService = employeeService;
        }

        [HttpGet]
        [Route("getemployeedetail")]
        public IActionResult GetAddEmployeeDetail(int Id)
        {
            AddEmployeeDetail addEmployeeDetail = _addemployeeService.GetAddEmployeeDetailById(Id);
            if (addEmployeeDetail == null)
            {
                return NotFound();
            }
            return Ok(addEmployeeDetail);
        }

        [HttpGet]
        [Route("getallemployeedetail/")]
        public IActionResult GetAllAddEmployeeDetail()
        {
            var addEmployeeDetail = _addemployeeService.GetAllAddEmployeeDetail();

            return Ok(addEmployeeDetail);
        }

        [HttpPost]
        [Route("addemployee")]
        public IActionResult UpdateEmployeesDetail([FromBody] AddEmployeeDetail addEmployeeDetail)
        {
            AddEmployeeDetail existingEmployeeDetail = _addemployeeService.GetAddEmployeeDetailById(addEmployeeDetail.id);
            if (existingEmployeeDetail != null || addEmployeeDetail.id == 0)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _addemployeeService.Post(addEmployeeDetail, existingEmployeeDetail);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            else
            {
                return NotFound("For new addemployeeDetail, id need to be zero(0)");
            }
            return Ok(addEmployeeDetail);
        }
    }
}
