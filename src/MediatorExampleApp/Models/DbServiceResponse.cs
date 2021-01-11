using MediatorExampleApp.Application;

namespace MediatorExampleApp.Models
{
    public sealed class DbServiceResponse : IDbServiceResponse
    {
        public DbServiceResponse()
        {
        }
        public DbServiceResponse(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }

        public string Surname { get; set; }

        public static implicit operator AddUserCommand(DbServiceResponse user)
        {
            return new AddUserCommand(user.Name, user.Surname);
        }

    }
}
