namespace Application.Services
{
    public interface IEmailService
    {
        void Send(string recipient, string subject, string message);
    }
}