namespace MediatorExampleApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MediatorExampleApp.Models;
    using MediatR;
    using System.Threading.Tasks;
    using MediatorExampleApp.Application;
    using System.Threading;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMediator mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            (this.logger, this.mediator) = (logger, mediator);
        }

        [HttpGet("{name}")]
        public async Task<DbServiceResponse> Get(string name)
        {
            var result = await this.mediator.Send(new DbServiceQuery(name), CancellationToken.None);
            return result;
        }

        [HttpGet]
        public async Task<List<DbServiceResponse>> GetAll()
        {
            var result = await this.mediator.Send(new GetAllUserQuery(), CancellationToken.None);
            return result;
        }

        [HttpPost]
        public async Task Post(DbServiceResponse user)
        {
            this.mediator.Send(new AddUserCommand(user.Name, user.Surname), CancellationToken.None);
        }


    }
}
