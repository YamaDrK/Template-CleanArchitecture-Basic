namespace Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendNotificationToAdminAsync();
    }
}
