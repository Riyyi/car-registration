using Microsoft.EntityFrameworkCore;

namespace CarRegistration;

public class CarManufacturerContext : DbContext
{
    public DbSet<CarManufacturer> CarManufacturers { get; set; } = null!;

    public string DbPath { get; }

    public CarManufacturerContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "car-manufacturers.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}