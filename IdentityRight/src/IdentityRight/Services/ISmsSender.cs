using System.Threading.Tasks;

namespace IdentityRight.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
