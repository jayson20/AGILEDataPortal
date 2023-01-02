using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGILEDataPortal.HelperClasses
{
    public interface IMailHelper
    {
        Task SendEmailNotificationEmailAsync(List<string> email, string subject, string message);

        Task sendMailAsync(string email, string subject, string message);
    }
}
