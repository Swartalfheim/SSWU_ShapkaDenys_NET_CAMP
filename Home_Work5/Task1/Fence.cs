using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Fence
    {
        private ArrangementOfTrees _arrangementOfTrees;
        public List<int[]> Treatment()
        {
            int minX = 10;
            int maxX = 0;
            int minY = 10;
            int maxY = 0;
            List<int[]> list = new List<int[]>();
            _arrangementOfTrees = new ArrangementOfTrees();
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] >= maxX)
                {
                    maxX = item[0];
                }

                if (item[0] <= minX)
                {
                    minX = item[0];
                }

                if (item[1] >= maxY)
                {
                    maxY = item[1];
                }

                if (item[1] <= minY)
                {
                    minY = item[1];
                }
            }

            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] == minX || item[0] == maxX || item[1] == minY || item[1] == maxY)
                {
                    list.Add(item);
                }
            }

            int[] bigestY = new int[2] { 10, 10 };
            int[] bigestX = new int[2] { 10, 10 };
            int[] centerLN = new int[2];
            int[] centerLU = new int[2];
            int[] centerRU = new int[2];
            int[] centerRN = new int[2];

            foreach (var item in list)
            {
                if (item[0] == minX)
                {
                    if (item[1] < bigestX[1])
                    {
                        bigestX = item;
                    }
                }

                if (item[1] == minY)
                {
                    if (item[0] < bigestY[0])
                    {
                        bigestY = item;
                    }
                }
            }

            centerLU[0] = (bigestX[0] + bigestY[0]) / 2;
            centerLU[1] = (bigestX[1] + bigestY[1]) / 2;
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] < bigestY[0] && item[1] < bigestX[1] && item[0] <= centerLU[0] && item[1] <= centerLU[1])
                {
                    list.Add(item);
                }
            }

            /*----------------------------------------------*/
            bigestY = new int[2] { 0, 0 };
            bigestX = new int[2] { 10, 10 };
            foreach (var item in list)
            {
                if (item[1] == minY)
                {
                    if (item[0] > bigestY[0])
                    {
                        bigestY = item;
                    }
                }

                if (item[0] == maxX)
                {
                    if (item[1] < bigestX[1])
                    {
                        bigestX = item;
                    }
                }
            }

            centerLN[0] = (bigestX[0] + bigestY[0]) / 2;
            centerLN[1] = (bigestX[1] + bigestY[1]) / 2;
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] > bigestY[0] && item[1] < bigestX[1] && item[0] >= centerLN[0] && item[1] <= centerLN[1])
                {
                    list.Add(item);
                }
            }

            /*--------------------------------------------*/
            bigestY = new int[2] { 10, 10 };
            bigestX = new int[2] { 0, 0 };
            foreach (var item in list)
            {
                if (item[0] == minX)
                {
                    if (item[1] > bigestX[1])
                    {
                        bigestX = item;
                    }
                }

                if (item[1] == maxY)
                {
                    if (item[0] < bigestY[0])
                    {
                        bigestY = item;
                    }
                }
            }

            centerRU[0] = (bigestX[0] + bigestY[0]) / 2;
            centerRU[1] = (bigestX[1] + bigestY[1]) / 2;
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] < bigestY[0] && item[1] > bigestX[1] && item[0] <= centerRU[0] && item[1] >= centerRU[1])
                {
                    list.Add(item);
                }
            }

            /*----------------------------------------------*/
            bigestY = new int[2] { 0, 0 };
            bigestX = new int[2] { 0, 0 };
            foreach (var item in list)
            {
                if (item[1] == maxY)
                {
                    if (item[0] > bigestX[0])
                    {
                        bigestX = item;
                    }
                }

                if (item[0] == maxX)
                {
                    if (item[1] > bigestY[1])
                    {
                        bigestY = item;
                    }
                }
            }

            centerRN[0] = (bigestX[0] + bigestY[0]) / 2;
            centerRN[1] = (bigestX[1] + bigestY[1]) / 2;
            foreach (var item in _arrangementOfTrees.Arrangement())
            {
                if (item[0] > bigestY[0] && item[1] > bigestX[1] && item[0] >= centerRN[0] && item[1] >= centerRN[1])
                {
                    list.Add(item);
                }
            }

            /*------------------------------------------------*/
            return list;
        }
    }
}
