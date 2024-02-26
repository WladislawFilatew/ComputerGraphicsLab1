using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class turn:Filters
    {
        int x0, y0;
        double u;
        public turn(int x0, int y0 ,double u) 
        {
            this.x0 = x0;
            this.y0 = y0;
            this.u = u;
        }
        protected override Color NewPixelColor(Bitmap image, int k, int l)
        {
            int x = (int)((k - x0) * Math.Cos(u) - (l - y0) * Math.Sin(u) + x0);
            int y = (int)((k - x0) * Math.Sin(u) + (l - y0) * Math.Cos(u) + y0);
            if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
            {
                return Color.Black;
            }
            return image.GetPixel(x, y);
        }
    }
}
