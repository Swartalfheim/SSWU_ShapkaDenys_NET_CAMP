using M4HW3.Configurations;
using M4HW3.Configurats;
using Microsoft.EntityFrameworkCore;

namespace M4HW3
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Languagegroup> Languagegroup { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<CountriesLanguages> CountriesLanguages { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguagesConfiguration());
            modelBuilder.ApplyConfiguration(new LanguagegroupConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesLanguagesConfiguration());
        }
    }
}
