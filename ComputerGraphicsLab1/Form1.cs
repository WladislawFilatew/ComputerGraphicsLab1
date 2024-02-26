using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ComputerGraphicsLab1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Queue<Filters> filters;
        List<Bitmap> images;

        public Form1()
        {
            InitializeComponent();
            filters = new Queue<Filters>();
            images = new List<Bitmap>();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image;
                images.Add(image);
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new InvertFilter());
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            filters.Clear();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = image;
            while (!backgroundWorker1.CancellationPending)
            {
                if (filters.Count != 0)
                {
                    Filters filtr = filters.Dequeue();
                    newImage = filtr.processImage(newImage, backgroundWorker1);
                }
                else
                {
                    break;
                }
            }
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                images.Add(image);
                if (images.Count > 10)
                {
                    images.RemoveAt(0);
                }
            }
            progressBar1.Value = 0;
            

        }

        private void отенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayScaleFilter filtr = new GrayScaleFilter();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepia filtr = new Sepia();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void увеличитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightness filtr = new brightness(10);
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
             
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
               
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filtr = new BlurFilter();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void гауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filtr = new GaussianFilter();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void собеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filtr = new Sobel();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filtr = new sharpness();
            filters.Enqueue(filtr);
            backgroundWorker1.RunWorkerAsync();
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new GrayScaleFilter());
            filters.Enqueue(new Embossing());
            filters.Enqueue(new brightness_2());
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new transfer(50, 50));
            backgroundWorker1.RunWorkerAsync();
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new turn((int)(image.Width / 2), (int)(image.Height / 2) ,Math.PI / 4));
            backgroundWorker1.RunWorkerAsync();
        }

        private void типToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new Wave(1));
            backgroundWorker1.RunWorkerAsync();
        }

        private void типToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new Wave(2));
            backgroundWorker1.RunWorkerAsync();
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters.Enqueue(new glass());
            backgroundWorker1.RunWorkerAsync();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (images.Count > 1)
            {
                images.RemoveAt(images.Count - 1);
                image = images[images.Count - 1];
                pictureBox1.Image = image;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
    }
}
