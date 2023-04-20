using Task2;

namespace Task2
{
    public static class Packer
    {
        public static Box PackByStore(List<Product> products, string storeName)
        {
            return new Box(PackByDepartment(products), storeName);
        }

        public static Box PackByStore(List<Box> boxes, string storeName)
        {
            return new Box(boxes, storeName);
        }

        public static List<Box> PackByDepartment(List<Product> products)
        {
            List<Box> result = new List<Box>();
            var groupedProducts = products.GroupBy(p => p.DepartmentName);
            foreach (var group in groupedProducts)
            {
                List<Box> packedProducts = new List<Box>();
                foreach (Product product in group)
                {
                    packedProducts.Add(PackProduct(product));
                }

                result.Add(new Box(packedProducts, group.First().DepartmentName));
            }

            return result;
        }

        public static Box PackProduct(Product product)
        {
            return new Box(product);
        }
    }
}
