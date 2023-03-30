namespace HW1_Dop
{
    public class Matrix
    {
        Random r = new Random();
        private int _height;
        private int _width;
        public Matrix(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public int[,] FillMatrix()
        {            
            int[,] matrix = new int[_height,_width];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(0,2);
                }
            }

            return matrix;
        }

        
    }
}
