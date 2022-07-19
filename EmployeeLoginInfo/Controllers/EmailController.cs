using EmployeeLoginInfo.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestCore.Controllers;

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
        //TODO: Remove after Test
        [HttpGet]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmail(string Email,DateTime Date)
        {
            var employeeDetail = _emailService.SendEmail();

            return Ok();
        }
    }
}
