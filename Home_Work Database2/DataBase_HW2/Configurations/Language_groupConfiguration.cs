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
    public class Language_groupConfiguration : IEntityTypeConfiguration<Language_group>
    {
        public void Configure(EntityTypeBuilder<Language_group> builder)
        {
            builder.ToTable("Language_group").HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);            
            
            builder.HasData(new List<Language_group>()
            {
                new Language_group() { Id = 1, Name = "Indo-European"},
                new Language_group() { Id = 2, Name = "Arabic"},
                new Language_group() { Id = 3, Name = "Turkic"}
            });
        }
    }
}
