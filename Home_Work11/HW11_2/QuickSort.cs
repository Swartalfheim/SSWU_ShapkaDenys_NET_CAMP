using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_2
{
    public class QuickSort<T>
        where T : IComparable
    {
        public static IEnumerable<T> Sort(IEnumerable<T> arr)
        {
            return Sort(arr.ToArray(), 0, arr.Count() - 1);
        }

        private static int PartitionFirst(T[] arr, int low, int high)
        {
            T pivot = arr[low]; // Опорний елемент - перший елемент масиву

            int i = low - 1;

            for (int j = low; j <= high; j++)
            {
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]); // Обмін елементів arr[j] і arr[i]
                }
            }

            (arr[low], arr[i]) = (arr[i], arr[low]); // Обмін опорного елемента з елементом arr[i]
            return i; // Повернення позиції опорного елемента
        }

        // Рекурсивне сортування масиву за допомогою опорного елемента - першого елемента
        private static IEnumerable<T> Sort(T[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionFirst(arr, low, high); // Розділення масиву і отримання позиції опорного елемента

                Sort(arr, low, pi - 1); // Рекурсивне сортування лівої частини масиву
                Sort(arr, pi + 1, high); // Рекурсивне сортування правої частини масиву
            }

            return new List<T>(arr); // Повернення відсортованого масиву у вигляді IEnumerable<T>
        }
    }
}
