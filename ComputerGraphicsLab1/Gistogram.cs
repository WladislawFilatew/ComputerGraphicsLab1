using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class Gistogram : Filters
    {
        int max_y = 0, min_y = 255;
        public override Bitmap processImage(Bitmap image, System.ComponentModel.BackgroundWorker backgroundWorker1)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                backgroundWorker1.ReportProgress((int)((float)i / result.Width * 50));
                if (backgroundWorker1.CancellationPending)
                    return null;
                for (int j = 0; j < image.Height; j++)
                {
                    Color color = image.GetPixel(i, j);
                    max_y = Math.Max(max_y,color.R);
                    min_y = Math.Min(min_y,color.R);
                }
            }
            
            for (int i = 0; i < image.Width; i++)
            {
                backgroundWorker1.ReportProgress(50 + (int)((float)i / result.Width * 50));
                if (backgroundWorker1.CancellationPending)
                    return null;
                for (int j = 0; j < image.Height; j++)
                {
                    result.SetPixel(i, j, NewPixelColor(image, i, j));
                }
            }

            return result;
        }

        protected override Color NewPixelColor(Bitmap image, int i, int j)
        {
            Color color = image.GetPixel(i, j);
            int k = Clamp((color.R - min_y) * 255 / (max_y - min_y), 0, 255);
            Color newColor = Color.FromArgb(k,k,k);
            return newColor;
        }
    }
}
