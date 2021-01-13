namespace MediatorExampleApp.Application
{
    using System.Collections.Generic;
    using MediatorExampleApp.Models;
    using MediatR;
    public sealed class GetAllUserQuery : IRequest<List<DbServiceResponse>>
    {

    }
}