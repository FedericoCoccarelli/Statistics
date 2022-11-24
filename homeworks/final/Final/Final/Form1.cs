namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }

            Form2_1 h2_1 = new Form2_1();
            h2_1.StartPosition = FormStartPosition.Manual;
            h2_1.Location = new Point(0,50);
            h2_1.TopLevel = false;
            h2_1.TopMost = true;
            this.Controls.Add(h2_1);
            h2_1.ControlBox = false;
            h2_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h2_1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }
            Form2_2 h2_2 = new Form2_2();
            h2_2.StartPosition = FormStartPosition.Manual;
            h2_2.Location = new Point(0, 50);
            h2_2.TopLevel = false;
            h2_2.TopMost = true;
            this.Controls.Add(h2_2);
            h2_2.ControlBox = false;
            h2_2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h2_2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }
            Form3_1 h3_1 = new Form3_1();
            h3_1.StartPosition = FormStartPosition.Manual;
            h3_1.Location = new Point(0, 50);
            h3_1.TopLevel = false;
            h3_1.TopMost = true;
            this.Controls.Add(h3_1);
            h3_1.ControlBox = false;
            h3_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h3_1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }
            Form4_1 h4_1 = new Form4_1();
            h4_1.StartPosition = FormStartPosition.Manual;
            h4_1.Location = new Point(0, 50);
            h4_1.TopLevel = false;
            h4_1.TopMost = true;
            this.Controls.Add(h4_1);
            h4_1.ControlBox = false;
            h4_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h4_1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }
            Homework5_1 h5_1 = new Homework5_1();
            h5_1.StartPosition = FormStartPosition.Manual;
            h5_1.Location = new Point(0, 50);
            h5_1.TopLevel = false;
            h5_1.TopMost = true;
            this.Controls.Add(h5_1);
            h5_1.ControlBox = false;
            h5_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h5_1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
            {
                if (!object.ReferenceEquals(Application.OpenForms[i], this))
                {
                    Application.OpenForms[i].Close();
                }
            }
            Form5_2 h5_2 = new Form5_2();
            h5_2.StartPosition = FormStartPosition.Manual;
            h5_2.Location = new Point(0, 50);
            h5_2.TopLevel = false;
            h5_2.TopMost = true;
            this.Controls.Add(h5_2);
            h5_2.ControlBox = false;
            h5_2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            h5_2.Show();
        }
    }
}