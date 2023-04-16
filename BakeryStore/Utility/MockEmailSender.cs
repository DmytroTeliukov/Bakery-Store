using Microsoft.AspNetCore.Identity.UI.Services;

namespace BakeryStore.Utility
{
    // for mocking email sender
    public class MockEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
