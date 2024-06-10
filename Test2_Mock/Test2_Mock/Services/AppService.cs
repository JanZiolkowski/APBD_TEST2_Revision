using Test2_Mock.Context;
using Test2_Mock.Entities;
using Test2_Mock.Exceptions;
using Test2_Mock.Model;
using Test2_Mock.Repositories;

namespace Test2_Mock.Services;

public class AppService : IAppService
{
    private IClientRepository _clientRepository;
    private IReservationRepository _reservationRepository;
    private ISailboatRepository _sailboatRepository;
    //HERE I INCLUDE DATABASE CONTEXT BECAUSE I DONT KNOW HOW TO SEPARATE THE REPOSITORIES
    private DatabaseContext _databaseContext;
    
    public AppService(IClientRepository clientRepository, IReservationRepository reservationRepository, ISailboatRepository sailboatRepository,DatabaseContext databaseContext)
    {
        _clientRepository = clientRepository;
        _reservationRepository = reservationRepository;
        _sailboatRepository = sailboatRepository;
        
        _databaseContext = databaseContext;
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

    public async Task<int> AddReservation(ReservationDTO reservationDto)
    {
        //Here I will implement checks:
        var activeReservations =  await _reservationRepository.GetNumberOfCurrentReservations(reservationDto.IdClient);
        if (activeReservations > 0)
        {
            throw new BadRequestException("The client has an reservation which is still active!");
        }
        
        var Reservation = new Reservation()
        {
            IdClient = reservationDto.IdClient,
            DateFrom = reservationDto.DateFrom,
            DateTo = reservationDto.DateTo,
            IdBoatStandard = reservationDto.IdBoatStandard,
            NumOfBoats = reservationDto.NumOfBoats,
            Fulfilled = false,
            Capacity = 10
        };

        var listOfStandardSailboats = await _sailboatRepository.ReturnBoatsEqual(reservationDto);
        var listOfHigherSailboats = await _sailboatRepository.ReturnBoatsHigherStandard(reservationDto);
        
        if (listOfStandardSailboats.Count < reservationDto.NumOfBoats)
        {
            if (listOfStandardSailboats.Count + listOfHigherSailboats.Count >= reservationDto.NumOfBoats)
            {
                
            }
            else
            {
                Reservation.CancelReason = "There was not enough bots for the Reservation";
                
                await _databaseContext.Reservations.AddAsync(Reservation);
                await _databaseContext.SaveChangesAsync();
                throw new BadRequestException("Not enough available sailboats");
                
            }
            
        }
        


        return 0;
    }

    public ICollection<Client> GetClients()
    {
        return _clientRepository.GetClients();
    }
}