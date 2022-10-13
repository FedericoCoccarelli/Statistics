namespace Homework2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] values = new int[10];
        Random random = new Random();
        Random r = new Random();
        int time;


        int ticks = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "Start")
            {
                timer1.Start();
                button1.Text = "Stop";
                progressBar1.Value = 0;

            }
            else if (button1.Text == "Stop")
            {
                timer1.Stop();
                button1.Text = "Start";
                progressBar1.Value = 100;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int d = random.Next(1,10);
            ticks++;
            

            if (d == 1)
            {
                this.richTextBox1.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 2)
            {
                this.richTextBox2.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 3)
            {
                this.richTextBox3.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 4)
            {
                this.richTextBox4.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 5)
            {
                this.richTextBox5.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 6)
            {
                this.richTextBox6.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 7)
            {
                this.richTextBox7.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 8)
            {
                this.richTextBox8.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
            if (d == 9)
            {
                this.richTextBox9.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            }
        }
    }
}