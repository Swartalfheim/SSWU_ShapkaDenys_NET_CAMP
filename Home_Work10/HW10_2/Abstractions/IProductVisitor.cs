using HW10_2.Implementations;

namespace HW10_2.Abstractions
{
    public interface IProductVisitor
    {
        decimal ThePriceOfClothingDelivery(Clothes clothing);
        decimal ThePriceOfElectronicsDelivery(Electronics electronics);
        decimal ThePriceOfProductsDelivery(Products products);
    }
}
