using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_1
{
    public class QuickSort_Random<T>
    {
        private static Random random = new Random();

        public static void Sort(T[] array, Func<T, T, int> compareFunc)
        {
            if (array == null || array.Length <= 1)
            {
                return;
            }

            QuickSortRecursive(array, compareFunc, 0, array.Length - 1);
        }

        private static void QuickSortRecursive(T[] array, Func<T, T, int> compareFunc, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(array, compareFunc, left, right);
                QuickSortRecursive(array, compareFunc, left, partitionIndex - 1); // Рекурсивне сортування лівого підмасиву
                QuickSortRecursive(array, compareFunc, partitionIndex + 1, right); // Рекурсивне сортування правого підмасиву
            }
        }

        private static int Partition(T[] array, Func<T, T, int> compareFunc, int left, int right)
        {
            int randomIndex = random.Next(left, right + 1); // Вибір випадкового індексу у межах left та right
            T pivot = array[randomIndex]; // Опорний елемент - випадковий елемент масиву
            Swap(array, randomIndex, right); // Переміщення опорного елемента на останню позицію
            int partitionIndex = left; // Індекс для розділення масиву на дві частини

            for (int i = left; i < right; i++)
            {// Порівняння поточного елемента з опорним елементом
                if (compareFunc(array[i], pivot) <= 0)
                {
                    Swap(array, i, partitionIndex); // Обмін поточного елемента з елементом на місці partitionIndex
                    partitionIndex++; // Зсув partitionIndex
                }
            }

            Swap(array, partitionIndex, right); // Обмін опорного елемента з елементом на місці partitionIndex
            return partitionIndex; // Повернення позиції опорного елемента
        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i]; // Тимчасова змінна для збереження значення елемента
            array[i] = array[j]; // Заміна значення першого елемента значенням другого
            array[j] = temp; // Присвоєння значення другого елемента змінній
        }
    }
}
