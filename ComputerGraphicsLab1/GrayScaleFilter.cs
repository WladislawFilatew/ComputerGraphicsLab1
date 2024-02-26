using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class GrayScaleFilter : Filters
    {
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            int intensity =(int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
            Color newColor = Color.FromArgb(intensity, intensity, intensity);
            return newColor;
        }
    }
}
