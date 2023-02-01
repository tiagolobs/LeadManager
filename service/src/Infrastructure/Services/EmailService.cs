using Application.Services;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string recipient, string subject, string message)
        {
            Console.WriteLine($"Email sent to {recipient}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}