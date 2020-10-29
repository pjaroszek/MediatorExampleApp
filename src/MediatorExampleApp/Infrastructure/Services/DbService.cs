namespace MediatorExampleApp.Infrastructures.Services
{
    using MediatorExampleApp.Interfaces;
    using MediatorExampleApp.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public sealed class DbService : IDbService
    {
        private readonly ILogger<DbService> logger;
        private readonly MediatorOptions options;

        public DbService(ILogger<DbService> logger, IOptions<MediatorOptions> options)
        {
            (this.logger, this.options) = (logger, options.Value);
        }
        public DbServiceResponse Work(DbServiceResponse data)
        {
            this.logger.LogInformation("[SERVER] Requesting information about '{Name}'.", data.Name);
            if (data.Name == "Pawel")
            {
                data.Surname = "Jaroszek";
            }
            else
            {
                this.logger.LogInformation("[SERVER] Informaction about '{Name}' not found.", data.Name);
                data.Surname = "not found";
            }

            return data;
        }
    }
}
