using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Windows.Forms;

namespace Homework3._1
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
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            comboBox1.Items.Clear();
            hasheader = false;

            string path = openFileDialog1.FileName;
            var strings = File.ReadAllLines(path);
            string[] row = strings[0].Split(",");

            if (!checkBox1.Checked)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    dataGridView1.Columns.Add("Field" + (i + 1).ToString(), "Field" + (i + 1).ToString());
                    comboBox1.Items.Add("Field" + (i + 1).ToString());
                }
                hasheader = true;
            }

            int length = strings.Length;
            foreach (var s in strings)
            {
                var fields = s.Split(",");

                if (!hasheader)
                {
                    foreach (var field in fields)
                    {
                        dataGridView1.Columns.Add(field, field);
                        comboBox1.Items.Add(field);
                    }
                    hasheader = true;
                }
                else
                    dataGridView1.Rows.Add(fields);
            }
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();

            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

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
        }
    }
}