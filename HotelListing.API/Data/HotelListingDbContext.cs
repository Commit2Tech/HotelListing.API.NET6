using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1, 
                    Name = "India",
                    ShortName = "In"
                },
                new Country
                {
                    Id = 2,
                    Name = "Sri Lanka",
                    ShortName = "SL"
                },
                new Country
                {
                    Id = 3,
                    Name = "United States Of America",
                    ShortName = "USA"
                },
                new Country
                {
                    Id = 4,
                    Name = "United Kindom",
                    ShortName = "UK"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Taj Palace",
                    Address = "Mumbai",
                    CountryId = 1,
                    Rating = 5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sandal Resort and Spa",
                    Address = "Negril",
                    CountryId = 2,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palladium",
                    Address = "Las Vegas",
                    CountryId = 3,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Comfort Suits",
                    Address = "Brighton",
                    CountryId = 4,
                    Rating = 4.5
                }
                );
        }
    }
}
