using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class brightness_2 : Filters
    {
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            Color newColor = Color.FromArgb(Clamp((color.R + 255) / 2, 0, 255), Clamp((color.G + 255) / 2, 0, 255), Clamp((color.B + 255) / 2, 0, 255));
            return newColor;
        }
    }
}
