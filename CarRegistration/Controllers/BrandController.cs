using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class BrandController : ControllerBase
{
    private CarRegistrationContext _context;
    private readonly ILogger<BrandController> _logger;

    public BrandController(ILogger<BrandController> logger)
    {
        _context = new CarRegistrationContext();
        _logger = logger;
    }

    // CRUD
    // ------------------------------------

    // Create
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Brand brand)
    {
        _context.Add(brand);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = brand.Id }, brand);
    }

    // Read
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Brand> Read()
    {
        return _context.Brands.ToList().Select(brand => brand = FillBrand(brand));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Read(long id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand is null) {
            return NotFound();
        }

        brand = FillBrand(brand);

        return Ok(brand);
    }

    // Update
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Update(long id, [FromBody] Brand brand)
    {
        brand.Id = id;
        _context.Update(brand);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = brand.Id }, brand);
    }

    // Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand is null) {
            return NotFound();
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ------------------------------------

    private Brand FillBrand(Brand brand)
    {
        var manufacturer = _context.CarManufacturers.Find(brand.CarManufacturerId);

        if (manufacturer is not null) {
            brand.CarManufacturer = manufacturer;
            brand.CarManufacturer.Brand = null;
        }

        return brand;
    }
}
