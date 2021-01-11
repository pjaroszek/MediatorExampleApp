namespace MediatorExampleApp.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class AddedUserEmailNotificationHandler : INotificationHandler<AddedUserNotification>
    {
        private readonly ILogger<AddedUserEmailNotificationHandler> logger;
        public AddedUserEmailNotificationHandler(ILogger<AddedUserEmailNotificationHandler> logger)
        {
            this.logger = logger;
        }
        public Task Handle(AddedUserNotification notification, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Email sended");
            return Task.CompletedTask;
        }
    }
}