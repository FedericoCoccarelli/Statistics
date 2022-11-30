namespace Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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