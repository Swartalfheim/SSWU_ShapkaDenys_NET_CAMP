namespace HW1_Dop
{
    public class Matrix
    {
        Random r = new Random();
        private int _height;
        private int _width;
        private int _depth;
        public Matrix(int height, int width, int depth)
        {
            _height = height;
            _width = width;
            _depth = depth;
        }

        public int[,,] FillMatrix()
        {            
            int[,,] matrix = new int[_height,_width, _depth];
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(2); j++)
                    {
                        matrix[x,i, j] = r.Next(0, 2);
                    }
                }
            }
            

            return matrix;
        }

        
    }
}
