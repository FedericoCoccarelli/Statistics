using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework7._1
{
    public partial class Form1 : Form
    {

        Bitmap b;
        Graphics g;
        Random random = new Random();
        Pen PenTrajectory = new Pen(Color.OrangeRed, 1);
        Pen PenHistogram = new Pen(Color.Black, 3);
        int lastX;
        int lastY;
        int[] results = new int[1000];
        int[] resultsCopy = new int[1000];
        int[] interarrivals;
        int[] interarrivalsCopy;
        Rectangle r, r2, r3;

        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
        }

        public int linearTransformX(double X, double minX, double maxX, int Left, int W)
        {
            return Left + (int)(W * ((X - minX) / (maxX - minX)));
        }

        public int linearTransformY(double Y, double minY, double maxY, int Top, int H)
        {
            return Top + (int)(H - H * ((Y - minY) / (maxY - minY)));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Number of trials: " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Number of trajectories: " + trackBar2.Value.ToString();
            trackBar3.Maximum = trackBar2.Value;
            if (trackBar2.Value<=trackBar3.Value)
            {
                trackBar3.Value = trackBar2.Value;
                label3.Text = "Value of λ: " + trackBar3.Value.ToString();
            }
            
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Value of λ: " + trackBar3.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int TrialsCount = trackBar1.Value;
            double successProbability=(double)((double)trackBar3.Value/ (double)trackBar2.Value);
            int TrajectoryNumber = trackBar2.Value;

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = (double)TrialsCount;

            interarrivals = new int[TrialsCount+1];
            interarrivalsCopy = new int[TrialsCount + 1];

            r = new Rectangle(20, 20, b.Width - 650, b.Height - 40);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            r2 = new Rectangle(r.Right + 10, 20, 200, b.Height - 40);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            r3 = new Rectangle(r2.Right + 10, 20, 390, b.Height - 40);
            g.FillRectangle(Brushes.White, r3);
            g.DrawRectangle(Pens.Black, r3);

            Array.Clear(results, 0, results.Length);

            for (int t = 0; t < TrajectoryNumber; t++)
            {
                lastX = r.Left;
                lastY = r.Bottom;
                int lastSuccess=0;
                double Y = 0;
                PenTrajectory.Color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                PenTrajectory.Width = 2;
                double space = (double)(r3.Width) / (double)(TrialsCount);
                for (int X = 1; X <= TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) { 
                        Y = Y + 1;
                        interarrivals[X - lastSuccess] += 1;
                        lastSuccess = X;
                    }
                    g.DrawLine(PenHistogram, r3.Left + X * (int)(space), b.Height - 20, r3.Left + X * (int)(space), b.Height - interarrivals[X] - 20);

                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);


                    g.DrawLine(PenTrajectory, lastX, lastY, xCord, yCord);
                    lastX = xCord;
                    lastY = yCord;
                    if (X == TrialsCount)
                    {
                        results[lastY] += 3; //histogram bar increases by 1px
                        g.DrawLine(PenHistogram, r2.Left, lastY, r2.Left + results[lastY], lastY);
                    }

                }
                pictureBox1.Image = b;
                pictureBox1.Update();
            }
        }
    }
}