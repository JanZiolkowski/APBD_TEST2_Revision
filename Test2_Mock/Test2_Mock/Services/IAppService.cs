using Test2_Mock.Entities;
using Test2_Mock.Model;

namespace Test2_Mock.Services;

public interface IAppService
{
    public Task<object> GetReservations(int idClient);
    public Task<int> AddReservation(ReservationDTO reservationDto);
    public ICollection<Client> GetClients();
}