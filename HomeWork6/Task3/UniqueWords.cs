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
        {
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
    }
}
