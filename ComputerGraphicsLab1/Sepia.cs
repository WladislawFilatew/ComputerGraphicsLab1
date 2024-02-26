using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class Sepia : Filters
    {
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            int intensity = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
            int k = 30;
            Color newColor = Color.FromArgb(Clamp((int)(intensity + 0.5 * k),0,255), Clamp((int)(intensity + 0.5 * k), 0, 255), Clamp(intensity - k, 0, 255));
            return newColor;
        }
    }
}
