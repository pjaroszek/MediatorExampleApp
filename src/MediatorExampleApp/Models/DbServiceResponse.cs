namespace MediatorExampleApp.Models
{
    public sealed class DbServiceResponse : IDbServiceResponse
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
