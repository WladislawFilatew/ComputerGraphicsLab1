using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class reference_color : Filters
    {
        Color source;
        Color result;
        public reference_color(Color source, Color result) {
            this.source = source;
            this.result = result;
        }
        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            Color newColor = Color.FromArgb(Clamp((int)(color.R * result.R / source.R), 0, 255), Clamp((int)(color.G * result.G / source.G), 0, 255), Clamp((int)(color.B * result.B / source.B), 0, 255));
            return newColor;
        }
    }
}
