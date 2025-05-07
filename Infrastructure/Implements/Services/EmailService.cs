using Application.Interfaces.Base;
using Application.Interfaces.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Infrastructure.Implements.Services
{
    public class EmailService(IUnitOfWork _unitOfWork, IEmailSender emailSender) : IEmailService
    {
        public async Task SendNotificationToAdminAsync()
        {
            var adminAccounts = await _unitOfWork.UserRepository.GetAllAsync(user => user.Role == RoleEnum.Admin);
            var emails = adminAccounts.Select(adminAccounts => adminAccounts.Email).ToList();
            foreach (var email in emails)
            {
                await emailSender.SendEmailAsync(email, "Notification", "You have a new notification.");
            }
        }
    }
}
