using System.ComponentModel.DataAnnotations;

namespace CarRegistration;

public class Car
{
    public long Id { get; set; }

    public long MakeId { get; set; }

    [Required]
    public Brand Make { get; set; } = null!;

    [Required]
    public string Model { get; set; } = null!;

    [Required]
    public string VIN { get; set; } = null!; // 17 characters (digits and capital letters)

    [Required]
    public string LicensePlate { get; set; } = null!;

    public DateTime InitialRegistrationDate { get; set; }

    public int Power { get; set; }

    [Required]
    public string BodyType { get; set; } = null!;
    
    [Required]
    public string Color { get; set; } = null!;
}
