using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11_1
{
    public class QuickSort_First<T>
    {
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
            T pivot = array[left]; // Опорний елемент - перший елемент масиву
            int i = left + 1; // Індекс для проходження від лівого до правого кінця підмасиву
            int j = right; // Індекс для проходження від правого до лівого кінця підмасиву

            while (true)
            {// Знаходження елемента, який більший за опорний
                while (i <= j && compareFunc(array[i], pivot) <= 0)
                {
                    i++;
                }

                // Знаходження елемента, який менший за опорний
                while (j >= i && compareFunc(array[j], pivot) >= 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j); // Обмін місцями елементів, які не знаходяться на своїх місцях
            }

            Swap(array, left, j); // Переміщення опорного елемента на його правильне місце
            return j; // Повернення позиції опорного елемента
        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i]; // Тимчасова змінна для зберігання значення елемента
            array[i] = array[j]; // Заміна значення першого елемента значенням другого
            array[j] = temp; // Присвоєння значення другого елемента змінній
        }
    }
}