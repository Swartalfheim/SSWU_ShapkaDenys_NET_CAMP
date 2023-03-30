namespace HW1_Dop
{
    public class PrintInfo
    {
        private Matrix _matrix;
        private FindHoles _findHoles;
        private int _height;
        private int _width;

        public PrintInfo(int height, int width)
        {            
            _height = height;
            _width = width;
        }

        public void Info()
        {
            _findHoles = new FindHoles(_height,_width);
            _findHoles.Holes();
        }
    }
}
