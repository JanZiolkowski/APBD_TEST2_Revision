namespace Test2_Mock.Entities;

public class BoatStandard
{
    public int IdBoatStandard{ get; set; }
    public string Name{ get; set; }
    public int Level { get; set; }
    public virtual ICollection<Reservation>Reservations {get;}
    public virtual ICollection<Sailboat> SailBoats {get;}
}