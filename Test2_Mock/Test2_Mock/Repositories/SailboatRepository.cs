using Microsoft.EntityFrameworkCore;
using Test2_Mock.Context;
using Test2_Mock.Entities;
using Test2_Mock.Model;

namespace Test2_Mock.Repositories;

public class SailboatRepository : ISailboatRepository
{
    private DatabaseContext _databaseContext;

    public SailboatRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Sailboat>> ReturnBoatsEqual(ReservationDTO reservationDto)
    {
        var numOfBoats = reservationDto.NumOfBoats;

        var availableSailboats = await _databaseContext.Sailboats
            .Where(s => s.IdBoatStandard == reservationDto.IdBoatStandard && !s.SailboatReservations
                .Any(sr => sr.Reservation.DateFrom <= reservationDto.DateTo &&
                           sr.Reservation.DateTo >= reservationDto.DateFrom)
            ).ToListAsync();

        return availableSailboats;
    }
    public async Task<List<Sailboat>> ReturnBoatsHigherStandard(ReservationDTO reservationDto)
    {
        var numOfBoats = reservationDto.NumOfBoats;

        var availableSailboats = await _databaseContext.Sailboats
            .Where(s => s.IdBoatStandard > reservationDto.IdBoatStandard && !s.SailboatReservations
                .Any(sr => sr.Reservation.DateFrom <= reservationDto.DateTo &&
                           sr.Reservation.DateTo >= reservationDto.DateFrom)
            ).ToListAsync();

        return availableSailboats;

        
    }
}