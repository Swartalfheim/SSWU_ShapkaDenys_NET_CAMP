using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PrintInfo
    {
        private DataStorage _dataStorage;
        private Treatment _treatment;

        public void Print()
        {
            _dataStorage = new DataStorage();
            _treatment = new Treatment();
            int i = 1;
            Console.WriteLine("Вивiд всiх рядкiв");
            foreach (var item in _dataStorage.Storage())
            {
                Console.WriteLine($"{i}: {item}");
                i++;
            }

            i = 1;
            Console.WriteLine();
            Console.WriteLine("Вивiд всiх рядкiв якi мiстять @");
            foreach (var item in _treatment.Storage1())
            {
                Console.WriteLine($"{i}: {item}");
                i++;
            }

            i = 1;
            Console.WriteLine();
            Console.WriteLine("Вивiд всiх рядкiв з правильною єлектроною адресою");
            foreach (var item in _treatment.Storage())
            {
                Console.WriteLine($"{i}: {item}");
                i++;
            }
        }
    }
}
