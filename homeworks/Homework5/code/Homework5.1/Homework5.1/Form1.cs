using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

namespace Homework5._1
{
    public partial class Form1 : Form
    {
        string[][] jaggedArray;
        string[] lines;
        Bitmap b;
        Graphics g;
        Pen PenHistogram = new Pen(Color.Red, 3);
        EditableRectangle r;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Paint(Graphics e,int x,int y,string text)
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);


            r = new EditableRectangle(1, 1, b.Width-2 , b.Height - 2,pictureBox1,this);
            g.FillRectangle(Brushes.White, r.r);
            g.DrawRectangle(Pens.Black, r.r);

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
            }
            else
            {
                for (int i = 0; i < lines[0].Split(',').Length; i++)
                {;
                    comboBox1.Items.Add(jaggedArray[0][i]);
                }
            }
            pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            int i = 1;
            int len = jaggedArray.Length-1;
            int index = Array.IndexOf(jaggedArray[0], comboBox1.Text);
            if (!checkBox1.Checked) { index =int.Parse(comboBox1.Text.Substring(5))-1; i = 0; }
            richTextBox1.Text += index.ToString();
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

            double space = (double)(r.r.Width) / (double)(valuePairs.Count);
            dataGridView2.Columns.Add(comboBox1.Text, comboBox1.Text);
            dataGridView2.Columns.Add("Distribution", "Distribution");
            foreach (var pair in valuePairs)
            {
                X += 1;
                dataGridView2.Rows.Add(pair.Key, $"{pair.Value} / {valuePairs.Count}");
                g.DrawLine(PenHistogram,r.r.Left +X * (int)(space), r.r.Height -100, r.r.Left+X * (int)(space), r.r.Height-pair.Value-100);
                if (space > 8)
                {
                    pictureBox1_Paint(g, r.r.Left + X * (int)(space) - 8, r.r.Height - 100, pair.Key);
                }

            }
            g.DrawLine(new Pen(Color.Black, 1), r.r.Left, r.r.Height - 100, r.r.Left + X * (int)(space), r.r.Height - 100);
            pictureBox1.Image = b;
        }
    }
    class EditableRectangle
    {
        public Rectangle r;
        PictureBox p;
        Form f;

        public EditableRectangle(int X, int Y, int Width, int Heigth, PictureBox pb, Form fo)
        {
            r = new Rectangle(X, Y, Width, Heigth);
            p = pb;
            f = fo;

            pb.MouseUp += new MouseEventHandler(editableRect_Up);
            pb.MouseDown += new MouseEventHandler(editableRect_Down);
            pb.MouseMove += new MouseEventHandler(editableRect_Move);

            f.MouseWheel += new MouseEventHandler(editableRect_Zoom);
        }

        int x_down;
        int y_down;

        int x_mouse;
        int y_mouse;

        int r_width;
        int r_height;

        bool drag = false;
        bool resizing = false;

        double ScaleFact = 0.1d;

        int hoverX;
        int hoverY;

        private void editableRect_Down(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_mouse = e.X;
                y_mouse = e.Y;

                x_down = r.X;
                y_down = r.Y;

                r_width = r.Width;
                r_height = r.Height;

                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    resizing = true;
                }
            }
        }

        private void editableRect_Up(object sender, MouseEventArgs e)
        {
            drag = false;
            resizing = false;
        }

        private void editableRect_Move(object sender, MouseEventArgs e)
        {
            hoverX = e.X;
            hoverY = e.Y;

            int delta_x = e.X - x_mouse;
            int delta_y = e.Y - y_mouse;

            if (drag)
            {
                r.X = x_down + delta_x;
                r.Y = y_down + delta_y;
            }
            else if (resizing)
            {
                r.Width = r_width + delta_x;
                r.Height = r_height + delta_y;
            }
        }

        private void editableRect_Zoom(object sender, MouseEventArgs e)
        {

            int pictx = hoverX;
            int picty = hoverY;

            if (r.Contains(pictx, picty))
            {
                x_down = r.X;
                y_down = r.Y;

                r.Width = r.Width + (int)(e.Delta * ScaleFact);
                r.Height = r.Height + (int)(e.Delta * ScaleFact);

                r.X = x_down - (int)((e.Delta * ScaleFact) / 2);
                r.Y = y_down - (int)((e.Delta * ScaleFact) / 2);
            }
        }
    }
}