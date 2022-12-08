using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Homework_8_2
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Pen penna = new Pen(Color.Gray, 0.5F);
        Bitmap b;
        Graphics g;
        Pen Penhistogram = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g = Graphics.FromImage(b);
            this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.g.Clear(Color.White);

            Rectangle rettangolo = new Rectangle(0, 0, this.b.Width - 1, this.b.Height - 1);
            g.DrawRectangle(Pens.Black, rettangolo);

            double minValue = -20;
            double maxValue = 20;


            if (this.radioButton1.Checked)
            {
                minValue = -3;
                maxValue = 3;
            }

            else if (this.radioButton2.Checked)
            {
                minValue = 0;
                maxValue = 4;
            }

            else if (this.radioButton3.Checked)
            {
                minValue = -8;
                maxValue = 8;
            }

            else if (this.radioButton4.Checked)
            {
                minValue = 0;
                maxValue = 4;
            }

            else if (this.radioButton5.Checked)
            {
                minValue = -10;
                maxValue = 10;
            }

            double delta = maxValue - minValue;
            double intervalSize = delta / 150;


            int punti = 3000;

            //Definizione dizionario
            Dictionary<double, int> dizionario = new Dictionary<double, int>();
            double tempValue = 0;
            for (int i = 0; i <= 150; i++)
            {
                tempValue = minValue + (intervalSize * i);
                tempValue = Math.Round(tempValue, 2);
                dizionario[tempValue] = 0;
            }

            int total = 0;

            for (int x = 0; x < punti; x++)
            {
                double xRnd = (r.NextDouble() * 2) - 1;
                double value = 0;
                double yRnd = (r.NextDouble() * 2) - 1;

                double s = (xRnd * xRnd) + (yRnd * yRnd);

                while (s < 0 || s > 1)
                {
                    xRnd = (r.NextDouble() * 2) - 1;
                    yRnd = (r.NextDouble() * 2) - 1;
                    s = (xRnd * xRnd) + (yRnd * yRnd);
                }

                xRnd *= Math.Sqrt(-2 * Math.Log(s) / s);
                yRnd *= Math.Sqrt(-2 * Math.Log(s) / s);

                if (this.radioButton1.Checked) value = xRnd;
                else if (this.radioButton2.Checked) value = xRnd * xRnd;
                else if (this.radioButton3.Checked) value = xRnd / (yRnd * yRnd);
                else if (this.radioButton4.Checked) value = (xRnd * xRnd) / (yRnd * yRnd);
                else if (this.radioButton5.Checked) value = xRnd / yRnd;

                foreach (double key in dizionario.Keys)
                {
                    double range = key + intervalSize;
                    if (range > maxValue)
                    {
                        range = maxValue;
                    }
                    if (value < range && value > key)
                    {
                        dizionario[key] += 1;
                        if (total < dizionario[key])
                        {
                            total = dizionario[key];
                        }
                        break;
                    }
                }
            }

            g.TranslateTransform(0, this.b.Height);
            g.ScaleTransform(1, -1);

            int cnt = 0;
            int widthI = (int)(this.b.Width / 150);
            int j = 0;
            int len = dizionario.Count;
            int space = rettangolo.Width / len;
            foreach (double key in dizionario.Keys)
            {
                j++;
                int heightI = dizionario[key] * this.b.Height / total;
                int newX = (widthI * cnt) + 1;
                g.DrawLine(Penhistogram, j*space, 0, j*space, heightI);
                cnt++;

                 
            }

            this.pictureBox1.Image = b;
        }

    }
}