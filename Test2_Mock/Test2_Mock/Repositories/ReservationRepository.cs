using Microsoft.EntityFrameworkCore;
using Test2_Mock.Context;
using Test2_Mock.Entities;

namespace Test2_Mock.Repositories;

public class ReservationRepository : IReservationRepository
{
    private DatabaseContext _databaseContext;

    public ReservationRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Reservation>> GetReservationOfClient(int idClient)
    {
        return await _databaseContext.Reservations.Where(x => x.IdClient == idClient).OrderByDescending(x => x.DateTo).ToListAsync();
    }
}