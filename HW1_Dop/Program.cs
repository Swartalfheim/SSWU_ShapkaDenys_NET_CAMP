namespace HW1_Dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value that will be responsible for the sides of the cube:");
            int  side= int.Parse(Console.ReadLine());            
            PrintInfo printInfo = new PrintInfo(side,side,side);
            printInfo.Info();

        }
    }
}