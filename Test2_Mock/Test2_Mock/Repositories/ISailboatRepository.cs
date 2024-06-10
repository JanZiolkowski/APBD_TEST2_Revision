using Test2_Mock.Entities;
using Test2_Mock.Model;

namespace Test2_Mock.Repositories;

public interface ISailboatRepository
{
    public Task<List<Sailboat>> ReturnBoatsHigherStandard(ReservationDTO reservationDto);
    public Task<List<Sailboat>> ReturnBoatsEqual(ReservationDTO reservationDto);
}