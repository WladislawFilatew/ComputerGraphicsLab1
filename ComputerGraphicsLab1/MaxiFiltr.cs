using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class MaxiFiltr:Filters
    {
        int r;
        public MaxiFiltr(int r)
        {
            this.r = r;
        }
        protected override Color NewPixelColor(Bitmap image, int x, int y)
        {
            List<Color> colors = new List<Color>();
            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {
                    if (x + i >= image.Width || x + i < 0 || y + j >= image.Height || y + j < 0)
                        continue;
                    colors.Add(image.GetPixel(x + i, y + j));
                }
            }
            colors.Sort((c1, c2) => c1.ToArgb().CompareTo(c2.ToArgb()));

            return colors[colors.Count - 1];
        }
    }
}
