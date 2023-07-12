using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M4HW3.Configurats;

namespace M4HW3
{
    public class DBManager
    {
        private ApplicationContext _db;
        public DBManager(ApplicationContext db)
        {
            _db = db;
        }
        public void Add(Countries countries)
        {
            _db.Countries.Add(countries);
            _db.SaveChanges();
        }
        public void Modify(Countries countries)
        {
            Countries? target = _db.Countries.Find(countries.CountriesId);
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
        public void Add(CountriesLanguages countries_Languages)
        {
            _db.CountriesLanguages.Add(countries_Languages);
            _db.SaveChanges();
        }
        public void Modify(CountriesLanguages countries_Languages)
        {
            CountriesLanguages? target = _db.CountriesLanguages.Find(countries_Languages.CountriesLanguagesId);
            if (target != null)
            {
                target.CountriesId = countries_Languages.CountriesId;
                target.LanguagesId = countries_Languages.LanguagesId;
                _db.SaveChanges();
            }
        }
        public void RemoveCountries_Languages(int id)
        {
            CountriesLanguages? target = _db.CountriesLanguages.Find(id);
            if (target != null)
            {
                _db.CountriesLanguages.Remove(target);
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
            Languages? target = _db.Languages.Find(languages.LanguagesId);
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
        public void Add(Languagegroup language_Group)
        {
            _db.Languagegroup.Add(language_Group);
            _db.SaveChanges();
        }
        public void Modify(Languagegroup language_Group)
        {
            Languagegroup? target = _db.Languagegroup.Find(language_Group.LanguagegroupId);
            if (target != null)
            {
                target.Name = language_Group.Name;
                _db.SaveChanges();
            }
        }
        public void RemoveLanguage_group(int id)
        {
            Languagegroup? target = _db.Languagegroup.Find(id);
            if (target != null)
            {
                _db.Languagegroup.Remove(target);
                _db.SaveChanges();
            }
        }
    }
}
