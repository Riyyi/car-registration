using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class CarManufacturerController : ControllerBase
{
    private static readonly string[] Brands = new[]
    {
        "VW", "Audi", "Skoda", "Mercedes-Benz"
    };

    private readonly ILogger<CarManufacturerController> _logger;

    public CarManufacturerController(ILogger<CarManufacturerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCarManufacturer")]
    public IEnumerable<CarManufacturer> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new CarManufacturer
        {
            Name = "",
            Brand = Brands[Random.Shared.Next(Brands.Length)],
            Address = "",
            PhoneNumber = "",
            FoundingYear = 1970
        })
        .ToArray();
    }
}
