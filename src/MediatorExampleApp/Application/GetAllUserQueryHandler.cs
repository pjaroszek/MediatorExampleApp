namespace MediatorExampleApp.Application
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Models;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<DbServiceResponse>>
    {
        private readonly IDbService dbService;
        private readonly ILogger<GetAllUserQueryHandler> logger;

        public GetAllUserQueryHandler()
        { }
        public GetAllUserQueryHandler(IDbService dbService, ILogger<GetAllUserQueryHandler> logger)
        {
            (this.dbService, this.logger) = (dbService, logger);
        }
        public async Task<List<DbServiceResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Get all contractors");
            return await Task.FromResult(dbService.GetAllUser());
        }
    }
}