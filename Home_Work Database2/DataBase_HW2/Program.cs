using DataBase_HW2.Entities;

namespace DataBase_HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DbManager manager = new DbManager(db);
                Console.WriteLine("TABLE CONTENTS (JOINED BY LAZY LOADING):\n");                
                var query = db.Countries.Select(
                    a => new
                    {
                        a.Id,
                        a.Name,
                        a.Population,
                        a.Area
                    });
                
                foreach (var item in query)
                {
                    Console.WriteLine(
                        $"Id: {item.Id}\n" +
                        $"Name: {item.Name}\n" +
                         $"Population: {item.Name}\n" +
                          $"Area: {item.Name}\n" );
                }
                
                Console.WriteLine("ADDING AN ITEM TO Languages (BEFORE):\n");
                foreach (Languages languages in db.Languages)
                {
                    Console.WriteLine($"Id: {languages.Id}, Name:{languages.Name}");
                }
                manager.Add(new Languages() { Name = "Tadjic" });
                Console.WriteLine("\nADDING AN ITEM TO Languages (AFTER):\n");
                foreach (Languages languages in db.Languages)
                {
                    Console.WriteLine($"Id: {languages.Id}, Name: {languages.Name}");
                }

                Console.WriteLine("\nMODIFYING AN ITEM IN Countries_Languages TYPES (BEFORE):\n");
                foreach (Countries_Languages countries_Languages in db.Countries_Languages)
                {
                    Console.WriteLine($"Id: {countries_Languages.Id}, CountriesId: {countries_Languages.CountriesId}, LanguagesId:{countries_Languages.LanguagesId}");
                }
                manager.Modify(new Countries_Languages() { Id = 10, CountriesId = 3,LanguagesId=2 });
                Console.WriteLine("\nMODIFYING AN ITEM IN Countries_Languages TYPES (AFTER):\n");
                foreach (Countries_Languages countries_Languages in db.Countries_Languages)
                {
                    Console.WriteLine($"Id: {countries_Languages.Id}, CountriesId: {countries_Languages.CountriesId}, LanguagesId:{countries_Languages.LanguagesId}");
                }

                Console.WriteLine("\nREMOVING AN ITEM IN COUNTRIES (BEFORE):\n");
                foreach (Countries countries in db.Countries)
                {
                    Console.WriteLine($"Id: {countries.Id}, Name: {countries.Name}");
                }
                manager.RemoveCountries(4);
                Console.WriteLine("\nREMOVING AN ITEM IN COUNTRIES (AFTER):\n");
                foreach (Countries countries in db.Countries)
                {
                    Console.WriteLine($"Id: {countries.Id}, Name: {countries.Name}");
                }
                
            }
        }
    }
}