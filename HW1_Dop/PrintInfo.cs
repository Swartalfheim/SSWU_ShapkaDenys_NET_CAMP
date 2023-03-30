namespace HW1_Dop
{
    public class PrintInfo
    {
        private Matrix _matrix;
        private FindHoles _findHoles;
        private int _height;
        private int _width;
        private int _depth;

        public PrintInfo(int height, int width,int depth)
        {            
            _height = height;
            _width = width;
            _depth = depth;
        }

        public void Info()
        {
            _findHoles = new FindHoles(_height, _width, _depth);
            _findHoles.Holes();
        }
    }
}
