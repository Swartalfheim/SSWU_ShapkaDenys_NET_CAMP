using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PrintInfo
    {
        public void Print()
        {
            Treatment matrix = new Treatment(5);
            int height = matrix.FillMatrix().GetLength(0);
            int width = matrix.FillMatrix().GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0,4}", matrix.FillMatrix()[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            foreach (var item in matrix)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
