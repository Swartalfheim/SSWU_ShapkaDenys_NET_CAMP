using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PrintInfo
    {
        private NewArray _newArray;
        public void Print()
        {
            _newArray = new NewArray();
            int[] a = new int[5] { 1, 2, 5, 6, 7 };
            int[] b = new int[5] { 9, 8, 5, 1, 3 };
            int[] c = new int[5] { 9, 6, 4, 2, 5 };
            foreach (var item in _newArray.NewNumbers(a, b, c))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
