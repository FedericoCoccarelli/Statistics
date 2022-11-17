using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = openFileDialog1.FileName;
            }
        }
        bool hasheader = false;
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            hasheader = false;

            string path = openFileDialog1.FileName;
            string[] lines = File.ReadAllLines(path);
            string[][] jaggedArray = new string[lines.Length][];
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

            string result = string.Join(", ", jaggedArray[0]);
            result += string.Join(", ", header);
            richTextBox1.Text += result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Dictionary<string, int> valuePairs = new Dictionary<string, int>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string value = (string)dataGridView1.Rows[i].Cells[comboBox1.Text].Value;
                if (!valuePairs.ContainsKey(value))
                    valuePairs.Add(value, 1);
                else
                    valuePairs[value]++;
            }

            dataGridView2.Columns.Add(comboBox1.Text, comboBox1.Text);
            dataGridView2.Columns.Add("Distribution", "Distribution");
            foreach (var pair in valuePairs)
                dataGridView2.Rows.Add(pair.Key, $"{pair.Value} / {dataGridView1.Rows.Count}"); 
        */} 
    }
}