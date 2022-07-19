using Utility.Email;

namespace EmployeeLoginInfo.Email
{
    public class EmailNotification : IEmailNotification
    {
        public Task SendEmail(string subject, string content, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }
    }
}
