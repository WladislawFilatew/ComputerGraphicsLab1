using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ComputerGraphicsLab1
{
    abstract class Filters
    {
        public virtual Bitmap processImage(Bitmap image, System.ComponentModel.BackgroundWorker backgroundWorker1)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0;i < image.Width; i++)
            {
                backgroundWorker1.ReportProgress((int)((float)i / result.Width * 100));
                if (backgroundWorker1.CancellationPending)
                    return null;
                for (int j = 0; j < image.Height; j++) {
                    result.SetPixel(i, j, NewPixelColor(image, i, j));
                }
            }

            return result;
        }

        protected abstract Color NewPixelColor(Bitmap image, int i, int j);
        public int Clamp(int value,int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
