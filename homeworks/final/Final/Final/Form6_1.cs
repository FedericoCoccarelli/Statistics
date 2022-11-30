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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final
{
    public partial class Form6_1 : Form
    {
        public Form6_1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void Form6_1_Load(object sender, EventArgs e)
        {

        }
    
        string[][] jaggedArray;
        string[] lines;
        Bitmap b;
        Graphics g;
        Pen PenHistogram = new Pen(Color.Red, 3);
        Rectangle r, r2;
        Random random = new Random();

        int x_down;
        int y_down;

        int x_mouse;
        int y_mouse;

        int r_width;
        int r_height;

        bool drag = false;
        bool resizing = false;

        int samples;
        int size;

        private void pictureBox1_Paint(Graphics e, int x, int y, string text)
        {
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            using (Font myFont = new Font("Arial", 8))
            {
                e.DrawString(text, myFont, Brushes.Green, new Point(x, y), drawFormat);
            }
        }

        private bool isNumeric(string[][] array, int index)
        {
            int i = 0;
            if (checkBox1.Checked) { i = 1; }
            bool ret = true;
            for (; i < array.Length; i++)
            {
                if (!int.TryParse(array[i][index], out _)) { ret = false; }
            }
            return ret;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Number of samples: " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Samples size: " + trackBar2.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = openFileDialog1.FileName;
            }
            button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);


            string path = openFileDialog1.FileName;
            lines = File.ReadAllLines(path);
            jaggedArray = new string[lines.Length][];
            string[] header = new string[lines[0].Split(',').Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] strArray = lines[i].Split(',');
                jaggedArray[i] = strArray;

            }

            if (!checkBox1.Checked)
            {
                for (int i = 0; i < lines[0].Split(',').Length; i++)
                {
                    header[i] = "Field" + (i + 1).ToString();
                    comboBox1.Items.Add(header[i]);
                }
                comboBox1.Text = header[0];
            }
            else
            {
                for (int i = 0; i < lines[0].Split(',').Length; i++)
                {
                    ;
                    comboBox1.Items.Add(jaggedArray[0][i]);

                }
                comboBox1.Text = jaggedArray[0][0];
            }
            r = new Rectangle(1, 1, b.Width / 2 - 3, b.Height - 2);
            r2 = new Rectangle(b.Width / 2 + 3, 1, b.Width / 2 - 4, b.Height - 2);
            int len = jaggedArray.Length;
            if (checkBox1.Checked) { len -= 1; }
            trackBar1.Maximum = len;
            trackBar2.Maximum = len;
            pictureBox1.Image = b;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int len = jaggedArray.Length;
            int k = 1;
            int index = 0;
            if (checkBox1.Checked) { len -= 1; index = Array.IndexOf(jaggedArray[0], comboBox1.Text); }
            if (!checkBox1.Checked) { index = int.Parse(comboBox1.Text.Substring(5)) - 1; k = 0; }
            progressBar1.Value = 0;
            progressBar1.Maximum = trackBar1.Value * 101;

            if (isNumeric(jaggedArray, index))
            {
                int realmean = 0;
                for (int i = 1; i < jaggedArray.Length; i++)
                {
                    realmean += int.Parse(jaggedArray[i][index]);
                }
                realmean = (int)((double)realmean / (double)jaggedArray.Length);

                int realvariance = 0;
                for (int i = 1; i < jaggedArray.Length; i++)
                {
                    realvariance += (realmean - int.Parse(jaggedArray[i][index])) * (realmean - int.Parse(jaggedArray[i][index]));
                }
                realvariance = (int)((double)realvariance / (double)len);
                realvariance = (int)Math.Sqrt(realvariance);

                if (!checkBox1.Checked) { index = int.Parse(comboBox1.Text.Substring(5)) - 1; k = 0; }
                int X = 0;
                int[] results = new int[trackBar1.Value];
                int[] varianceresults = new int[trackBar1.Value];
                for (int i = 0; i < trackBar1.Value; i++)
                {
                    int[] numbers = new int[trackBar2.Value];
                    int number = 0;
                    int sum = 0;
                    for (int j = 0; j < trackBar2.Value; j++)
                    {
                        do
                        {
                            if (checkBox1.Checked) { number = random.Next(0, len + 1); }
                            else { number = random.Next(0, len); }
                        } while (numbers.Contains(number));
                        numbers[j] = number;
                        sum += int.Parse(jaggedArray[number][index]);
                    }
                    progressBar1.Value += 100;
                    int mean = (int)((double)sum / (double)trackBar2.Value);
                    results[i] = mean;

                    int variance = 0;
                    for (int j = 0; j < trackBar2.Value; j++)
                    {
                        variance += (realmean - int.Parse(jaggedArray[numbers[j]][index])) * (realmean - int.Parse(jaggedArray[numbers[j]][index]));
                    }
                    variance = (int)((double)variance / (double)trackBar2.Value);
                    variance = (int)Math.Sqrt(variance);
                    varianceresults[i] = variance;
                }

                for (int i = 0; i < trackBar2.Value; i++)
                {

                }


                progressBar1.Value = progressBar1.Maximum;
                int maxValue = results.Max();
                int maxValue2 = varianceresults.Max();

                g.FillRectangle(Brushes.White, r);
                g.DrawRectangle(Pens.Black, r);
                g.FillRectangle(Brushes.White, r2);
                g.DrawRectangle(Pens.Black, r2);
                double space = (double)(r.Width - 5) / (double)(trackBar1.Value + 1);
                double space2 = (double)(r2.Height - 10) / (double)(trackBar1.Value + 1);

                float ratio, ratio2;
                if (maxValue < r.Height) { ratio = (float)((double)(0.9 * r.Height - 100) / (double)maxValue); } /*multiplied by 0.9 to make the chart not touch the top of the rectangle */
                else { ratio = (float)((double)maxValue * 0.9 / (double)(r.Height - 100)); }
                if (maxValue2 < r2.Height) { ratio2 = (float)((double)((r2.Height - 100) * 0.9) / (double)maxValue2); }
                else { ratio2 = (float)((double)maxValue2 * 0.9 / (double)(r2.Height - 100)); }


                for (int i = 0; i < trackBar1.Value; i++)
                {
                    X += 1;
                    g.DrawLine(new Pen(Color.Blue, 3), r.Left - 5 + (float)(space), r.Height - 100, r.Left - 5 + (float)(space), r.Height - realmean * ratio - 100);
                    g.DrawLine(new Pen(Color.Blue, 3), r2.Left - 5 + (float)(space), r2.Height - 100, r2.Left - 5 + (float)(space), r2.Height - realvariance * ratio2 - 100);

                    g.DrawLine(PenHistogram, r.Left - 5 + (X + 1) * (float)(space), r.Height - 100, r.Left - 5 + (X + 1) * (float)(space), r.Height - results[i] * ratio - 100);
                    g.DrawLine(PenHistogram, r2.Left - 5 + (X + 1) * (float)(space), r2.Height - 100, r2.Left - 5 + (X + 1) * (float)(space), r2.Height - varianceresults[i] * ratio2 - 100);

                    /*g.DrawLine(PenHistogram, r2.Left + 100, r2.Top + 5 + X * (float)space2, r2.Left + 100 + results[i] * ratio2, r2.Top + 5 + X * (float)space2); */

                    if (space > 8)
                    {
                        pictureBox1_Paint(g, r.Left - 13 + (int)((X + 1) * space), r.Height - 100, (i + 1).ToString());
                        pictureBox1_Paint(g, r2.Left - 13 + (int)((X + 1) * space), r2.Height - 100, (i + 1).ToString());
                        pictureBox1_Paint(g, r.Left - 13 + (int)((1) * space), r.Height - 100, "Real Mean");
                        pictureBox1_Paint(g, r2.Left - 13 + (int)((1) * space), r2.Height - 100, "Real Variance");

                    }
                    else
                    {
                        g.DrawString("Too many labels to be represented", new Font("Arial", 8), Brushes.Green, new Point(270, r.Height - 50));
                        g.DrawString("Too many labels to be represented", new Font("Arial", 8), Brushes.Green, new Point(r2.Left + 270, r2.Height - 50));
                    }
                }
                g.DrawLine(new Pen(Color.Black, 1), r.Left + 5, r.Height - 100, r.Left - 5 + (X + 1) * (float)(space), r.Height - 100);
                g.DrawLine(new Pen(Color.Black, 1), r2.Left + 5, r2.Height - 100, r2.Left - 5 + (X + 1) * (float)(space), r2.Height - 100);


                pictureBox1.Image = b;

            }
            else
            {
                richTextBox1.Text = "The chosen field has no numeric values";
            }

        }
    }
}
