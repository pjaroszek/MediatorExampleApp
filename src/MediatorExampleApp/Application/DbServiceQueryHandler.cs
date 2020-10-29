namespace MediatorExampleApp.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Models;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class DbServiceQueryHandler : IRequestHandler<DbServiceQuery, DbServiceResponse>
    {
        private readonly ILogger<DbServiceQueryHandler> logger;
        private readonly IDbService service;

        public DbServiceQueryHandler(ILogger<DbServiceQueryHandler> logger, IDbService service)
        {
            (this.logger, this.service) = (logger, service);
        }
        public async Task<DbServiceResponse> Handle(DbServiceQuery request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("[SERVER] Processing '{name}' request.", request.Name);
            return await Task.FromResult(this.service.Work(new DbServiceResponse { Name = "Pawel" }));

        }
    }
}
