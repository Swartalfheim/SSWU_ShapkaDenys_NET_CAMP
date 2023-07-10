using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_HW2.Entities
{
    public class Language_group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Languages> Languages { get; set; } = new List<Languages>();
    }
}
