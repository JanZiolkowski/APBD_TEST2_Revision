using System.ComponentModel.DataAnnotations;

namespace Test2_Mock.Model;

public class ReservationDTO
{
    [Required]
    public int IdClient { get; set; }
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
    [Required]
    public int IdBoatStandard { get; set; }
    [Required]
    public int NumOfBoats { get; set; }
}