// <auto-generated />
using CarRegistration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRegistration.Migrations
{
    [DbContext(typeof(CarRegistrationContext))]
    [Migration("20221125151636_AddBrandModel")]
    partial class AddBrandModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CarRegistration.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CarManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarManufacturerId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarRegistration.CarManufacturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FoundingYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CarManufacturers");
                });

            modelBuilder.Entity("CarRegistration.Brand", b =>
                {
                    b.HasOne("CarRegistration.CarManufacturer", "CarManufacturer")
                        .WithMany("Brand")
                        .HasForeignKey("CarManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarManufacturer");
                });

            modelBuilder.Entity("CarRegistration.CarManufacturer", b =>
                {
                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
