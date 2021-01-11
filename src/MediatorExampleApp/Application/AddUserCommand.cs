namespace MediatorExampleApp.Application
{
    using MediatR;

    public record AddUserCommand(string FirstName, string LastName) : IRequest;
    public record AddedUserNotification(string FirstName, string LastName) : INotification;

}