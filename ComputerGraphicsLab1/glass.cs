using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class glass : Filters
    {
        protected override Color NewPixelColor(Bitmap image, int k, int l)
        {
            Random rand = new Random();
            int x = (int)(k +(rand.Next(0,2) - 0.5) * 10);
            int y = (int)(l + (rand.Next(0,2) - 0.5) * 10);
            if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
            {
                return image.GetPixel(k, l);
            }
            return image.GetPixel(x, y);
        }
    }
}
