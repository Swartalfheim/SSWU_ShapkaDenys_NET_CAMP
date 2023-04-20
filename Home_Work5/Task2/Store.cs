namespace Task2
{
    public class Store
    {
        public Store(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }

        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public void AddDepartment(string name)
        {
            Departments.Add(new Department(name));
        }

        public Department? FindDepartment(string name)
        {
            return Departments.Find(x => x.Name.ToLower() == name.ToLower());
        }

        public Department? FindInnerDepartment(string route)
        {
            string[] data = route.Split('/');
            Department? department = FindDepartment(data[0]);
            for (int i = 1; i < data.Length; i++)
            {
                department = department?.FindInnerDepartment(data[i]);
                if (department == null)
                {
                    break;
                }
            }

            return department;
        }

        public List<Product> GetAllProducts()
        {
            return GetAllDepartmentProducts(Departments, new List<Product>());
        }

        public List<Product> GetAllDepartmentProducts(List<Department> departments, List<Product> products)
        {
            foreach (Department department in departments)
            {
                if (department.Products != null)
                {
                    foreach (Product product in department.Products)
                    {
                        products.Add(product);
                    }
                }
                else
                {
                    if (department.InnerDepartments != null)
                    {
                        products = GetAllDepartmentProducts(department.InnerDepartments, products);
                    }
                }
            }

            return products;
        }

        public List<Product> Buy(string route, string product, int count = 1)
        {
            List<Product> result = new List<Product>();
            Product? p = FindInnerDepartment(route)?.FindProduct(product);
            if (p != null)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(p);
                }
            }

            return result;
        }

        public void SeedData()
        {
            AddDepartment("Grocery");
            FindDepartment("Grocery")?.AddInnerDepartment("Fruits");
            FindDepartment("Grocery")?.FindInnerDepartment("Fruits")?.AddProduct("Pomegranate", 20, 10, 5);
            FindDepartment("Grocery")?.FindInnerDepartment("Fruits")?.AddProduct("Peach", 15, 15, 15);
            FindDepartment("Grocery")?.FindInnerDepartment("Fruits")?.AddProduct("Pear", 12, 12, 12);
            FindDepartment("Grocery")?.AddInnerDepartment("Vegetables");
            FindDepartment("Grocery")?.FindInnerDepartment("Vegetables")?.AddProduct("Onion", 12, 10, 11);
            FindDepartment("Grocery")?.FindInnerDepartment("Vegetables")?.AddProduct("Eggplant", 15, 5, 5);
            FindDepartment("Grocery")?.FindInnerDepartment("Vegetables")?.AddProduct("Cabbage", 10, 10, 8);
            AddDepartment("Clothing");
            FindDepartment("Clothing")?.AddInnerDepartment("Male Clothing");
            FindDepartment("Clothing")?.FindInnerDepartment("Male Clothing")?.AddInnerDepartment("Male Shirts");
            FindDepartment("Clothing")?.FindInnerDepartment("Male Clothing")?.FindInnerDepartment("Male Shirts")?.AddProduct("T-shirt", 20, 15, 3);
            FindDepartment("Clothing")?.FindInnerDepartment("Male Clothing")?.AddInnerDepartment("Male Pants");
            FindDepartment("Clothing")?.FindInnerDepartment("Male Clothing")?.FindInnerDepartment("Male Pants")?.AddProduct("Jeans", 20, 15, 10);
            FindDepartment("Clothing")?.AddInnerDepartment("Female Clothing");
            FindDepartment("Clothing")?.FindInnerDepartment("Female Clothing")?.AddInnerDepartment("Female Shirts");
            FindDepartment("Clothing")?.FindInnerDepartment("Female Clothing")?.FindInnerDepartment("Female Shirts")?.AddProduct("T-shirt", 20, 15, 3);
            FindDepartment("Clothing")?.FindInnerDepartment("Female Clothing")?.AddInnerDepartment("Female Pants");
            FindDepartment("Clothing")?.FindInnerDepartment("Female Clothing")?.FindInnerDepartment("Female Pants")?.AddProduct("Jeans", 20, 15, 10);
            AddDepartment("Houseware");
            FindDepartment("Houseware")?.AddInnerDepartment("Utensils");
            FindDepartment("Houseware")?.FindInnerDepartment("Utensils")?.AddProduct("Knife", 15, 3, 2);
            FindDepartment("Houseware")?.FindInnerDepartment("Utensils")?.AddProduct("Spoon", 15, 5, 3);
            FindDepartment("Houseware")?.FindInnerDepartment("Utensils")?.AddProduct("Fork", 15, 4, 2);
        }
    }
}
