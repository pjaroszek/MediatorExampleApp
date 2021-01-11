using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorExampleApp.Application
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");


            var command = request as AddUserCommand;
            if (command != null)
            {
                if (!string.IsNullOrEmpty(command.FirstName) && !string.IsNullOrEmpty(command.LastName))
                {
                    throw new System.Exception("Przerwanie dodawania");
                }
            }

            // go to the next behaviour in the chain/to the request handler
            var response = await next();

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }
}