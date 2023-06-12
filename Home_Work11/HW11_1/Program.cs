namespace HW11_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
            }

            Print_Info print_Info = new (array);
            print_Info.Print();
        }
    }
}