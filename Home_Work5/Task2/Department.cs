namespace Task2
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Product>? Products { get; set; }
        public List<Department>? InnerDepartments { get; set; }
        public bool AddInnerDepartment(string name)
        {
            if (Products != null)
            {
                return false;
            }

            InnerDepartments ??= new List<Department>();
            InnerDepartments.Add(new Department(name));
            return true;
        }

        public Department? FindInnerDepartment(string name)
        {
            return InnerDepartments?.Find(x => x.Name.ToLower() == name.ToLower());
        }

        public bool AddProduct(string name, double length, double width, double height)
        {
            if (InnerDepartments != null)
            {
                return false;
            }

            Products ??= new List<Product>();
            Products.Add(new Product(name, length, width, height, Name));
            return true;
        }

        public Product? FindProduct(string name)
        {
            return Products?.Find(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
