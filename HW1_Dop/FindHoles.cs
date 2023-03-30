using System;

namespace HW1_Dop
{
    public class FindHoles
    {
        private Matrix _matrix;
        private int _height;
        private int _width;
        private int[,] _mat;
        public FindHoles(int height, int width)
        {
            _height = height;
            _width = width;
        }        
        public void Holes()
        {
            _matrix = new Matrix(_height, _width);
            _mat = new int[_height,_width];
            for (int i = 0; i < _matrix.FillMatrix().GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.FillMatrix().GetLength(1); j++)
                {
                    _mat[i, j] = _matrix.FillMatrix()[i, j];
                }
            }

            int num = 0;
            int jump = 0;
            string Line = "";
            string Сolumn = "";
            string DiagonalR = "";
            string DiagonalL = "";
            for (int i = 0; i < _mat.GetLength(0); i++)
            {
                for (int j = 0; j < _mat.GetLength(1); j++)
                {
                    Console.Write("{0,2}",_mat[i,j]);                    
                    if (_mat[i,j]==0)
                    {
                        num++;
                    }
                }
                if (num==_width)
                {
                    Line = Line + Convert.ToString(i+1) + "; ";
                }
                Console.WriteLine();
                num = 0;
            }
            num = 0;
            for (int i = 0; i < _mat.GetLength(0); i++)
            {
                for (int j = 0; j < _mat.GetLength(1); j++)
                {
                    if (_mat[j,i]==0)
                    {
                        num++;
                    }
                }
                if (num == _height)
                {
                    Сolumn = Сolumn + Convert.ToString(i + 1)+"; ";
                }
                Console.WriteLine();
                num = 0;
                
            }
            num = 0;
            for (int i = 0; i < _mat.GetLength(0); i++)
            {
                for (int j = 0; j < _mat.GetLength(1); j++)
                {                  
                    
                    if (_mat[i,j]==0)
                    {
                        if (jump==_height-1)
                        {
                            num++;
                            jump = 0;
                        }
                        
                    }
                    jump++;                    
                }
                if (num == _height)
                {
                    DiagonalR = "Right diagonal";
                }
            }
            num = 0;
            jump = _height+1;
            for (int i = 0; i < _mat.GetLength(0); i++)
            {
                for (int j = 0; j < _mat.GetLength(1); j++)
                {
                    if (jump==0)
                    {
                        jump = _height + 1;
                    }
                    if (jump==_height+1)
                    {
                        if (_mat[i,j]==0)
                        {
                            num++;
                        }
                        
                    }
                    jump--;
                }
                if (num == _height)
                {
                    DiagonalL = "Left diagonal";
                }
            }
            Console.WriteLine();            
            Console.WriteLine("Rows with a through hole: " + Line);
            Console.WriteLine("Сolumn with a through hole: " + Сolumn);
            Console.WriteLine("Diagonal with a through hole: " + DiagonalR);
            Console.WriteLine("Diagonal with a through hole: " + DiagonalL);

        }
    }
}
