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
        int len = 200;
        int[] resultX = new int[200];
        int[] resultY = new int[200];
        int X;
        double Y;
        Rectangle r3;

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Rectangle r = new Rectangle(1, 1, 201, 201);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            Rectangle r2 = new Rectangle(1, b.Height-202, 201, 201);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            r3 = new Rectangle(202+10, 1, b.Width-213, 418);
            g.FillRectangle(Brushes.White, r3);
            g.DrawRectangle(Pens.Black, r3);
            int[] result = new int[100];
            
           
            for (int i = 0; i < 1000; i++)
            {
                X = random.Next(1, len / 2);
                Y = random.NextDouble(); /* generates a double between 0.0 and 1.0*/
                Y = Y * 2 * Math.PI;

                int realX = (int)(X * Math.Cos(Y));
                int realY = (int)(X * Math.Sin(Y));

                resultX[realX + len / 2] += 1;
                resultY[realY + len / 2] += 1;

            }
            

                for (int i = 0; i < resultX.Length; i += 5)
            {
                g.DrawLine(Penhistogram, i + 4, r.Height, i + 4, r.Height - resultX[i] - resultX[i + 1] - resultX[i + 2] - resultX[i + 3] - resultX[i + 4]);
                g.DrawLine(Penhistogram, i + 4, b.Height+2, i + 4, b.Height+2 - resultY[i] - resultY[i + 1] - resultY[i + 2] - resultY[i + 3] - resultY[i + 4]);

            }

            pictureBox1.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.FillRectangle(Brushes.White, r3);
            g.DrawRectangle(Pens.Black, r3);
            int[] resultX2 = new int[len];
            for (int i = 0; i < resultX.Length; i++)
            {
                resultX2[i] = resultX[i] * resultX[i];
            }

            for (int i = 0; i < resultX.Length; i += 5)
            {
                g.DrawLine(Penhistogram, 202 + 10, i * 2 + 10, 202 + 10 + (resultX2[i] + resultX2[i + 1] + resultX2[i + 2] + resultX2[i + 3] + resultX2[i + 4]), i * 2 + 10);

            }

            pictureBox1.Image = b;
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            g.FillRectangle(Brushes.White, r3);
            g.DrawRectangle(Pens.Black, r3);
            int[] resultX2 = new int[len];
            int[] resultY2 = new int[len];
            for (int i = 0; i < resultX.Length; i++)
            {
                resultX2[i] = resultX[i] * resultX[i];
                resultY2[i] = resultY[i] * resultY[i];
                if (resultY2[i] ==0) { resultY2[i] = 1; }

            }

            for (int i = 0; i < resultX.Length; i += 5)
            {
                g.DrawLine(Penhistogram, 202 + 10, i * 2 + 10, 202 + 10 + (resultX2[i]/resultY2[i] + resultX2[i + 1] / resultY2[i+1] + resultX2[i + 2] / resultY2[i+2] + resultX2[i + 3] / resultY2[i+3] + resultX2[i + 4] / resultY2[i+4]), i * 2 + 10);

            }

            pictureBox1.Image = b;
        }
    }
}