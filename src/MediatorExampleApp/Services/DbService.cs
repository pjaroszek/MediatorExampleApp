namespace MediatorExampleApp.Services
{
    using System.Collections.Generic;
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public sealed class DbService : IDbService
    {
        private readonly Dictionary<string, DbServiceResponse> DbServiceDictionary = new Dictionary<string, DbServiceResponse>();
        private readonly ILogger<DbService> logger;
        private readonly MediatorOptions options;

        public DbService(ILogger<DbService> logger, IOptions<MediatorOptions> options)
        {
            (this.logger, this.options) = (logger, options.Value);

            DbServiceDictionary.Add("Pawel", new DbServiceResponse
            {
                Name = "Pawel",
                Surname = "Jaroszek"
            });
        }
        public DbServiceResponse Work(DbServiceResponse data)
        {
            this.logger.LogInformation("[SERVER] Requesting information about '{Name}'.", data.Name);
            if (this.DbServiceDictionary.ContainsKey(data.Name))
            {
                this.logger.LogInformation("[SERVER] Informaction about '{Name}' found.", data.Name);
                return this.DbServiceDictionary[data.Name];
            }
            else
            {
                this.logger.LogInformation("[SERVER] Informaction about '{Name}' not found.", data.Name);
                return new DbServiceResponse();
            }
        }
    }
}
