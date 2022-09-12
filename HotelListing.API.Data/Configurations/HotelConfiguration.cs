using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
