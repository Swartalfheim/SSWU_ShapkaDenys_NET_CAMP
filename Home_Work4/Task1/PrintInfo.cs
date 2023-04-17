using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PrintInfo
    {
        private DataStorage _dataStorage;
        private Treatment _treatment;
        public void Print()
        {
            _dataStorage = new DataStorage();
            _treatment = new Treatment();
            for (int i = 0; i < _dataStorage.Storage().Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_dataStorage.Storage()[i]}");
            }

            Console.WriteLine();
            for (int i = 0; i < _treatment.Processing().Count; i++)
            {
                Console.WriteLine($"{_treatment.Processing()[i]}");
            }
        }
    }
}
