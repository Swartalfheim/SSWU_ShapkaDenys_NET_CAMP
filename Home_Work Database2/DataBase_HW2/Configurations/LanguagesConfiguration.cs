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
    public class LanguagesConfiguration : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            builder.ToTable("Languages").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(a => a.Language_group).WithMany(c => c.Languages).HasForeignKey(a => a.Language_groupId).OnDelete(DeleteBehavior.Cascade);
           
            builder.HasData(new List<Languages>()
            {
                new Languages() {
                    Id = 1,
                    Name = "English",
                    Language_groupId = 1                    
                },
                new Languages() {
                    Id = 2,
                    Name = "Azerbaijani",
                    Language_groupId = 3
                },
                new Languages() {
                    Id = 3,
                    Name = "German",
                    Language_groupId = 1
                },
                new Languages() {
                    Id = 4,
                    Name = "Maghreb",
                    Language_groupId = 2
                },
                new Languages() {
                    Id = 5,
                    Name = "Turkish",
                    Language_groupId = 3
                }
            });
        }
    }
}
