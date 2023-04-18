using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class RecordingAndComparison
    {
        private List<string> _lines;
        private FencePerimeter _perimeter;
        public void Recording()
        {
            _perimeter = new FencePerimeter();
            _lines = new List<string>();
            int nums = 0;
            FileStream file = new FileStream("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work5\\Task1\\log.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                _lines.Add(readFile.ReadLine());
            }

            readFile.Close();

            if (int.Parse(_lines[_lines.Count - 1]) > _perimeter.Perimetr1())
            {
                Console.WriteLine("Попереднiй паркан був бiльшим");
            }

            if (int.Parse(_lines[_lines.Count - 1]) < _perimeter.Perimetr1())
            {
                Console.WriteLine("Теперешнiй паркан бiшьший");
            }

            if (int.Parse(_lines[_lines.Count - 1]) == _perimeter.Perimetr1())
            {
                Console.WriteLine("Паркани однаковi");
            }
        }
    }
}
