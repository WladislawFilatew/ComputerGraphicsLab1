using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class transfer : Filters
    {
        int k, l;
        public transfer(int k,int l) {
           this.k = k;
           this.l = l;
        }
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            if (i < k || j < l)
            {
                return Color.Black;
            }
            return image.GetPixel(i - k,j - l);
        }
    }
}
