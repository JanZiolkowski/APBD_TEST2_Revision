using System.ComponentModel.DataAnnotations;

namespace Test2_Mock.Entities;

public class BoatStandard
{
    [Key]
    public int IdBoatStandard{ get; set; }
    [MaxLength(100)]
    [Required]
    public string Name{ get; set; }
    [Required]
    public int Level { get; set; }
    public virtual ICollection<Reservation>Reservations {get;}
    public virtual ICollection<Sailboat> SailBoats {get;}
}