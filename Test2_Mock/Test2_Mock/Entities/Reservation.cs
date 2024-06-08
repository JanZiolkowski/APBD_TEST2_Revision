using System.ComponentModel.DataAnnotations;

namespace Test2_Mock.Entities;

public class Reservation
{
    public int IdReservation{ get; set; }
    public int IdClient{ get; set; }
    [Required]
    public DateTime DateFrom{ get; set; }
    [Required]
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    [Required]
    public int NumOfBoats { get; set; }
    [Required]
    public bool Fulfilled { get; set; }
    //TODO: money type???
    public double? Price { get; set; }
    [MaxLength(200)]
    public string? CancelReason { get; set; }

    public virtual BoatStandard BoatStandard { get; }
    public virtual Client Client { get; }
    public virtual ICollection<SailboatReservation> SailboatReservations { get; }

}