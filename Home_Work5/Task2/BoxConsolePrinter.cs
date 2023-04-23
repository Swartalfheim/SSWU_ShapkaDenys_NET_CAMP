namespace Task2
{// Цей підхід не до кінця правильний. Хоча початкова ідея добра.
    public static class BoxConsolePrinter
    {
        public static void PrintFullBoxInfo(Box box, int indent, int indentIncrement)
        {
            Console.WriteLine($"{new string(' ', indent)}\"{box.Label}\" [Довжина: {box.Length}, Ширина: {box.Width}, Висота: {box.Height}]");
            if (box.Contents[0] is Box)
            {
                Console.WriteLine($"{new string(' ', indent)}Внутрiшнi ящики:");
            }

            foreach (object item in box.Contents)
            {
                if (item is Box)
                {
                    PrintFullBoxInfo((Box)item, indent + indentIncrement, indentIncrement);
                }
            }
        }
    }
}
