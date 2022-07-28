using AutoMapper;
using EmployeeLoginInfo.Email.EmailTemplate;
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

        public async Task<IEnumerable<EmployeeDetail>> SendEmail(DateTime Date,string receiver)
        {
            var employeeDetails = _employeeService.GetAllEmployeeDetail().Where(emp => emp.LoginTime.Date == Date.Date);

            foreach (var employeeDetail in employeeDetails)
            {
                string subject = "";
                string content = "";
                subject = _emailTemplate.Value.EmailSubject;
                content = _emailTemplate.Value.ContentTableHeader + String.Format(_emailTemplate.Value.ContentTableBody, employeeDetail.Id, employeeDetail.UserId,
                employeeDetail.UserName,employeeDetail.LoginTime,
                employeeDetail.LogoutTime, employeeDetail.LastUpdateTime, employeeDetail.LastUpdatedBy);

                await _emailNotification.SendEmail(
                receiver,
                subject,
                content,
                true);
            }
            return (employeeDetails);
        }
    }
}
