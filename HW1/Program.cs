using System.Security.Cryptography.X509Certificates;

namespace HW1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Натисьнiть цифру яка вiдповiдає завданню: 1-2");
            int a= int.Parse(Console.ReadLine());            
            switch (a)
            {
                case 1:

                    
                    int[,] matrix;
                    int rows, columns, counter = 10;
                    bool result;

                    
                    int r = 0, c = 0, maxRowSteps, maxColumnSteps, rowSteps = 0, columnSteps = 0;
                    (int r, int c) direction = (1, 0);

                    do
                    {
                        Console.Write("Введiть кiлькiсть рядкiв: ");
                        result = int.TryParse(Console.ReadLine(), out rows);
                    } while (!result || rows <= 0);
                    do
                    {
                        Console.Write("Введiть кiлькiсть стовбцiв: ");
                        result = int.TryParse(Console.ReadLine(), out columns);
                    } while (!result || columns <= 0);

                    matrix = new int[rows, columns];
                    maxRowSteps = rows - 1;
                    maxColumnSteps = columns - 1;

                    while (maxRowSteps > 0 || maxColumnSteps > 0)
                    {
                        matrix[r, c] = counter++;
                       
                        if ((rowSteps >= maxRowSteps && maxRowSteps > 0) || (columnSteps >= maxColumnSteps && maxColumnSteps > 0))
                        {                            
                            rowSteps = 0;
                            columnSteps = 0;
                            switch (direction)
                            {
                                case (1, 0): 
                                    direction = (0, 1);
                                    if (maxColumnSteps != columns - 1) 
                                    {
                                        maxRowSteps--;
                                    }
                                    break;
                                case (0, 1): 
                                    direction = (-1, 0); 
                                    maxColumnSteps--;
                                    break;
                                case (-1, 0): 
                                    direction = (0, -1); 
                                    maxRowSteps--;
                                    break;
                                case (0, -1):
                                    direction = (1, 0); 
                                    maxColumnSteps--;
                                    break;
                            }
                            if (rows > columns && maxRowSteps < 2)
                            {
                                maxRowSteps--;
                            }
                        }
                        r += direction.r;
                        c += direction.c;
                        rowSteps += Math.Abs(direction.r);
                        columnSteps += Math.Abs(direction.c);
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }

                    break;
                case 2:

                    int[,] mas;
                    int rows1, columns1, colors = 16;
                    (int i, int j) maxStart = (-1, -1), maxEnd = (-1, -1), start = (-1, -1), pStart = (-1, -1), pEnd = (-1, -1);
                    bool result1;
                    Random random = new Random();

                    do
                    {
                        Console.Write("Введiть кiлькiсть рядкiв: ");
                        result1 = int.TryParse(Console.ReadLine(), out rows1);
                    } while (!result1 || rows1 <= 0);
                    do
                    {
                        Console.Write("Введiть кiлькiсть стовбцiв: ");
                        result = int.TryParse(Console.ReadLine(), out columns1);
                    } while (!result1 || columns1 <= 0);

                    mas = new int[rows1, columns1];
                    for (int i = 0; i < rows1; i++)
                    {
                        for (int j = 0; j < columns1; j++)
                        {
                            mas[i, j] = random.Next(colors + 1);
                            Console.Write($"{mas[i, j]}; ");
                        }
                        Console.WriteLine();
                    }

                    for (int i = 0; i < rows1; i++)
                    {
                        for (int j = 0; j < columns1; j++)
                        {
                            if ((j == 0) || (j > 0 && mas[i, j] != mas[i, j - 1]))
                            {
                                pStart = j == 0 ? (-1, -1) : start;
                                pEnd = j == 0 ? (-1, -1) : (i, j - 1);
                                start = (i, j);
                            }
                            if ((j >= columns1 - 1) && mas[i, j] == mas[i, j - 1])
                            {
                                pStart = start;
                                pEnd = (i, j);
                            }
                            if ((maxEnd.j - maxStart.j + 1 < pEnd.j - pStart.j + 1) || (maxStart.j == -1 && pEnd.j != -1))
                            {
                                maxStart = pStart;
                                maxEnd = pEnd;
                            }
                        }
                    }
                    Console.WriteLine($"Найдовший рядок - колiр: {mas[maxStart.i, maxStart.j]}, з iндексами: [{maxStart.i}, {maxStart.j}] - [{maxEnd.i}, {maxEnd.j}], має довжину: {maxEnd.j - maxStart.j + 1}");

                    break;

            }



        }
    }
}