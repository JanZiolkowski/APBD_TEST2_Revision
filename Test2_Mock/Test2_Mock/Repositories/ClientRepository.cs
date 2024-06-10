using Microsoft.EntityFrameworkCore;
using Test2_Mock.Context;
using Test2_Mock.Entities;

namespace Test2_Mock.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DatabaseContext _databaseContext;

    public ClientRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Client?> RetrieveClient(int idClient)
    {
        //I have to use Include to indicate what object to request additionaly from database
        return await _databaseContext.Clients.Include(c => c.ClientCategory).Where(x => x.IdClient == idClient).FirstOrDefaultAsync();
    }

    public ICollection<Client> GetClients()
    {
        return _databaseContext.Clients.ToList();
    }
}