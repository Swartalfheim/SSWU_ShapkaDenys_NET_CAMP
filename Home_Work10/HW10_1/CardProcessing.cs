namespace HW10_1
{
    public class CardProcessing
    {
        public string Name { get; private set; }
        public void Result(HashSet<ulong> card)
        {
            List<string> masterCard = new List<string>() { "51", "52", "53", "54" };
            List<string> americanExpress = new List<string>() { "34", "37" };
            string result;
            int nums = 1;
            foreach (var item in card)
            {
                string a = Convert.ToString(item);
                int first = 0;
                int second = 0;
                int sum = 0;
                for (int i = a.Length - 2; i >= 0; i -= 2)
                {
                    first = (a[i] - 48) * 2;
                    if (first >= 10)
                    {
                        string en = first.ToString();
                        first = en[0] - 48 + en[1] - 48;
                    }

                    second = a[i + 1] - 48;
                    sum = sum + first + second;
                }

                if (a.Length % 2 != 0)
                {
                    sum = sum + a[0] - 48;
                }

                if (sum % 10 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (masterCard.Contains(a.Substring(0, 2)) && a.Length == 16)
                    {
                        result = $"{a} - Master Card - Valid";
                    }
                    else if (americanExpress.Contains(a.Substring(0, 2)) && a.Length == 15)
                    {
                        result = $"{a} - American Express - Valid";
                    }
                    else if (a.StartsWith("4") && (a.Length == 13 || a.Length == 16))
                    {
                        result = $"{a} - Visa - Valid";
                    }
                    else
                    {
                        result = $"{a}  - Unknown - Valid";
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    result = $"{a}  -  Invalid";
                }

                Console.WriteLine($"{nums}) {result}");
                Console.ResetColor();
                nums++;
            }
        }
    }
}
