using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class InvertFilter : Filters
    {
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            Color NewColor = Color.FromArgb(255 - color.R,255 - color.G, 255 -  color.B);
            return NewColor;

        }
    }
}
