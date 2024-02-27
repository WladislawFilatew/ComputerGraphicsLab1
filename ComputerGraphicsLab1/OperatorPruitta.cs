using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class OperatorPruitta:MatrixFilter
    {
        public OperatorPruitta()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = kernel[1,0] = kernel[2, 0] = -1;
            kernel[0, 2] = kernel[1,2] = kernel[2, 2] = 1;
        }
    }
}
