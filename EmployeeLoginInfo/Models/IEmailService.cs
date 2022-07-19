using StudentLoginInfo.Models;

namespace EmployeeLoginInfo.Models
{
    public interface IEmailService
    {
       Task< IEnumerable <EmployeeDetail>> SendEmail();
    }
}