using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using M4HW3.Configurats;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace M4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                DBManager manager = new DBManager(db);
                var query = db.Countries.Select(
                    a => new
                    {
                        a.CountriesId,
                        a.Name,
                        a.Population,
                        a.Area
                    });
                Console.WriteLine("Output of all information about countries: \n");
                foreach (var item in query)
                {
                    Console.WriteLine(
                        $"Id: {item.CountriesId}\n" +
                        $"Name: {item.Name}\n" +
                         $"Population: {item.Population}\n" +
                          $"Area: {item.Area}\n");
                }
                Console.WriteLine("Output of all languages of the Turkic language group: \n");
                var users = db.Languages.FromSqlRaw("Select * From [dbo].[Languages] where [dbo].[Languages].LanguagegroupId = 3").ToList();
                foreach (var item in users)
                {
                    Console.WriteLine($"Name {item.Name}");
                }
                manager.Add(new Languagegroup() { Name = "S" });
                manager.Modify(new Languagegroup() { LanguagegroupId = 2, Name = "fxgh" });
                var query2 = db.Languagegroup.Select(
                    a => new
                    {
                        a.LanguagegroupId,
                        a.Name
                    });
                Console.WriteLine("Output of changed and added language groups: \n");
                foreach (var item in query2)
                {
                    Console.WriteLine(
                        $"Id: {item.LanguagegroupId}\n" +
                        $"Name: {item.Name}\n");
                }
                manager.RemoveCountries(3);
                var query1 = db.Countries.Select(
                    a => new
                    {
                        a.CountriesId,
                        a.Name,
                        a.Population,
                        a.Area
                    });
                Console.WriteLine("Output of all Countries without removing: \n");
                foreach (var item in query1)
                {
                    Console.WriteLine(
                        $"Id: {item.CountriesId}\n" +
                        $"Name: {item.Name}\n" +
                         $"Population: {item.Population}\n" +
                          $"Area: {item.Area}\n");
                }
            }
        }
    }
}