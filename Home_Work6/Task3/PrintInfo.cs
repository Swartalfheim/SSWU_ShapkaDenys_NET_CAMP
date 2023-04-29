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
                "between rome and wars carthage punic";
            Console.WriteLine("Вивiд основного тексту:");
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("Вивiд тексту без повторень:");
            foreach (var word in _uniqueWords.Uniquewords(text))
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine('\n');
            Console.WriteLine("Вивiд тексту тiльки унiкальних слiв:");
            foreach (var item in _uniqueWords.NUniquewords(text))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
