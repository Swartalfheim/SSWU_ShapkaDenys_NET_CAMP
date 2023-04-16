using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DataStorage
    {
        private List<string> _lines;

        public List<string> Storage()
        {
            _lines = new List<string>();
            int nums = 0;
            FileStream file = new FileStream("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work4\\Task2\\text.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                _lines.Add(readFile.ReadLine());
            }

            readFile.Close();
            return _lines;
        }
    }
}
