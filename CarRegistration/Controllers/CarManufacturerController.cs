using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class CarManufacturerController : ControllerBase
{
    private static readonly string[] Brands = new[]
    {
        "VW", "Audi", "Skoda", "Mercedes-Benz"
    };

    private CarManufacturerContext _context;
    private readonly ILogger<CarManufacturerController> _logger;

    public CarManufacturerController(ILogger<CarManufacturerController> logger)
    {
        _context = new CarManufacturerContext();
        _logger = logger;
    }

    [HttpGet]
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CarManufacturer manufacturer)
    {
        _context.Add(manufacturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = manufacturer.CarManufacturerId }, manufacturer);
    }

    // [HttpGet(Name = "{id}")]
    // public void Read()

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Update(int id, [FromBody] CarManufacturer manufacturer)
    {
        manufacturer.CarManufacturerId = id;
        _context.Update(manufacturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = manufacturer.CarManufacturerId }, manufacturer);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var manufacturer = await _context.CarManufacturers.FindAsync(id);

        if (manufacturer is null) {
            return NotFound();
        }

        _context.CarManufacturers.Remove(manufacturer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
