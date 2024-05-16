using Microsoft.AspNetCore.Identity.UI.Services;

namespace Project_ASP.NET_NinjaTurtles.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Här kan vi lägga emails logik/kod 
            return Task.CompletedTask;
        }
    }
}
