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
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder.ToTable("Language_group").HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Population).IsRequired();
            builder.Property(m => m.Area).IsRequired();



            builder.HasData(new List<Countries>()
            {
                new Countries() { Id = 1, Name = "England", Population=53000000, Area=130279},
                new Countries() { Id = 2, Name = "USA", Population=350000000, Area=9834000},
                new Countries() { Id = 3, Name = "Azerbaijan", Population=10000000, Area=86600},
                new Countries() { Id = 4, Name = "Germany", Population=83000000, Area=357588},
                new Countries() { Id = 5, Name = "Austria", Population=8956000, Area=83871},
                new Countries() { Id = 6, Name = "Tunisia", Population=12260000, Area=163610},
                new Countries() { Id = 7, Name = "Libyya", Population=6735000, Area=1760000},
                new Countries() { Id = 8, Name = "Turkey", Population=84780000, Area=783562}
            });
        }
    }
}
