using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2.Entities
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Population {get; set; }
        public int Area { get; set; }

        public virtual List<Countries_Languages> Countries_Languages { get; set; } = new List<Countries_Languages>();
    }
}
