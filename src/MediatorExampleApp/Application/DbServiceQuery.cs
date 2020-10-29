namespace MediatorExampleApp.Application
{
    using MediatorExampleApp.Models;
    using MediatR;
    public class DbServiceQuery : IRequest<DbServiceResponse>
    {
        public DbServiceQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
