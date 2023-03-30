using System;

namespace HW1_Dop
{
    public class FindHoles
    {
        private Matrix _matrix;
        private int _height;
        private int _width;
        private int _depth;
        private int[,,] _mat;
        public FindHoles(int height, int width, int depth)
        {
            _height = height;
            _width = width;
            _depth = depth;
        }        
        public void Holes()
        {
            _matrix = new Matrix(_height, _width, _depth);
            _mat = new int[_height,_width, _depth];            
            for (int x = 0; x < _matrix.FillMatrix().GetLength(0); x++)
            {
                for (int i = 0; i < _matrix.FillMatrix().GetLength(1); i++)
                {
                    for (int j = 0; j < _matrix.FillMatrix().GetLength(2); j++)
                    {
                        _mat[x,i, j] = _matrix.FillMatrix()[x,i, j];
                    }
                    
                }
            }

            int num = 0;
            int jump = 0;
            string Line = "";
            string Сolumn = "";
            string DiagonalR = "";
            string DiagonalL = "";
            for (int x = 0; x < _mat.GetLength(0); x++)
            {
                for (int i = 0; i < _mat.GetLength(1); i++)
                {
                    for (int j = 0; j < _mat.GetLength(2); j++)
                    {
                        if (_mat[x, i, j] == 0)
                        {
                            num++;
                        }
                    }
                    if (num == _width)
                    {
                        Line = Line + "In layer number: " + Convert.ToString(x + 1) + " column number " + Convert.ToString(i + 1) +"; ";
                    }
                    Console.WriteLine();
                    num = 0;
                }
            }
           
            num = 0;
            for (int x = 0; x < _mat.GetLength(0); x++)
            {
                for (int i = 0; i < _mat.GetLength(1); i++)
                {
                    for (int j = 0; j < _mat.GetLength(2); j++)
                    {
                        if (_mat[x,j, i] == 0)
                        {
                            num++;
                        }
                    }
                    if (num == _height)
                    {
                        Сolumn = Сolumn + "In layer number: " + Convert.ToString(x + 1)+ " column number " + Convert.ToString(i + 1) + "; ";
                    }
                    Console.WriteLine();
                    num = 0;

                }
            }
            num = 0;
            for (int x = 0; x < _mat.GetLength(0); x++)
            {
                for (int i = 0; i < _mat.GetLength(1); i++)
                {
                    for (int j = 0; j < _mat.GetLength(2); j++)
                    {

                        if (_mat[x,i, j] == 0)
                        {
                            if (jump == _height - 1)
                            {
                                num++;
                                jump = 0;
                            }

                        }
                        jump++;
                    }
                    if (num == _height)
                    {
                        DiagonalR = "In layer number: "+Convert.ToString(x + 1)+" Right diagonal; ";
                    }
                }
            }
            num = 0;
            jump = _height+1;
            for (int x = 0; x < _mat.GetLength(0); x++)
            {
                for (int i = 0; i < _mat.GetLength(1); i++)
                {
                    for (int j = 0; j < _mat.GetLength(2); j++)
                    {
                        if (jump == 0)
                        {
                            jump = _height + 1;
                        }
                        if (jump == _height + 1)
                        {
                            if (_mat[x,i, j] == 0)
                            {
                                num++;
                            }

                        }
                        jump--;
                    }
                    if (num == _height)
                    {
                        DiagonalL ="In layer number: "+ Convert.ToString(x + 1) + " Left diagonal; ";
                    }
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
