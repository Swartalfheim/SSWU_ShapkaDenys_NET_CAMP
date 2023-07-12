using M4HW3.Configurats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M4HW3.Configurations
{
    public class CountriesLanguagesConfiguration : IEntityTypeConfiguration<CountriesLanguages>
    {
        public void Configure(EntityTypeBuilder<CountriesLanguages> builder)
        {
            builder.ToTable("CountriesLanguages").HasKey(e => e.CountriesLanguagesId);
            builder.Property(e => e.CountriesLanguagesId).ValueGeneratedOnAdd();
            builder.HasOne(e => e.Languages)
                .WithMany(e => e.CountriesLanguages)
                .HasForeignKey(e => e.LanguagesId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Countries)
                .WithMany(e => e.CountriesLanguages)
                .HasForeignKey(e => e.CountriesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<CountriesLanguages>()
            {
                new CountriesLanguages() {
                    CountriesLanguagesId = 1,
                    CountriesId = 1,
                    LanguagesId = 1
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 2,
                    CountriesId = 2,
                    LanguagesId = 1
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 3,
                    CountriesId = 3,
                    LanguagesId = 2
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 4,
                    CountriesId = 4,
                    LanguagesId = 3
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 5,
                    CountriesId = 5,
                    LanguagesId = 3
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 6,
                    CountriesId = 6,
                    LanguagesId = 4
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 7,
                    CountriesId = 7,
                    LanguagesId = 4
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 8,
                    CountriesId = 8,
                    LanguagesId = 5
                },
                new CountriesLanguages() {
                    CountriesLanguagesId = 9,
                    CountriesId = 3,
                    LanguagesId = 5
                }
            });
        }
    }
}
