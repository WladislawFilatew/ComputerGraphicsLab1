using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class brightness : Filters
    {
        int k;
        public brightness(int k)
        {
            this.k = k;
        }
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            Color newColor = Color.FromArgb(Clamp(color.R + k, 0, 255), Clamp(color.G + k, 0, 255), Clamp(color.B + k, 0, 255));
            return newColor;
        }
    }
}
