namespace Test2_Mock.Entities;

public class SailboatReservation
{
    public int IdSailboat { get; set; }
    public int IdReservation { get; set; }
    public virtual Sailboat Sailboat { get; }
    public virtual Reservation Reservation { get; }
}