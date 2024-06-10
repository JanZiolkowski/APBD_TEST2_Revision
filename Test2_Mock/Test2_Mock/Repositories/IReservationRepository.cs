using Test2_Mock.Entities;

namespace Test2_Mock.Repositories;

public interface IReservationRepository
{
    public Task<List<Reservation>> GetReservationOfClient(int idClient);
    public Task<int> GetNumberOfCurrentReservations(int idClient);
}