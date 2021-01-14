namespace MediatorExampleApp.Interfaces
{
    using System.Collections.Generic;
    using MediatorExampleApp.Models;

    public interface IDbService
    {
        DbServiceResponse Work(DbServiceResponse dat);
        void AddUser(DbServiceResponse item);

        List<DbServiceResponse> GetAllUser();

        void DeleteItem(string name);
    }
}
