using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework4._1
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Random random = new Random();
        Pen PenTrajectory = new Pen(Color.OrangeRed, 1);

        public Form1()
        {
            InitializeComponent();
        }

        public int linearTransformX(double X, double minX, double maxX, int Left, int W)
        {
            return Left + (int)(W * ((X - minX) / (maxX - minX)));
        }

        public int linearTransformY(double Y, double minY, double maxY, int Top, int H)
        {
            return Top + (int)(H - H * ((Y - minY) / (maxY - minY)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            int TrialsCount = 100;
            double successProbability = 0.5;
            int TrajectoryNumber = 30;

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = (double)TrialsCount;


            Rectangle r = new Rectangle(20, 20, b.Width - 300, b.Height - 40);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            List<Point> lastpoints = new List<Point>();

            for (int t = 0; t < TrajectoryNumber; t++)
            {
                List<Point> points = new List<Point>();
                double Y = 0;

                for (int X = 0; X < TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) Y = Y + 1;

                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);

                    Point p = new Point(xCord, yCord);
                    points.Add(p);

                    if (X == TrialsCount - 1)
                    {
                        lastpoints.Add(p);
                    }
                }
                g.DrawLines(PenTrajectory, points.ToArray());
            }

            int min_y = lastpoints.Min(p => p.Y);
            int max_y = lastpoints.Max(p => p.Y);

            Rectangle r2 = new Rectangle(r.Right + 10, 20, 260, b.Height - 40);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            pictureBox1.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            int TrialsCount = 100;
            double successProbability = 0.5;
            int TrajectoryNumber = 30;

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = 1;


            Rectangle r = new Rectangle(20, 20, b.Width - 300, b.Height - 40);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            List<Point> lastpoints = new List<Point>();

            for (int t = 0; t < TrajectoryNumber; t++)
            {
                List<Point> points = new List<Point>();
                double Yt = 0;

                for (int X = 0; X < TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) Yt = Yt + 1;

                    double Y = Yt / (X + 1);

                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);

                    Point p = new Point(xCord, yCord);
                    points.Add(p);

                    if (X == TrialsCount - 1)
                    {
                        lastpoints.Add(p);
                    }
                }
                g.DrawLines(PenTrajectory, points.ToArray());
            }

            int min_y = lastpoints.Min(p => p.Y);
            int max_y = lastpoints.Max(p => p.Y);

            Rectangle r2 = new Rectangle(r.Right + 10, 20, 260, b.Height - 40);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            int TrialsCount = 100;
            double successProbability = 0.5;
            int TrajectoryNumber = 30;

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = ((double)TrialsCount) * successProbability;


            Rectangle r = new Rectangle(20, 20, b.Width - 300, b.Height - 40);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            List<Point> lastpoints = new List<Point>();

            for (int t = 0; t < TrajectoryNumber; t++)
            {
                List<Point> points = new List<Point>();
                double Yt = 0;

                for (int X = 0; X < TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) Yt = Yt + 1;

                    double Y = Yt / Math.Sqrt(X + 1);

                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);

                    Point p = new Point(xCord, yCord);
                    points.Add(p);

                    if (X == TrialsCount - 1)
                    {
                        lastpoints.Add(p);
                    }
                }
                g.DrawLines(PenTrajectory, points.ToArray());
            }

            int min_y = lastpoints.Min(p => p.Y);
            int max_y = lastpoints.Max(p => p.Y);

            Rectangle r2 = new Rectangle(r.Right + 10, 20, 260, b.Height - 40);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            pictureBox1.Image = b;
        }
    }
}
