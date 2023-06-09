namespace HW10_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ulong> numbers = new List<ulong>()
            {
                4003789100205381,
                372350614269787,
                342001532755894,
                385020663490130,
                5241039505054722,
                5264539817114556,
                6558927575000693,
                511302161976879,
                3542363366777374,
                448591206941775
            };
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"{i + 1}) - {numbers[i]}");
            }

            BankCardInformation bankCardInformation = new BankCardInformation(numbers);
            bankCardInformation.PrintInfo();
        }
    }
}