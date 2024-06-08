using System.ComponentModel.DataAnnotations;

namespace Test2_Mock.Entities;

public class Client
{
    public int IdClient { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    [MaxLength(100)]
    public string Pesel { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    public int IdClientCategory { get; set; }
    public virtual ClientCategory ClientCategory { get; }
    public virtual ICollection<Reservation> Reservations { get; }
}