using System;
using static System.Windows.Forms.DataFormats;

namespace Homework8._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static double SampleGaussian(Random random, double mean, double stddev)
        {
            // The method requires sampling from a uniform random of (0,1]
            // but Random.NextDouble() returns a sample of [0,1).
            double x1 = 1 - random.NextDouble();
            double x2 = 1 - random.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return y1 * stddev + mean;
        }

        Bitmap b;
        Graphics g;
        Random random = new Random();
        Pen Penhistogram = new Pen(Color.Black, 3);

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Rectangle r = new Rectangle(1, 1, 201, 201);
            Rectangle r2 = new Rectangle(1, 201, 201, 201);

            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);
            int[] result = new int[100];
            int X;
            double Y;
            int len = 200;
            int[] resultX = new int[len];
            int[] resultY = new int[len];
            for (int i = 0; i < 1000; i++)
            {
                X = random.Next(1, len/2);
                Y = random.NextDouble(); /* generates a double between 0.0 and 1.0*/
                Y = Y * 2 * Math.PI;

                int realX = (int)(X * Math.Cos(Y));
                int realY = (int)(X * Math.Sin(Y));

                resultX[realX + len / 2] += 1;
                resultY[realY + len / 2] += 1;

            }

            for (int i = 0; i < len; i += 5)
            {
                g.DrawLine(Penhistogram, 4+i, 200,4+ i, 200 - resultX[i] - resultX[i + 1] - resultX[i + 2] - resultX[i + 3] - resultX[i + 4]);
                g.DrawLine(Penhistogram, 4 + i, 400, 4 + i, 400 - resultY[i] - resultY[i + 1] - resultY[i + 2] - resultY[i + 3] - resultY[i + 4]);

            }
            pictureBox1.Image = b;

        }
    }
}