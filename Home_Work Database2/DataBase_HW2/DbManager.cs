using DataBase_HW2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2
{
    public class DbManager
    {
        private ApplicationContext _db;
        public DbManager(ApplicationContext db)
        {
            _db = db;
        }

        // not dummy-proof, no cloning
        public void Add(Countries countries)
        {
            _db.Countries.Add(countries);
            _db.SaveChanges();
        }
        public void Modify(Countries countries)
        {
            Countries? target = _db.Countries.Find(countries.Id);
            if (target != null)
            {
                target.Name = countries.Name;
                target.Population = countries.Population;
                target.Area = countries.Area;                
                _db.SaveChanges();
            }
        }
        public void RemoveCountries(int id)
        {
            Countries? target = _db.Countries.Find(id);
            if (target != null)
            {
                _db.Countries.Remove(target);
                _db.SaveChanges();
            }
        }
        public void Add(Countries_Languages countries_Languages)
        {
            _db.Countries_Languages.Add(countries_Languages);
            _db.SaveChanges();
        }
        public void Modify(Countries_Languages countries_Languages)
        {
            Countries_Languages? target = _db.Countries_Languages.Find(countries_Languages.Id);
            if (target != null)
            {
                target.CountriesId = countries_Languages.CountriesId;
                target.LanguagesId= countries_Languages.LanguagesId;
                _db.SaveChanges();
            }
        }
        public void RemoveCountries_Languages(int id)
        {
            Countries_Languages? target = _db.Countries_Languages.Find(id);
            if (target != null)
            {
                _db.Countries_Languages.Remove(target);
                _db.SaveChanges();
            }
        }
        public void Add(Languages languages)
        {
            _db.Languages.Add(languages);
            _db.SaveChanges();
        }
        public void Modify(Languages languages)
        {
            Languages? target = _db.Languages.Find(languages.Id);
            if (target != null)
            {
                target.Name = languages.Name;
                _db.SaveChanges();
            }
        }
        public void RemoveLanguages(int id)
        {
            Languages? target = _db.Languages.Find(id);
            if (target != null)
            {
                _db.Languages.Remove(target);
                _db.SaveChanges();
            }
        }
        public void Add(Language_group language_Group)
        {
            _db.Language_group.Add(language_Group);
            _db.SaveChanges();
        }
        public void Modify(Language_group language_Group)
        {
            Language_group? target = _db.Language_group.Find(language_Group.Id);
            if (target != null)
            {
                target.Name = language_Group.Name;
                _db.SaveChanges();
            }
        }
        public void RemoveLanguage_group(int id)
        {
            Language_group? target = _db.Language_group.Find(id);
            if (target != null)
            {
                _db.Language_group.Remove(target);
                _db.SaveChanges();
            }
        }
    }
}
