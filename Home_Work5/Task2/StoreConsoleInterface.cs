namespace Task2
{
    public class StoreConsoleInterface
    {
        private readonly Store _store;
        public StoreConsoleInterface(Store store)
        {
            _store = store;
        }

        public void PrintStructure(int indent, int indentIncrement)
        {
            PrintDepartmentStructure(_store.Departments, indent, indentIncrement);
        }

        public void PrintDepartmentStructure(List<Department> departments, int indent, int indentIncrement)
        {
            foreach (Department department in departments)
            {
                Console.WriteLine($"{new string(' ', indent)}{department.Name}: ");
                if (department.Products != null)
                {
                    foreach (Product product in department.Products)
                    {
                        Console.WriteLine($"{new string(' ', indent + indentIncrement)}{product.Name} [Длина: {product.Length}, Ширина: {product.Width}, Висота: {product.Height}]");
                    }
                }
                else
                {
                    if (department.InnerDepartments != null)
                    {
                        PrintDepartmentStructure(department.InnerDepartments, indent + indentIncrement, indentIncrement);
                    }
                }
            }
        }
    }
}