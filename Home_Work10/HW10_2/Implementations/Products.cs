using HW10_2.Abstractions;

namespace HW10_2.Implementations
{
    public class Products : IProduct
    {
        public Products(string name, double[] size, double weight, DateOnly manufacturingDate, DateOnly expirationDate)
        {
            Name = name;
            Size = new double[3];
            size.CopyTo(Size, 0); // Copies from the array with lower bound=0
            Weight = weight;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
        }

        public string Name { get; set; }
        public double[] Size { get; private set; }
        public double Weight { get; set; }
        public DateOnly ManufacturingDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public decimal ShippingPrice(IProductVisitor visitor)
        {
            return visitor.ThePriceOfProductsDelivery(this);
        }
    }
}
