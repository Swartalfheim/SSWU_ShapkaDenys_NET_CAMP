using System.Collections;

namespace Task2
{
    public class Box
    {
        public Box(Product product)
        {
            Label = product.Name;
            Contents = new ArrayList() { product };
            CalculateSize(product);
        }

        public Box(List<Box> boxes, string label)
        {
            Label = label;
            Contents = new ArrayList(boxes);
            CalculateSize(boxes);
        }

        public string Label { get; set; }

        // коробка може містити як один продукт, так і кілька коробок
        public ArrayList Contents { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        private void CalculateSize(Product product)
        {
            Length = product.Length;
            Width = product.Width;
            Height = product.Height;
        }

        private void CalculateSize(List<Box> boxes)
        {
            Length = boxes.Max(x => x.Length);
            Width = boxes.Max(x => x.Width);
            Height = boxes.Sum(x => x.Height);
        }
    }
}