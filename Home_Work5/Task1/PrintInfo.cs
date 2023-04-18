using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PrintInfo
    {
        private FencePerimeter _fencePerimeter;
        private Fence _fence;
        private RecordingAndComparison _recordingAndComparison;
        public void Print()
        {
            _fencePerimeter = new FencePerimeter();
            _fence = new Fence();
            _recordingAndComparison = new RecordingAndComparison();
            _recordingAndComparison.Recording();
            Console.WriteLine($"Площа паркану {_fencePerimeter.Perimetr1()}");
            /*
            Console.WriteLine("Координати за якими будується паркан");
            foreach (var item in _fence.Treatment())
            {
                Console.WriteLine($"{item[0]} - {item[1]}");
            }
            */
        }
    }
}
