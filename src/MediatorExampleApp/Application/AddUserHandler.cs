namespace MediatorExampleApp.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Models;
    using MediatR;

    public sealed class AddUserHandler : IRequestHandler<AddUserCommand>
    {

        private readonly IDbService dbService;
        private readonly IMediator mediator;

        public AddUserHandler(IDbService dbService, IMediator mediator)
        {
            (this.dbService, this.mediator) = (dbService, mediator);
        }

        public Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new DbServiceResponse()
            {
                Name = request.FirstName,
                Surname = request.LastName
            };
            dbService.AddUser(user);

            mediator.Publish(new AddedUserNotification(request.FirstName, request.LastName), cancellationToken);

            
            return Unit.Task;
        }
    }
}