using AutoMapper;
using EmployeeLoginInfo.Email.EmailTemplate;
using MediatR;
using Microsoft.Extensions.Options;
using StudentLoginInfo.Models;
using Utility.Email;

namespace EmployeeLoginInfo.Models
{
    public class EmailService : IEmailService
    {
        private EmployeeDb2022Context _context;
        private IOptions<EmailTemplate> _emailTemplate;
        private readonly IEmployeeeDetails _employeeService;
        private readonly IEmailNotification _emailNotification;
        public EmailService(EmployeeDb2022Context context, IOptions<EmailTemplate> emailTemplate,
            IEmployeeeDetails employeeService,
            IEmailNotification emailNotification)
        {
            _context = context;
            _emailTemplate = emailTemplate;
            _employeeService = employeeService;
            _emailNotification = emailNotification;
        }

        public async Task<IEnumerable<EmployeeDetail>> SendEmail()
        {
            var employeeDetails = _employeeService.GetAllEmployeeDetail();

            foreach (var employeeDetail in employeeDetails)
            {
                string subject = "";
                string content = "";
                subject = _emailTemplate.Value.ContentTableHeader;
                content = String.Format(_emailTemplate.Value.ContentTableBody, employeeDetail.Id, employeeDetail.UserId,
                employeeDetail.Login, employeeDetail.Logout, employeeDetail.LastUpdateTime, employeeDetail.LastUpdatedBy);

                await _emailNotification.SendEmail(
                subject,
                content,
                true);
            }
            return (employeeDetails);
        }
    }
}
