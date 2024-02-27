using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class GreyWorld : Filters
    {
        double R, G, B;
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
                    R += image.GetPixel(i, j).R;
                    G += image.GetPixel(i, j).G;
                    B += image.GetPixel(i, j).B;
                }
            }
            R /= image.Width * image.Height; G /= image.Width * image.Height; B /= image.Width * image.Height;
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
            double Avg = (R + G + B) / 3;
            Color color = image.GetPixel(i, j);
            Color newColor = Color.FromArgb(Clamp((int)(color.R * Avg / R),0,255), Clamp((int)(color.G * Avg / G), 0, 255), Clamp((int)(color.B * Avg / B), 0, 255));
            return newColor;
        }
    }
}
