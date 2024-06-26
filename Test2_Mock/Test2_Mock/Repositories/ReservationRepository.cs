﻿using Microsoft.EntityFrameworkCore;
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
        return await _databaseContext.Reservations.Include(x => x.BoatStandard).Include(r => r.SailboatReservations).ThenInclude(sr => sr.Sailboat).Where(x => x.IdClient == idClient).OrderByDescending(x => x.DateTo).ToListAsync();
    }

    public async Task<int> GetNumberOfCurrentReservations(int idClient)
    {
        return  await _databaseContext.Reservations.CountAsync(x => x.IdClient == idClient && x.DateTo > DateTime.Now);
    }

    public async Task SaveReservation(Reservation reservation)
    {
        await _databaseContext.Reservations.AddAsync(reservation);
        await _databaseContext.SaveChangesAsync();
    }
}