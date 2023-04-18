using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrangementOfTrees
    {
        private List<int[]> _arr;

        public List<int[]> Arrangement()
        {
            _arr = new List<int[]>()
           {
               new int[] { 1, 3 },
               new int[] { 1, 7 },
               new int[] { 2, 1 },
               new int[] { 3, 4 },
               new int[] { 5, 1 },
               new int[] { 5, 6 },
               new int[] { 5, 8 },
               new int[] { 6, 4 },
               new int[] { 8, 2 },
               new int[] { 9, 5 }
           };
            return _arr;
        }
    }
}
