using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DataStorage
    {
        private List<string[]> _lines;
        public List<string[]> StorageALL()
        {
            _lines = new List<string[]>();
            // Передавайте шлях до файлу через параметр методу
            FileStream file = new FileStream("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work4\\Task3\\text.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                var arr = readFile.ReadLine().Split(" ");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i].Replace(".10.", "_October_");
                    arr[i] = arr[i].Replace(".11.", "_November_");
                    arr[i] = arr[i].Replace(".12.", "_December_");
                }

                _lines.Add(arr);
            }

            readFile.Close();
            return _lines;
        }

        public List<string[]> Storage()
        {
            _lines = new List<string[]>();
            FileStream file = new FileStream("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work4\\Task3\\text.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                var arr = readFile.ReadLine().Split(" ");
                _lines.Add(arr);
            }

            readFile.Close();
            return _lines;
        }
    }
}
