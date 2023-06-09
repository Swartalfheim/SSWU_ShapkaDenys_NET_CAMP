namespace HW10_2.Abstractions
{
    public interface IProduct
    {
        string Name { get; }
        double[] Size { get; }
        double Weight { get; }
        decimal ShippingPrice(IProductVisitor visitor);
    }
}
