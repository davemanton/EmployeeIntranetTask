using System.Threading.Tasks;

namespace Application.Security.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
