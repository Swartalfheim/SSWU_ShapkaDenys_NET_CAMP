using M4HW3.Configurats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M4HW3.Configurations
{
    public class LanguagegroupConfiguration : IEntityTypeConfiguration<Languagegroup>
    {
        public void Configure(EntityTypeBuilder<Languagegroup> builder)
        {
            builder.ToTable("Languagegroup").HasKey(t => t.LanguagegroupId);
            builder.Property(t => t.LanguagegroupId).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Languagegroup>()
            {
                new Languagegroup() { LanguagegroupId = 1, Name = "Indo-European" },
                new Languagegroup() { LanguagegroupId = 2, Name = "Arabic" },
                new Languagegroup() { LanguagegroupId = 3, Name = "Turkic" }
            });
        }
    }
}
