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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarManufacturer>().HasData(
            new CarManufacturer {
                Id = 1,
                Name = "Big manufacturer",
                Address = "Chinastreet 1",
                PhoneNumber = "+86-13910998888",
                FoundingYear = 1973
            }
        );

        modelBuilder.Entity<Brand>().HasData(
            new Brand {
                Id = 1,
                Name = "VW",
                CarManufacturerId = 1,
            },
            new Brand {
                Id = 2,
                Name = "Audi",
                CarManufacturerId = 1,
            },
            new Brand {
                Id = 3,
                Name = "Skoda",
                CarManufacturerId = 1,
            },
            new Brand {
                Id = 4,
                Name = "Mercedes-Benz",
                CarManufacturerId = 1,
            },
            new Brand {
                Id = 5,
                Name = "Toyota",
                CarManufacturerId = 1,
            }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car {
                Id = 1,
                MakeId = 5,
                Model = "Aygo",
                VIN = "4Y1SL65848Z411439",
                LicensePlate = "3-DGP-63",
                InitialRegistrationDate = new DateTime(2011,02,15),
                Power = 53,
                BodyType = "4-doors",
                Color = "Blue",
            }
        );
    }
}