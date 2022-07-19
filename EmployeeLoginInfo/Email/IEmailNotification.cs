using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Email
{
    public interface IEmailNotification
    {
        public Task SendEmail( string subject, string content, bool isBodyHtml=true);
    }
}
