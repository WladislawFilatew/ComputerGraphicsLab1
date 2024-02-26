using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class Embossing:MatrixFilter
    {
        public Embossing()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            kernel[1, 0] = kernel[0, 1] = 1;
            kernel[2, 1] = kernel[1, 2] = -1;
        }
    }
}
