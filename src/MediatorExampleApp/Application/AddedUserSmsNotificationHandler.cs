namespace MediatorExampleApp.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class AddedUserSmsNotificationHandler : INotificationHandler<AddedUserNotification>
    {
        private readonly ILogger<AddedUserSmsNotificationHandler> logger;
        public AddedUserSmsNotificationHandler(ILogger<AddedUserSmsNotificationHandler> logger)
        {
            this.logger = logger;
        }
        public Task Handle(AddedUserNotification notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Sms sended");
            return Task.CompletedTask;
        }
    }
}