using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class PrintInfo
    {
        private const double _price = 1.68;
        private DataStorage _dataStorage;
        private Treatment _treatment;
        public void Print()
        {
            _dataStorage = new DataStorage();
            _treatment = new Treatment();

            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                for (int i = 0; i < _dataStorage.StorageALL()[j].Length; i++)
                {
                    if (i == 1 && j > 0)
                    {
                        continue;
                    }

                    if (i == 0 && j > 0)
                    {
                        Console.Write("apartment number-");
                    }

                    if (i == 0 && j == 0)
                    {
                        Console.Write("# of apartments- ");
                    }

                    if (i == 3 && j > 0)
                    {
                        Console.Write("Starts- ");
                    }

                    if (i == 4 && j > 0)
                    {
                        Console.Write("Final- ");
                    }

                    if (i == 8)
                    {
                        Console.Write("$-");
                    }

                    Console.Write("{0, 20}", _dataStorage.StorageALL()[j][i] + " |");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            _treatment.PrintOneApartment();
            Console.WriteLine();
            _treatment.Duty();
            Console.WriteLine();
            _treatment.NotUsed();
            Console.WriteLine();
            _treatment.AmountOfExpenses();
            Console.WriteLine();
            _treatment.TimeHasPassed();
        }
    }
}
