using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class BlackHat:Filters
    {
        int[,] mask;
        public BlackHat(int[,] mask)
        {
            this.mask = mask;
        }
        public override Bitmap processImage(Bitmap image, System.ComponentModel.BackgroundWorker backgroundWorker1)
        {
            Erosion filtr2 = new Erosion(mask);
            Bitmap erosion = filtr2.processImage(image, backgroundWorker1);

            Dilation filtr1 = new Dilation(mask);
            Bitmap dilation = filtr1.processImage(erosion, backgroundWorker1);

            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                backgroundWorker1.ReportProgress((int)((float)y / result.Height * 100));
                if (backgroundWorker1.CancellationPending)
                    return null;
                for (int x = 0; x < image.Width; x++)
                {
                    Color ImageColor = image.GetPixel(x, y);
                    Color dilationColor = dilation.GetPixel(x, y);

                    int diffR = Clamp(dilationColor.R - ImageColor.R, 0, 255);
                    int diffG = Clamp(dilationColor.G - ImageColor.G, 0, 255);
                    int diffB = Clamp(dilationColor.B - ImageColor.B, 0, 255);

                    Color resultColor = Color.FromArgb(diffR, diffG, diffB);
                    result.SetPixel(x, y, resultColor);
                }
            }
            return result;
        }


        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
