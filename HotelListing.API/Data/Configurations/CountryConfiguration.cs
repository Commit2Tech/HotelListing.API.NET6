using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
