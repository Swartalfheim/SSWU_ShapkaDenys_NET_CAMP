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
        public int Perimetr()
        {
            int countx = 0;
            int county = 0;
            _fence = new Fence();
            foreach (var item in _fence.Treatment())
            {
                countx = countx - item[0];
                county = county - item[1];
            }

            _perimeter = (int)Math.Sqrt((countx * countx) + (county * county));
            string p = Convert.ToString(_perimeter);
            File.WriteAllText("E:\\SSWU_ShapkaDenys_NET_CAMP\\Home_Work5\\Task1\\log.txt", p);
            return _perimeter;
        }
    }
}
