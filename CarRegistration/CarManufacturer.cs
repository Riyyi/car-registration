using System.ComponentModel.DataAnnotations;

namespace CarRegistration;

public class CarManufacturer
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public ICollection<Brand>? Brand { get; set; }

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public int FoundingYear { get; set; }
}
