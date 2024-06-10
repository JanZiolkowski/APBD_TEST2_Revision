using Test2_Mock.Entities;
using Test2_Mock.Exceptions;
using Test2_Mock.Repositories;

namespace Test2_Mock.Services;

public class AppService : IAppService
{
    private IClientRepository _clientRepository;
    private IReservationRepository _reservationRepository;

    public AppService(IClientRepository clientRepository, IReservationRepository reservationRepository)
    {
        _clientRepository = clientRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<object> GetReservations(int idClient)
    {
        Client? client = await _clientRepository.RetrieveClient(idClient);

        if (client == null)
        {
            throw new NotFoundException("The Client with given Id has not been found in database!");
        }

        List<Reservation> reservations = await _reservationRepository.GetReservationOfClient(idClient);

        var returnObject = new
        {
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Pesel = client.Pesel,
            Email = client.Email,
            ClientCategory = client.ClientCategory,
            Reservations = reservations
        };

        return returnObject;
    }

    public ICollection<Client> GetClients()
    {
        return _clientRepository.GetClients();
    }
}