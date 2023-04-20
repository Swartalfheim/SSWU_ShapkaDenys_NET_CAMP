namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Store store = new Store("Somestore");
            store.SeedData();

            // тест для покупки продуктів
            List<Product> products = store.GetAllProducts();
            List<Product> products1 = store.Buy("Grocery/Vegetables", "Carrot", 3);
            List<Product> products2 = store.Buy("Grocery/Vegetables", "Egg", 2);
            List<Product> products3 = store.Buy("Grocery/Grain", "Rice", 4);
            List<Product> products4 = store.Buy("Household chemicals", "Bleach");

            // показ структури магазину
            StoreConsoleInterface storeConsole = new StoreConsoleInterface(store);
            storeConsole.PrintStructure(0, 4);
            Console.WriteLine();

            // додати випадкові продукти, які будуть підтримані наступним
            List<Product> allProducts = store.GetAllProducts();
            List<Product> boughtProducts = new List<Product>();
            Random random = new Random();
            foreach (Product product in allProducts)
            {
                for (int i = 0; i < random.Next(1, 5 + 1); i++)
                {
                    boughtProducts.Add(product);
                }
            }

            Box box = Packer.PackByStore(boughtProducts, store.Name);

            // показати інформацію про коробку
            BoxConsolePrinter.PrintFullBoxInfo(box, 0, 4);
        }
    }
}