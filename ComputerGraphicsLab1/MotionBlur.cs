using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class MotionBlur:MatrixFilter
    {
        public MotionBlur(int n)
        {
            kernel = new float[n, n];
            for (int i = 0;i < n; i++)
            {
                kernel[i,i] = (1.0f / n);
            }
        }
    }
}
