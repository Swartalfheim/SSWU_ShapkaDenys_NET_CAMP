using HW10_2.Abstractions;

namespace HW10_2.Implementations
{
    public class Clothes : IProduct
    {
        public Clothes(string name, double[] size, double weight)
        {
            Name = name;
            Size = new double[3];
            size.CopyTo(Size, 0); // Copies from the array with lower bound=0
            Weight = weight;
        }

        public string Name { get; set; }
        public double[] Size { get; private set; }
        public double Weight { get; set; }
        public decimal ShippingPrice(IProductVisitor visitor)
        {
            return visitor.ThePriceOfClothingDelivery(this);
        }
    }
}
