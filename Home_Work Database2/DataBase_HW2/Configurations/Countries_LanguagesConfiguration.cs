using DataBase_HW2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2.Configurations
{
    public class Countries_LanguagesConfiguration : IEntityTypeConfiguration<Countries_Languages>
    {
        public void Configure(EntityTypeBuilder<Countries_Languages> builder)
        {
            builder.ToTable("Countries_Languages").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();            
            builder.HasOne(a => a.Countries).WithMany(c => c.Countries_Languages).HasForeignKey(a => a.CountriesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Languages).WithMany(m => m.Countries_Languages).HasForeignKey(a => a.LanguagesId).OnDelete(DeleteBehavior.Cascade);
            

            builder.HasData(new List<Countries_Languages>()
            {
                new Countries_Languages() {
                    Id = 1,
                    CountriesId= 1,
                    LanguagesId= 1,
                },
                new Countries_Languages() {
                    Id = 2,
                    CountriesId= 2,
                    LanguagesId= 1,
                },
                new Countries_Languages() {
                    Id = 3,
                    CountriesId= 3,
                    LanguagesId= 2,
                },
                new Countries_Languages() {
                    Id = 4,
                    CountriesId= 4,
                    LanguagesId= 3,
                },
                new Countries_Languages() {
                    Id = 5,
                    CountriesId= 5,
                    LanguagesId= 3,
                },
                new Countries_Languages() {
                    Id = 6,
                    CountriesId= 6,
                    LanguagesId= 4,
                },
                new Countries_Languages() {
                    Id = 7,
                    CountriesId= 7,
                    LanguagesId= 4,
                },
                new Countries_Languages() {
                    Id = 8,
                    CountriesId= 8,
                    LanguagesId= 5,
                },
                new Countries_Languages() {
                    Id = 9,
                    CountriesId= 3,
                    LanguagesId= 5,
                }
            });
        }
    }
}
