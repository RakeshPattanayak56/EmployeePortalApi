using EmployeeLoginInfo.Models;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
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
        public EmailNotification(EmployeeDb2022Context context, IOptions<EmailSetting> emailSettings, IEmployeeeDetails employeeService)
        {
            _context = context;
            _emailSettings = emailSettings;
            _employeeService = employeeService;
        }
        public async Task SendEmail( string receiver,string subject, string content, bool isBodyHtml = true)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(_emailSettings.Value.Sender, _emailSettings.Value.SenderName);
                //message.To.Add(new MailAddress("sandeepkgiri20@gmail.com","Sandeep"));
                message.To.Add(new MailAddress(receiver));
                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = isBodyHtml;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.Value.Sender, _emailSettings.Value.Password);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }

                //var toEmail = new EmailAddress(receiver);
                //var fromEmail = new EmailAddress("rakeshpattanayak56@gmail.com", "Rakesh");
                //var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, string.Empty, content);
            }
        }
    }
}
