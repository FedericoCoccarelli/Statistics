using System.Windows.Forms;

namespace Homework2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Random random = new Random();
        Random r = new Random();
        int tempo;
        int ticks = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out time)) {}
            else { time = 500; time = 500; }
            progressBar1.Maximum = time;

            if (button1.Text == "Start")
            {
                timer1.Start();
                button1.Text = "Stop";
                progressBar1.Value = time;
                ticks = 0;

            }
            else if (button1.Text == "Stop")
            {
                timer1.Stop();
                button1.Text = "Start";
                progressBar1.Value = 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int count = 1; count <= 9; count++)
            {
                RichTextBox currentBox = (RichTextBox)this.Controls.Find("richTextBox" + count, true)[0];
                currentBox.BackColor = Color.White;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int d = random.Next(1, 10);

            if (progressBar1.Value >= 1) { progressBar1.Value -= 1; }
            if (ticks > time) {
                timer1.Stop();
                this.button1.Text = "Start";
                ticks = 0;
            }
            if (ticks++ < time)
            {
                RichTextBox currentBox = (RichTextBox)this.Controls.Find("richTextBox" + d, true)[0];
                currentBox.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));   
            }
        }
    }
}