using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class Form1 : Form
    {
        Bitmap b, b2, b3;
        Graphics g,g2,g3;
        Random random = new Random();
        Pen Penhistogram = new Pen(Color.Black, 3);
        int X;
        double Y;
        int[] resultX,resultY;


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            b3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);

            g = Graphics.FromImage(b);
            g2 = Graphics.FromImage(b2);
            g3 = Graphics.FromImage(b3);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Rectangle r = new Rectangle(1,1,b.Width-2,b.Height-2);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);
            resultX = new int[b.Width];
            resultY = new int[b.Width];


            for (int i=0;i<1000;i++)
            {
                X = random.Next(1, b.Width/2);
                Y = random.NextDouble(); /* generates a double between 0.0 and 1.0*/
                Y = Y * 2*Math.PI;

                int realX = (int)(X * Math.Cos(Y));
                int realY = (int)(X * Math.Sin(Y));

                resultX[realX+b.Width/2] += 1;
                resultY[realY + b.Width / 2] += 1;


                g.FillRectangle(Brushes.Black, realX+b.Width/2, realY+b.Width/2, 2, 2);

            }
            
            for (int i=0;i<resultX.Length;i+=5)
            {
                g2.DrawLine(Penhistogram, i, b2.Height, i, b2.Height - resultX[i] - resultX[i+1] - resultX[i+2] - resultX[i+3] - resultX[i+4]);
                g3.DrawLine(Penhistogram, 1 , b3.Height - i, 1 + resultY[i] + resultY[i + 1] + resultY[i + 2] + resultY[i + 3] + resultY[i + 4],b3.Height-i);
            }

            pictureBox1.Image = b;
            pictureBox2.Image = b2;
            pictureBox3.Image = b3;
            pictureBox1.Update();
            pictureBox2.Update();
            pictureBox3.Update();

        }
    }
}
