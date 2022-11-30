using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Homework1_1 : Form
    {
        public Homework1_1()
        {
            InitializeComponent();
        }

        private void Homework1_1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            Random r = new Random();
            this.richTextBox1.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
