using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ComputerGraphicsLab1
{
    internal class MatrixFilter :Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel) {
            this.kernel = kernel;
        }

        protected override Color NewPixelColor(Bitmap image, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusX; l <= radiusX; l++)
            {
                for (int k = -radiusY; k <= radiusY; k++)
                {
                    int idX = Clamp(x + l, 0, image.Width - 1);
                    int idY = Clamp(y + k,0, image.Height - 1);
                    Color newColor = image.GetPixel(idX, idY);
                    resultR += newColor.R * kernel[l + radiusX,k + radiusY];
                    resultG += newColor.G * kernel[l + radiusX, k + radiusY];
                    resultB += newColor.B * kernel[l + radiusX, k + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }
}
