using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Fence
    {
        private ArrangementOfTrees _arrangementOfTrees;
        public void Treatment()
        {
            _arrangementOfTrees = new ArrangementOfTrees();
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                Console.WriteLine(item);
            }
        }
    }
}
