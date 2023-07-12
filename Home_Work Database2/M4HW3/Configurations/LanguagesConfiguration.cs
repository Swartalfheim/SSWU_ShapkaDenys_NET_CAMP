using M4HW3.Configurats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M4HW3.Configurations
{
    public class LanguagesConfiguration : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            builder.ToTable("Languages").HasKey(e => e.LanguagesId);
            builder.Property(e => e.LanguagesId).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(e => e.Languagegroup)
                .WithMany(o => o.Languages)
                .HasForeignKey(e => e.LanguagegroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Languages>()
            {
                new Languages() {
                    LanguagesId = 1,
                    Name = "English",
                    LanguagegroupId = 1
                },
                new Languages() {
                    LanguagesId = 2,
                    Name = "Azerbaijani",
                    LanguagegroupId = 3
                },
                new Languages() {
                    LanguagesId = 3,
                    Name = "German",
                    LanguagegroupId = 1
                },
                new Languages() {
                    LanguagesId = 4,
                    Name = "Maghreb",
                    LanguagegroupId = 2
                },
                new Languages() {
                    LanguagesId = 5,
                    Name = "Turkish",
                    LanguagegroupId = 3
                }
            });
        }
    }
}
