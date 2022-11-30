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
            Rectangle r = new Rectangle(1, 1, b.Width - 2, b.Height - 2);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);
            int[] result = new int[100];
            int mean = 10;
            double stddev = 3;
            for (int i = 0; i < 100; i++)
            {
                Random rand = new Random(); //reuse this if you are generating many
                double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                double u2 = 1.0 - rand.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                             Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                double num =
                             mean + stddev * randStdNormal; //random normal(mean,stdDev^2)
                result[i] = (int)num;
            }
            for (int i = 0; i < 100; i ++)
            {
                g.DrawLine(Penhistogram, i*4, b.Height, i*4, b.Height - result[i]*5);
            }
            pictureBox1.Image = b;

        }
    }
}