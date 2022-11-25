using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class CarManufacturerController : ControllerBase
{
    private CarRegistrationContext _context;
    private readonly ILogger<CarManufacturerController> _logger;

    public CarManufacturerController(ILogger<CarManufacturerController> logger)
    {
        _context = new CarRegistrationContext();
        _logger = logger;
    }

    // CRUD
    // ------------------------------------

    // Create
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CarManufacturer manufacturer)
    {
        _context.Add(manufacturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = manufacturer.Id }, manufacturer);
    }

    // Read
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<CarManufacturer> Read()
    {
        return _context.CarManufacturers.ToList();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Read(long id)
    {
        var manufacturer = await _context.CarManufacturers.FindAsync(id);

        if (manufacturer is null) {
            return NotFound();
        }

        return Ok(manufacturer);
    }

    // Update
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Update(long id, [FromBody] CarManufacturer manufacturer)
    {
        manufacturer.Id = id;
        _context.Update(manufacturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = manufacturer.Id }, manufacturer);
    }

    // Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
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
