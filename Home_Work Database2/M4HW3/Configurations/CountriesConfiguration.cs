using M4HW3.Configurats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M4HW3.Configurations
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder.ToTable("Countries").HasKey(p => p.CountriesId);
            builder.Property(p => p.CountriesId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Population).IsRequired();
            builder.Property(p => p.Area).IsRequired();

            builder.HasData(new List<Countries>()
            {
                new Countries() { CountriesId = 1, Name = "England", Population = 53000000, Area = 130279 },
                new Countries() { CountriesId = 2, Name = "USA", Population = 350000000, Area = 9834000 },
                new Countries() { CountriesId = 3, Name = "Azerbaijan", Population = 10000000, Area = 86600 },
                new Countries() { CountriesId = 4, Name = "Germany", Population = 83000000, Area = 357588 },
                new Countries() { CountriesId = 5, Name = "Austria", Population = 8956000, Area = 83871 },
                new Countries() { CountriesId = 6, Name = "Tunisia", Population = 12260000, Area = 163610 },
                new Countries() { CountriesId = 7, Name = "Libyya", Population = 6735000, Area = 1760000 },
                new Countries() { CountriesId = 8, Name = "Turkey", Population = 84780000, Area = 783562 }
            });
        }
    }
}
