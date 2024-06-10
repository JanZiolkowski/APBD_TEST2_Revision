using Test2_Mock.Entities;

namespace Test2_Mock.Services;

public interface IAppService
{
    public Task<object> GetReservations(int idClient);
    public ICollection<Client> GetClients();
}