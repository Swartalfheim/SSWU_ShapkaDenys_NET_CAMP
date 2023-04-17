using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArrangementOfTrees
    {
        private List<int> _arr;

        public List<int> Arrangement()
        {
            _arr = new List<int>();
            Random rnd = new Random(new Random().Next());
            for (int i = 0; i < 10; i++)
            {
                int j = rnd.Next(10, 100);
                while (_arr.Contains(j))
                {
                    j = rnd.Next(10, 100);
                }

                _arr.Add(j);
            }

            return _arr;
        }
    }
}
