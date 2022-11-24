using System.ComponentModel.DataAnnotations;

namespace CarRegistration;

public class CarManufacturer
{
    public int CarManufacturerId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Brand { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public int FoundingYear { get; set; }
}
