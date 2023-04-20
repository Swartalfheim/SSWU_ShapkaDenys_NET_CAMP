namespace Task2
{
    public class Product
    {
        public Product(string name, double length, double width, double height, string departmentName)
        {
            Name = name;
            Length = length;
            Width = width;
            Height = height;
            DepartmentName = departmentName;
        }

        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string DepartmentName { get; set; }
    }
}
