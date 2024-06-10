using Test2_Mock.Entities;

namespace Test2_Mock.Repositories;

public interface IClientRepository
{
    public Task<Client?> RetrieveClient(int IdClient);
    public ICollection<Client> GetClients();
}
