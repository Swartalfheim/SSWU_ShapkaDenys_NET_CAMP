namespace HW11_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataOutput dataOutput = new DataOutput();
            Random rnd = new Random();
            List<string> data = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                data.Add(rnd.Next(100).ToString()); // Генерація випадкових чисел в діапазоні від 0 до 99 і додавання їх до списку даних
            }

            dataOutput.WriteDataLines(data.ToArray()); // Запис даних зі списку в файл за допомогою методу WriteDataLines

            Merging.Sort(dataOutput.Output, 50);
            /*
            File.Delete(@"E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work11\\HW11_2\\temp1.txt");
            File.Delete(@"E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work11\\HW11_2\\temp2.txt");
            */
        }
    }
}