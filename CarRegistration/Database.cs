using Microsoft.EntityFrameworkCore;

namespace CarRegistration;

public class CarRegistrationContext : DbContext
{
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<CarManufacturer> CarManufacturers { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;

    public string DbPath { get; }

    public CarRegistrationContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "car-registration.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}