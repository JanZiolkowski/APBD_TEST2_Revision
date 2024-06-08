using System.ComponentModel.DataAnnotations;

namespace Test2_Mock.Entities;

public class ClientCategory
{
    [Key]
    public int IdClientCategory{ get; set; }
    [Required]
    [MaxLength(100)]
    public string Name{ get; set; }
    [Required]
    public int DiscountPerc{ get; set; }
    public virtual ICollection<Client> Clients { get; }
}