using System.Threading.Tasks;

namespace IdentityRight.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
