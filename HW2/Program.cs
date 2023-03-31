namespace HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WaterTower waterTower = new WaterTower(50, new Pump(3, 10));
            waterTower.ConnectUser(new User(35));
            waterTower.ConnectUser(new User(3));
            waterTower.ConnectUser(new User(17));
            Console.WriteLine(waterTower.ToString());
        }
    }
}