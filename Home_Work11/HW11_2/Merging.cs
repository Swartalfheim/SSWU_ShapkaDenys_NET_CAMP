namespace HW11_2
{
    public class Merging
    {
        public static void Sort(string path, int count)
        {
            // Створення шляхів до тимчасових файлів
            string temp1 = Path.Combine(Path.GetDirectoryName(path), "temp1.txt");
            string temp2 = Path.Combine(Path.GetDirectoryName(path), "temp2.txt");

            // Відкриття потоків для читання та запису
            StreamReader reader = new StreamReader(path);
            StreamWriter writer = new StreamWriter(temp1);

            int[] arr = new int[count]; // Створення масиву фіксованого розміру

            // Зчитування чисел з вхідного файлу та заповнення масиву
            for (int i = 0; i < arr.Length && !reader.EndOfStream; i++)
            {
                arr[i] = int.Parse(reader.ReadLine());
            }

            arr = QuickSort<int>.Sort(arr).ToArray(); // Сортування масиву

            // Запис відсортованих чисел у тимчасовий файл
            for (int i = 0; i < arr.Length && !reader.EndOfStream; i++)
            {
                writer.WriteLine(arr[i]);
                arr[i] = int.Parse(reader.ReadLine());
            }

            writer.Close(); // Закриття потоку запису

            writer = new StreamWriter(temp2); // Відкриття нового потоку запису
            arr = QuickSort<int>.Sort(arr).ToArray();

            // Запис відсортованих чисел у другий тимчасовий файл
            for (int i = 0; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }

            // Закриття потоків та видалення непотрібних тимчасових файлів
            writer.Dispose();
            writer.Close();
            reader.Dispose();
            reader.Close();

            Sort_Merge(temp1, temp2, path); // Виклик методу злиття файлів
        }

        private static void Sort_Merge(string file1, string file2, string output)
        {
            // Відкриття потоків для читання та запису
            StreamReader reader1 = new StreamReader(file1);
            StreamReader reader2 = new StreamReader(file2);

            StreamWriter writer = new StreamWriter(output);

            int num1 = int.Parse(reader1.ReadLine()); // Зчитування першого числа з першого файлу
            int num2 = int.Parse(reader2.ReadLine()); // Зчитування першого числа з другого файлу

            // Злиття відсортованих чисел з обох файлів
            while (!reader1.EndOfStream && !reader2.EndOfStream)
            {
                if (num1 < num2)
                {
                    writer.WriteLine(num1);

                    num1 = int.Parse(reader1.ReadLine());
                }
                else
                {
                    writer.WriteLine(num2);

                    num2 = int.Parse(reader2.ReadLine());
                }
            }

            // Запис залишкових чисел з першого файлу, якщо другий файл закінчився
            if (!reader1.EndOfStream)
            {
                writer.WriteLine(num2);
                while (!reader2.EndOfStream)
                {
                    writer.WriteLine(reader2.ReadLine());
                }
            }

            // Запис залишкових чисел з другого файлу, якщо перший файл закінчився
            else
            {
                writer.WriteLine(num1);
                while (!reader1.EndOfStream)
                {
                    writer.WriteLine(reader1.ReadLine());
                }
            }

            // Закриття потоків та видалення непотрібних тимчасових файлів
            reader1.Dispose();
            reader1.Close();
            reader2.Dispose();
            reader2.Close();
            writer.Dispose();
            writer.Close();
        }
    }
}
