using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Final
{
    public partial class Homework5_1 : Form
    {
        string[][] jaggedArray;
        string[] lines;
        Bitmap b;
        Graphics g;
        Pen PenHistogram = new Pen(Color.Red, 3);
        Rectangle r, r2;

        int x_down;
        int y_down;

        int x_mouse;
        int y_mouse;

        int r_width;
        int r_height;

        bool drag = false;
        bool resizing = false;

        public Homework5_1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void pictureBox1_Paint(Graphics e, int x, int y, string text)
        {
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            using (Font myFont = new Font("Arial", 8))
            {
                e.DrawString(text, myFont, Brushes.Green, new Point(x, y), drawFormat);
            }
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
            r = new Rectangle(1, 1, b.Width * 2 / 3 - 3, b.Height - 2);
            r2 = new Rectangle(b.Width * 2 / 3 + 3, 1, 360, b.Height - 2);
            pictureBox1.Image = b;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);


            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            int i = 1;
            int len = jaggedArray.Length - 1;
            int index = Array.IndexOf(jaggedArray[0], comboBox1.Text);
            if (!checkBox1.Checked) { index = int.Parse(comboBox1.Text.Substring(5)) - 1; i = 0; }
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();
            int X = 0;

            for (; i < len; i++)
            {
                string value = (string)jaggedArray[i][index];
                if (!valuePairs.ContainsKey(value))
                    valuePairs.Add(value, 1);
                else
                    valuePairs[value]++;
            }

            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);
            double space = (double)(r.Width - 5) / (double)(valuePairs.Count);
            double space2 = (double)(r2.Height - 10) / (double)(valuePairs.Count);
            dataGridView2.Columns.Add(comboBox1.Text, comboBox1.Text);
            dataGridView2.Columns.Add("Distribution", "Distribution");

            var maxValue = valuePairs.Values.Max();
            float ratio, ratio2;
            if (maxValue < r.Height) { ratio = (float)((double)(0.9 * r.Height - 100) / (double)maxValue); }
            else { ratio = (float)((double)maxValue * 0.9 / (double)(r.Height - 100)); } /*multiplied by 0.9 to make the chart not touch the top of the rectangle */
            if (maxValue < r2.Width) { ratio2 = (float)((double)((r2.Width - 100) * 0.9) / (double)maxValue); }
            else { ratio2 = (float)((double)maxValue * 0.9 / (double)(r2.Width - 100)); }


            foreach (var pair in valuePairs)
            {
                X += 1;
                dataGridView2.Rows.Add(pair.Key, $"{pair.Value} / {valuePairs.Count}");
                g.DrawLine(PenHistogram, r.Left - 5 + X * (float)(space), r.Height - 100, r.Left - 5 + X * (float)(space), r.Height - pair.Value * ratio - 100);
                g.DrawLine(PenHistogram, r2.Left + 100, r2.Top + 5 + X * (float)space2, r2.Left + 100 + pair.Value * ratio2, r2.Top + 5 + X * (float)space2);

                if (space > 8)
                {
                    pictureBox1_Paint(g, r.Left - 13 + (int)(X * space), r.Height - 100, pair.Key);

                }
                else
                {
                    g.DrawString("Too many labels to be represented", new Font("Arial", 8), Brushes.Green, new Point(270, r.Height - 50));
                }
                if (space2 > 8)
                {
                    g.DrawString(pair.Key.Truncate(14), new Font("Arial", 8), Brushes.Green, r2.Left + 10, r2.Top - 3 + X * (float)space2);

                }
                else
                {
                    pictureBox1_Paint(g, r2.Left + 40, r.Height - 250, "Too many labels to be represented");
                }

            }
            g.DrawLine(new Pen(Color.Black, 1), r.Left + 5, r.Height - 100, r.Left - 5 + X * (float)(space), r.Height - 100);
            g.DrawLine(new Pen(Color.Black, 1), r2.Left + 100, r2.Top + 5, r2.Left + 100, r2.Top + 5 + X * (float)space2);


            pictureBox1.Image = b;
        }
    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}