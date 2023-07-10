using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2.Entities
{
    public class Countries_Languages
    {
        public int Id { get; set; }
        public int CountriesId { get; set; }
        public virtual Countries Countries { get; set; }
        public int LanguagesId { get; set; }
        public virtual Languages Languages { get; set; }
    }
}
