using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework4._1
{
    public partial class Form1 : Form
    {
        public int width = 0;
        public int height = 500;
        public Bitmap b, b2;
        public Graphics g, g2;
        Pen pen = new Pen(Color.Green);
        private Random r = new Random();
        public int[] results;
        public double parametro = (0.5);
        public Pen pen3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void disegna(int result)
        {
            if (result == 0)
            {
                g.DrawLine(pen, width, height, width + 20, height);
                width += 20;
            }
            else
            {
                g.DrawLine(pen, width, height, width + 20, height - 20);
                width += 20;
                height -= 20;
            }
            pictureBox1.Image = b;
        }
        public void disegna2(int result)
        {
            float x = 0;
            if (result == 0)
            {

            }
            else
            {
                ns++;
            }
            x = (ns / np) * (float)500.0;

            g.DrawLine(pen, width, height, width + 20, x);
            pictureBox1.Image = b;
            width += 20;
            height = (int)x;
        }

        public void disegna3(int result)
        {
            float x = 0;
            if (result == 0)
            {

            }
            else
            {
                ns++;
            }
            x = (float)((ns / (float)Math.Sqrt(np)) * ((float)500.0 / ((5.7))));

            g.DrawLine(pen, width, height, width + 20, 500 - x);
            pictureBox1.Image = b;
            width += 20;
            height = 500 - (int)x;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            results = new int[501];
            b = new Bitmap(600, 500);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen2 = new Pen(Color.Black);
            pictureBox1.Image = b;

            b2 = new Bitmap(500, 500);
            g2 = Graphics.FromImage(b2);
            pen3 = new Pen(Color.Black);
            pen3.Width = 5;
            pictureBox2.Image = b2;
            Array.Clear(results, 0, results.Length);
            for (int j = 0; j < trackBar1.Value; j++)
            {
                for (int i = 0; i < trackBar2.Value; i++)
                {
                    if (r.Next(1000) >= 1000 * parametro)
                        disegna(1);
                    else
                        disegna(0);

                }
                if (height <= 500 && height > 0)
                {
                    results[height] += 2; //i put 2 because i want to make the histogram bigger
                    g2.DrawLine(pen3, 0, height, results[height], height);
                }
                else
                {
                    results[0]++;
                    g2.DrawLine(pen3, 0, 0, results[0], 0);
                }
                pictureBox2.Image = b2;
                pictureBox2.Update();
                width = 0;
                height = 500;
                pictureBox1.Update();
                pen.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                pen.Width = 2;
            }
        }
        public float ns = 0;
        public float np = 0;



        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Number of trajectories: " + trackBar1.Value.ToString();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Number of trials: " + trackBar2.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            results = new int[501];
            b = new Bitmap(600, 500);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen2 = new Pen(Color.Black);
            pictureBox1.Image = b;

            b2 = new Bitmap(500, 500);
            g2 = Graphics.FromImage(b2);
            pen3 = new Pen(Color.Black);
            pen3.Width = 5;
            pictureBox2.Image = b2;
            Array.Clear(results, 0, results.Length);
            for (int j = 0; j < trackBar1.Value; j++)
            {
                ns = 0;
                np = 0;
                for (int i = 0; i < 30; i++)
                {
                    np++;
                    if (r.Next(1000) >= 1000 * parametro)
                        disegna2(1);
                    else
                        disegna2(0);
                }
                if (height < 500 && height > 0)
                    results[height] += 2;
                g2.DrawLine(pen3, 0, height, results[height], height);
                pictureBox2.Image = b2;
                pictureBox2.Update();
                width = 0;
                height = 500;
                pictureBox1.Update();
                pen.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                pen.Width = 2;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            results = new int[501];
            b = new Bitmap(600, 500);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen2 = new Pen(Color.Black);
            pictureBox1.Image = b;

            b2 = new Bitmap(500, 500);
            g2 = Graphics.FromImage(b2);
            pen3 = new Pen(Color.Black);
            pen3.Width = 5;
            pictureBox2.Image = b2;
            Array.Clear(results, 0, results.Length);
            for (int j = 0; j < trackBar1.Value; j++)
            {
                ns = 0;
                np = 0;
                for (int i = 0; i < 30; i++)
                {
                    np++;
                    if (r.Next(1000) >= 1000 * parametro)
                        disegna3(1);
                    else
                        disegna3(0);


                }
                if (height < 500 && height > 0)
                    results[height] += 2;
                g2.DrawLine(pen3, 0, height, results[height], height);
                pictureBox2.Image = b2;
                pictureBox2.Update();
                width = 0;
                height = 500;
                pictureBox1.Update();
                pen.Color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                pen.Width = 2;
            }
        }
    }
}