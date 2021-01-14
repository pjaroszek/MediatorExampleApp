namespace MediatorExampleApp.Application
{
    using MediatR;
    public sealed record DeleteUserCommand(string Name) : IRequest;
}