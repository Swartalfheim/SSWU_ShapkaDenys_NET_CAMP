using System.Collections;
using System.Drawing;
using System.Globalization;

namespace Task1
{
    public class Treatment : IEnumerable<int>
    {
        public Treatment(int size)
        {
            Size = size;
            Matrix = new int[Size, Size];
        }

        public int Size { get; private set; }
        public int[,] Matrix { get; set; }
        public IEnumerator<int> GetEnumerator()
        {
            int x = 0;
            int y = 0;
            int step = -1;
            Matrix = FillMatrix();
            for (int i = 0; i < Size * Size; i++)
            {
                yield return Matrix[y, x];
                int xNext = x + step;
                int yNext = y - step;
                if (xNext < 0 || yNext < 0 || xNext == Size || yNext == Size)
                {
                    step *= -1;
                }

                y = xNext == Size ? yNext + 2 : yNext < 0 ? 0 : yNext == Size ? Size - 1 : yNext;
                x = yNext == Size ? xNext + 2 : xNext < 0 ? 0 : xNext == Size ? Size - 1 : xNext;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int[,] FillMatrix()
        {
            int n = 1;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = n;
                    n++;
                }
            }

            return Matrix;
        }
    }
}
