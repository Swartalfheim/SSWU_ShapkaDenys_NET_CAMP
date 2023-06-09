using HW10_2.Abstractions;
using HW10_2.Implementations;

namespace HW10_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IProductVisitor calc = new PriceCalculator(50, 0.01, 10);

            Clothes shirt = new Clothes("Shirt", new double[] { 30, 10, 5 }, 0.5);
            Clothes trousers = new Clothes("Trousers", new double[] { 40, 20, 7 }, 0.8);

            Electronics laptop = new Electronics("Laptop", new double[] { 20, 10, 4 }, 2.5);
            Electronics telephone = new Electronics("Telephone", new double[] { 5, 10, 1 }, 0.2);

            Products pickles = new Products("Pickles", new double[] { 10, 10, 30 }, 1.5, new DateOnly(2023, 05, 21), new DateOnly(2024, 10, 27));
            Products olives = new Products("Olives", new double[] { 15, 15, 20 }, 0.5, new DateOnly(2023, 06, 09), new DateOnly(2023, 11, 17));

            Console.WriteLine("Delivery price in hryvnia:");
            Console.WriteLine($"{shirt.Name,-9} - {shirt.ShippingPrice(calc)}");
            Console.WriteLine($"{trousers.Name,-9} - {trousers.ShippingPrice(calc)}");

            Console.WriteLine($"{laptop.Name,-9} - {laptop.ShippingPrice(calc)}");
            Console.WriteLine($"{telephone.Name,-9} - {telephone.ShippingPrice(calc)}");

            Console.WriteLine($"{pickles.Name,-9} - {pickles.ShippingPrice(calc)}");
            Console.WriteLine($"{olives.Name,-9} - {olives.ShippingPrice(calc)}");
        }
    }
}