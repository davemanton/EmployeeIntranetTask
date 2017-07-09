using System.Threading.Tasks;

namespace Application.Security.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
