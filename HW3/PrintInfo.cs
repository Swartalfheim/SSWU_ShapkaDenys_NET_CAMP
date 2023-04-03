using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class PrintInfo
    {
        private OriginalString _originalString;
        private Exercise1 _exercise1;
        private Exercise2 _exercise2;
        private Exercise3 _exercise3;
        public void Print()
        {
            _originalString = new OriginalString();
            Console.WriteLine($"Рядок який буде оброблятися: {_originalString.Original()};\n ");
            Console.WriteLine("Ведiть текст який буде шукатися в рядку, в першому завданнi");
            string task1 = Console.ReadLine();
            Console.WriteLine("Ведiть текст на який буде замiнено подвоєння в рядку, в третьому завданнi");
            string task2 = Console.ReadLine();
            _exercise1 = new Exercise1(task1);
            _exercise2 = new Exercise2();
            _exercise3 = new Exercise3(task2);

            Console.WriteLine();
            Console.WriteLine($"task a: {_exercise1.Treatment()}");
            Console.WriteLine($"task b: {_exercise2.Treatment()} - слова починаються з великої лiтери");
            Console.WriteLine($"task c: {_exercise3.Treatment()}");
        }
    }
}
