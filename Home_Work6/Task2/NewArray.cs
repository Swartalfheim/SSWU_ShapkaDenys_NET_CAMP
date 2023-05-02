using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class NewArray
    {
        public IEnumerable<int> NewNumbers(params int[][] arrays)
        {// Заплутались в 3 соснах. Залиштеся, щоб я пояснила.
            int[] mins = new int[arrays.Length];
            int max = arrays.Select(m => m.Max()).Max();
            List<int> sorted = new List<int>(); // to check if a minimum was already output
            List<int> sortedMins = new List<int>(); // to find next minimums in all arrays

            do
            {
                if (sorted.Any())
                {
                    for (int i = 0; i < arrays.Length; i++)
                    {
                        int currMin = mins[i];
                        for (int j = 0; j < arrays[i].Length; j++)
                        {
                            if (arrays[i][j] > mins[i])
                            {
                                currMin = arrays[i][j];
                                break;
                            }
                        }

                        for (int j = 0; j < arrays[i].Length; j++)
                        {
                            if (arrays[i][j] > mins[i] && currMin > arrays[i][j])
                            {
                                currMin = arrays[i][j];
                            }
                        }

                        mins[i] = currMin;
                    }
                }
                else
                {
                    for (int i = 0; i < arrays.Length; i++)
                    {
                        mins[i] = arrays[i].Min();
                    }
                }

                sortedMins = new List<int>(mins.Distinct().OrderBy(m => m));
                foreach (int min in sortedMins)
                {
                    if (sorted.Contains(min))
                    {
                        continue;
                    }

                    for (int i = 0; i < arrays.Length; i++)
                    {
                        for (int j = 0; j < arrays[i].Length; j++)
                        {
                            if (arrays[i][j] == min)
                            {
                                yield return arrays[i][j];
                            }
                        }
                    }
                }

                sorted.AddRange(sortedMins);
            }
            while (sortedMins.Max() != max);
        }
    }
}
