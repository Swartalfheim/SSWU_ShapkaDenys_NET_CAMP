using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class NewArray
    {
        public IEnumerable<int> NewNumbers(params int[][] mas)
        {
            List<int> numbers = new List<int>();
            foreach (var item in mas)
            {
                numbers.AddRange(item);
            }

            numbers.Sort();

            foreach (var item in numbers)
            {
                yield return item;
            }
        }
    }
}
