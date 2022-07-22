using EmployeeLoginInfo.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Utility.Email;
using Utility.Models;

namespace EmployeeLoginInfo.Email
{
    public class EmailNotification : IEmailNotification
    {
        private EmployeeDb2022Context _context;
        private IOptions<EmailSetting> _emailSettings;
        private readonly IEmployeeeDetails _employeeService;
        public EmailNotification(EmployeeDb2022Context context,IOptions<EmailSetting> emailSettings, IEmployeeeDetails employeeService)
        {
            _context = context;
            _emailSettings = emailSettings;
            _employeeService = employeeService;
        }
        public async Task SendEmail(string subject, string content, bool isBodyHtml = true)
        {
            List<string> Key = new List<string>();
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.To.Add(new MailAddress("sandeepkgiri20@gmail.com", "Sandeep"));
            message.From = new MailAddress(_emailSettings.Value.Sender, _emailSettings.Value.SenderName);
            message.Subject = subject;
            message.IsBodyHtml = isBodyHtml; //to make message body as html  
            message.Body = content;
            smtp.Port = Convert.ToInt32(_emailSettings.Value.SmtpPort);
            smtp.Host = _emailSettings.Value.SmtpHost; 
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("rakeshpattanayak56@gmail.com", "Rakesh@123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
