namespace HW11_2
{
    public class DataOutput
    {
        public const string OutputPath = "E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work11\\HW11_2\\Data.txt";
        public string Output { get => OutputPath; }

        public void WriteDataLines(string[] text, bool append = false, string path = OutputPath)
        {
            using StreamWriter outputFile = new (path, append); // Використання блоку using для автоматичного закриття потоку запису після виконання коду
            foreach (var line in text)
            {
                outputFile.WriteLine(line); // Запис кожного рядка тексту в файл
            }
        }
    }
}
