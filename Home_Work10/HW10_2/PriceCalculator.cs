using HW10_2.Abstractions;
using HW10_2.Implementations;

namespace HW10_2
{
    public class PriceCalculator : IProductVisitor
    {
        public PriceCalculator(decimal baseDeliveryPrice, double sizeCoefficient, double weightCoefficient)
        {
            BaseDeliveryPrice = baseDeliveryPrice;
            SizeCoefficient = sizeCoefficient;
            WeightCoefficient = weightCoefficient;
        }

        public decimal BaseDeliveryPrice { get; private set; }
        public double SizeCoefficient { get; private set; }
        public double WeightCoefficient { get; private set; }
        public decimal ThePriceOfClothingDelivery(Clothes clothing)
        {
            return BaseDeliveryPrice + Convert.ToDecimal((clothing.Size[0] * clothing.Size[1] * clothing.Size[2] * SizeCoefficient) + (clothing.Weight * WeightCoefficient));
        }

        public decimal ThePriceOfElectronicsDelivery(Electronics electronics)
        {
            double volume = electronics.Size[0] * electronics.Size[1] * electronics.Size[2];
            decimal currPrice = BaseDeliveryPrice + Convert.ToDecimal((volume * SizeCoefficient) + (electronics.Weight * WeightCoefficient));
            if (volume > 10000)
            {
                return currPrice * 2;
            }

            return currPrice;
        }

        public decimal ThePriceOfProductsDelivery(Products products)
        {
            decimal currPrice = BaseDeliveryPrice + Convert.ToDecimal((products.Size[0] * products.Size[1] * products.Size[2] * SizeCoefficient) + (products.Weight * WeightCoefficient));
            if (products.ExpirationDate.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber < 3)
            {
                return currPrice * 1.5m;
            }

            return currPrice;
        }
    }
}
