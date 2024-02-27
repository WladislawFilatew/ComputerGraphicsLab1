using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    internal class Erosion :Filters
    {
        int[,] mask;
        public Erosion(int[,] mask)
        {
            this.mask = mask;
        }

        public override Bitmap processImage(Bitmap image, System.ComponentModel.BackgroundWorker backgroundWorker1)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int Width = image.Width;
            int Height = image.Height;
            int MW = mask.GetLength(0);
            int MH = mask.GetLength(1);
            for (int y = MH / 2; y < Height - MH / 2; y++)
            {
                backgroundWorker1.ReportProgress((int)((float)y / result.Height * 100));
                if (backgroundWorker1.CancellationPending)
                    return null;
                for (int x = MW / 2; x < Width - MW / 2; x++)
                {
                    int min = 255;
                    for (int j = -MH / 2; j <= MH / 2; j++)
                    {
                        for (int i = -MW / 2; i <= MW / 2; i++)
                        {
                            if ((mask[MW / 2 + i, MH / 2 + j] == 1) && (image.GetPixel(Clamp(x + i, 0, Width - 1), Clamp(y + j, 0, Height - 1)).R < min))
                            {
                                min = image.GetPixel(Clamp(x + i, 0, Width - 1), Clamp(y + j, 0, Height - 1)).R;
                            }
                        }
                    }
                    result.SetPixel(x, y, Color.FromArgb(min, min, min));
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

