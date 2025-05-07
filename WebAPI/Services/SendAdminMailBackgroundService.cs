using Application.Interfaces.Services;

namespace WebAPI.Services
{
    public class SendAdminMailBackgroundService(IServiceProvider serviceProvider) : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async _ => await NotifyToAdminAsync(), null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async Task NotifyToAdminAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
            await emailService.SendNotificationToAdminAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
