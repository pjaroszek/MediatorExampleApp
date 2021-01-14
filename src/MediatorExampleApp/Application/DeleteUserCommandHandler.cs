namespace MediatorExampleApp.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Services;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ILogger<DeleteUserCommandHandler> logger;
        private readonly IDbService dbService;

        public DeleteUserCommandHandler() { }
        public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger, IDbService dbService)
        {
            (this.logger, this.dbService) = (logger, dbService);
        }
        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Delete {Name} from data", request.Name);
            this.dbService.DeleteItem(request.Name);
            return Unit.Task;
        }
    }
}
