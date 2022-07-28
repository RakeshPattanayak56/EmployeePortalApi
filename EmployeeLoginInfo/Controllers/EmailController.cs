using EmployeeLoginInfo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoginInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailController(
            IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmail(string Email,DateTime Date)
        {
            var employeeDetail = _emailService.SendEmail(Date,Email);

            return Ok(employeeDetail);
        }
    }
}
