using System.ComponentModel.DataAnnotations;

namespace CarRegistration;

public class Brand
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public CarManufacturer CarManufacturer { get; set; } = null!;
}
