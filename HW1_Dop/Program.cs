namespace HW1_Dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int  side= int.Parse(Console.ReadLine());            
            PrintInfo printInfo = new PrintInfo(side,side,side);
            printInfo.Info();

        }
    }
}