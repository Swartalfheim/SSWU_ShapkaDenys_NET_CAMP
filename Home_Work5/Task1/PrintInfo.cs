using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PrintInfo
    {
        private Fence _fence;
        public void Print()
        {
            _fence = new Fence();
            _fence.Treatment();
        }
    }
}
