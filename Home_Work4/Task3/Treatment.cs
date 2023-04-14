using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Treatment
    {
        private const double _price = 1.68;
        private DataStorage _dataStorage;
        public void PrintOneApartment()
        {
            _dataStorage = new DataStorage();
            Console.WriteLine("Enter apartment number");
            string number = Console.ReadLine();

            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                if (_dataStorage.StorageALL()[j][0] == number)
                {
                    for (int i = 0; i < _dataStorage.StorageALL()[j].Length; i++)
                    {
                        Console.Write("{0, 17}", _dataStorage.StorageALL()[j][i] + " |");
                    }
                }
                else
                {
                    continue;
                }

                Console.WriteLine();
            }
        }

        public void Duty()
        {
            double more;
            double most = 0;
            _dataStorage = new DataStorage();
            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                if (j > 0)
                {
                    more = (Convert.ToDouble(_dataStorage.StorageALL()[j][4]) - Convert.ToDouble(_dataStorage.StorageALL()[j][3])) * _price;
                    more = Convert.ToDouble(_dataStorage.StorageALL()[j][8]) - more;
                    if (more <= most)
                    {
                        most = more;
                    }
                }
            }

            Console.WriteLine($"The biggest debt: {most} hryvnia at the user:");

            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                if (j > 0)
                {
                    more = (Convert.ToDouble(_dataStorage.StorageALL()[j][4]) - Convert.ToDouble(_dataStorage.StorageALL()[j][3])) * _price;
                    more = Convert.ToDouble(_dataStorage.StorageALL()[j][8]) - more;
                    if (more == most)
                    {
                        for (int i = 0; i < _dataStorage.StorageALL()[j].Length; i++)
                        {
                            Console.Write("{0, 17}", _dataStorage.StorageALL()[j][i] + " |");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                Console.WriteLine();
            }
        }

        public void NotUsed()
        {
            _dataStorage = new DataStorage();
            Console.WriteLine("Users who did not use electricity:");
            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                if (j > 0 && Convert.ToInt32(_dataStorage.StorageALL()[j][4]) - Convert.ToInt32(_dataStorage.StorageALL()[j][3]) == 0)
                {
                    for (int i = 0; i < _dataStorage.StorageALL()[j].Length; i++)
                    {
                        Console.Write("{0, 17}", _dataStorage.StorageALL()[j][i] + " |");
                    }
                }
                else
                {
                    continue;
                }

                Console.WriteLine();
            }
        }

        public void AmountOfExpenses()
        {
            _dataStorage = new DataStorage();
            Console.WriteLine("Users who did not use electricity:");
            for (int j = 0; j < _dataStorage.StorageALL().Count; j++)
            {
                if (j > 0)
                {
                    Console.Write($"Аpartment number: {_dataStorage.StorageALL()[j][0]}, by the address: {_dataStorage.StorageALL()[j][1]}, have to pay: {Math.Round((Convert.ToDouble(_dataStorage.StorageALL()[j][4]) - Convert.ToDouble(_dataStorage.StorageALL()[j][3])) * _price, 2)} hryvnia");
                }
                else
                {
                    continue;
                }

                Console.WriteLine();
            }
        }

        public void TimeHasPassed()
        {
            _dataStorage = new DataStorage();
            DateTime dateTimeNow = DateTime.Now;
            for (int j = 0; j < _dataStorage.Storage().Count; j++)
            {
                if (j > 0)
                {
                    Console.WriteLine($"The apartment has a number: {_dataStorage.Storage()[j][0]}, by the address: {_dataStorage.StorageALL()[j][1]}");
                    Console.WriteLine($"{(dateTimeNow - DateTime.Parse(_dataStorage.Storage()[j][7])).Days} - days elapsed from the last paid invoice to the current date.");
                }
                else
                {
                    continue;
                }

                Console.WriteLine();
            }
        }
    }
}
