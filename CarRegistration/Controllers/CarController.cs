using Microsoft.AspNetCore.Mvc;

namespace CarRegistration.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class CarController : ControllerBase
{
    private CarRegistrationContext _context;
    private readonly ILogger<CarController> _logger;

    public CarController(ILogger<CarController> logger)
    {
        _context = new CarRegistrationContext();
        _logger = logger;
    }

    // CRUD
    // ------------------------------------

    // Create
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Car car)
    {
        _context.Add(car);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = car.Id }, car);
    }

    // Read
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Car> Read()
    {
        return _context.Cars.ToList().Select(car => FillCar(car));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Read(long id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car is null) {
            return NotFound();
        }

        car = FillCar(car);

        return Ok(car);
    }

    // Update
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Update(long id, [FromBody] Car car)
    {
        car.Id = id;
        _context.Update(car);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Read), new { id = car.Id }, car);
    }

    // Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        var car = await _context.Cars.FindAsync(id);

        if (car is null) {
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ------------------------------------

    private Car FillCar(Car car)
    {
        var brand = _context.Brands.Find(car.MakeId);

        if (brand is not null) {
            car.Make = brand;
            car.Make.CarManufacturer = null;

            var manufacturer = _context.CarManufacturers.Find(car.Make.CarManufacturerId);

            if (manufacturer is not null) {
                car.Make.CarManufacturer = manufacturer;
                car.Make.CarManufacturer.Brand = null;
            }
        }

        return car;
    }
}
