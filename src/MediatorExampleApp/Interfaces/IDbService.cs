namespace MediatorExampleApp.Interfaces
{
    using MediatorExampleApp.Models;

    public interface IDbService
    {
        DbServiceResponse Work(DbServiceResponse dat);
    }
}
