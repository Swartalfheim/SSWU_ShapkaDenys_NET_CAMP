using DataBase_HW2.Configurations;
using DataBase_HW2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Countries_Languages> Countries_Languages { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Language_group> Language_group { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new Countries_LanguagesConfiguration());
            modelBuilder.ApplyConfiguration(new LanguagesConfiguration());
            modelBuilder.ApplyConfiguration(new Language_groupConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
