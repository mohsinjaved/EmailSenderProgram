using System.Threading.Tasks;

namespace EmailSenderProgram
{
    public interface IEmailService
    {
        Task SendAsync(string to, string from, string sub, string body);
    }
}
