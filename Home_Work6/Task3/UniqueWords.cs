using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class UniqueWords
    {
        public IEnumerable<string> Uniquewords(string text)
        {// Не враховано, що пробільні символи можуть бути різні. І їх може бути кілька підряд.
            string[] words = text.ToLower().Split(',', '-', '.', ' ');
            var hashSet = new HashSet<string>();

            foreach (string word in words)
            {
                if (hashSet.Add(word))
                {
                    yield return word;
                }
            }
        }
// До умови задачі нам це не потрібно
        public IEnumerable<string> NUniquewords(string text)
        {// Ви змінили колекцію
            string[] words = text.ToLower().Split(',', '-', '.', '“', '”', ' ');
            foreach (var item in words)
            {// Не ефективно тут
                if (words.Where(q => q == item).Count() == 1)
                {
                    yield return item;
                }
            }
        }
    }
}
