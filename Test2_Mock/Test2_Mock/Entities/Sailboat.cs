namespace Test2_Mock.Entities;

public class Sailboat
{
    public int IdSailboat { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
    public int IdBoatStandard { get; set; }
    public double Price { get; set; }

    public virtual BoatStandard BoatStandard { get; }
    //this should automatically configure our relashionship
    public virtual ICollection<SailboatReservation> SailboatReservations { get; }
}