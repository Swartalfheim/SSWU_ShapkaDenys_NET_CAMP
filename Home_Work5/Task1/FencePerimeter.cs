using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FencePerimeter
    {
        private Fence _fence;
        private int _perimeter;
        private ArrangementOfTrees _arrangementOfTrees;
        public int Perimetr1()
        {
            int countx = 0;
            int county = 0;
            _arrangementOfTrees = new ArrangementOfTrees();
            _fence = new Fence();
            foreach (var item in _fence.Treatment(_arrangementOfTrees.Arrangement()))
            {
                countx = countx - item[0];
                county = county - item[1];
            }

            _perimeter = (int)Math.Sqrt((countx * countx) + (county * county));
            string p = Convert.ToString(_perimeter);
            File.WriteAllText("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work5\\Task1\\log.txt", p);
            return _perimeter;
        }

        public int Perimetr()
        {
            int countx = 0;
            int county = 0;
            _arrangementOfTrees = new ArrangementOfTrees();
            _fence = new Fence();
            foreach (var item in _fence.Treatment(_arrangementOfTrees.Arrangement1()))
            {
                countx = countx - item[0];
                county = county - item[1];
            }

            _perimeter = (int)Math.Sqrt((countx * countx) + (county * county));
            string p = Convert.ToString(_perimeter);
            File.WriteAllText("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work5\\Task1\\log.txt", p);
            return _perimeter;
        }

        public bool Less()
        {
            return Perimetr1() < Perimetr();
        }

        public bool More()
        {
            return Perimetr1() > Perimetr();
        }

        public bool Equals()
        {
            return Perimetr1() == Perimetr();
        }

        public bool NotEqual()
        {
            return Perimetr1() != Perimetr();
        }

        public bool LessEquals()
        {
            return Perimetr1() <= Perimetr();
        }

        public bool MoreEqual()
        {
            return Perimetr1() >= Perimetr();
        }
    }
}
