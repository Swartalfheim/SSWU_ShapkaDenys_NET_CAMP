using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_1
{
    public class Print_Info
    {
        private int[] _array;
        public Print_Info(int[] array)
        {
            _array = array;
        }

        public void Print()
        {
            Console.WriteLine("Quick sort by first element:");
            QuickSort_First<int>.Sort(_array, (a, b) => a.CompareTo(b));
            foreach (var item in _array)
            {
                Console.Write($"{item}; ");
            }

            Console.WriteLine();
            Console.WriteLine("\nQuick sort by median element:");
            QuickSort_Median<int>.Sort(_array, (a, b) => a.CompareTo(b));
            foreach (var item in _array)
            {
                Console.Write($"{item}; ");
            }

            Console.WriteLine();
            Console.WriteLine("\nQuick sort by random element:");
            QuickSort_Random<int>.Sort(_array, (a, b) => a.CompareTo(b));
            foreach (var item in _array)
            {
                Console.Write($"{item}; ");
            }
        }
    }
}
