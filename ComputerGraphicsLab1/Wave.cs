using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class Wave : Filters
    {
        int tip;
       public  Wave(int t)
        {
            tip = t;
        }
        protected override Color NewPixelColor(Bitmap image, int k, int l)
        {
            if (tip == 1)
            {
                int x = (int)(k + 20 * Math.Sin(2 * Math.PI  * l  / 60));
                int y = l;
                if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
                {
                    return image.GetPixel(k, l);
                }
                return image.GetPixel(x, y);
            }
            else
            {
                int x = (int)(k + 20 * Math.Sin(2 * Math.PI * k / 30));
                int y = l;
                if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
                {
                    return image.GetPixel(k,l);
                }
                return image.GetPixel(x, y);
            }
        }
    }
}
