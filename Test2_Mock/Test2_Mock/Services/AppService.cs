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
            ClientCategory = client.ClientCategory.Name,
            Reservations = reservations.Select( r => new
            {
                IdReservation = r.IdReservation,
                DateFrom = r.DateFrom,
                DateTo = r.DateTo,
                BoatStandard = r.BoatStandard.Name,
                Capacity = r.Capacity,
                NumberOfBoats = r.NumOfBoats,
                Fulfilled = r.Fulfilled,
                Price = r.Price,
                CancelReason = r.CancelReason,
                ListOfBoats = r.SailboatReservations.Select(x => x.Sailboat.Name)
                //I can use here this Select statement because when I was retrieving data from the database I used Include and ThenInclude
            })
        };

        return returnObject;
    }

    public ICollection<Client> GetClients()
    {
        return _clientRepository.GetClients();
    }
}