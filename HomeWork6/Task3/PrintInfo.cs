using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class PrintInfo
    {
        private UniqueWords _uniqueWords = new UniqueWords();
        public void Print()
        {
            string text = "fought the punic wars were a series of rome wars between 264 and 146 bc fought " +
                "between Rome and wars Carthage Punic";
            foreach (var word in _uniqueWords.Uniquewords(text))
            {
                Console.Write($"{word} ");
            }
        }
    }
}
