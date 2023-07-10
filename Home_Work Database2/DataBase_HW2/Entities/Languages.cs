using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2.Entities
{
    public class Languages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Language_groupId { get; set; }
        public virtual Language_group Language_group { get; set; }
        public virtual List<Countries_Languages> Countries_Languages { get; set; } = new List<Countries_Languages>();
    }
}
