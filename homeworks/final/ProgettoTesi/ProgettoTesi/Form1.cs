namespace ProgettoTesi
{
    public partial class Form1 : Form
    {

        Bitmap b;
        Graphics g;
        Random random = new Random();
        Pen PenTrajectory = new Pen(Color.OrangeRed, 1);
        Pen PenHistogram = new Pen(Color.Black, 2);
        int lastX;
        int lastY;
        int[] results = new int[2000];

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "0,5";
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int TrialsCount = trackBar1.Value;
            double successProbability;
            Boolean success = Double.TryParse(comboBox1.Text, out successProbability);
            if (!success || (success & (successProbability > 1 || successProbability < 0))) successProbability = 0.5;
            int TrajectoryNumber = trackBar2.Value;

            Rectangle r = new Rectangle(20, 20, b.Width - 300, b.Height - 40);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);

            Rectangle r2 = new Rectangle(r.Right + 10, 20, 260, b.Height - 40);
            g.FillRectangle(Brushes.White, r2);
            g.DrawRectangle(Pens.Black, r2);

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = (double)TrialsCount;

            Array.Clear(results, 0, results.Length);
            double sum = 0;

            for (int t = 0; t < TrajectoryNumber; t++)
            {
                
                lastX = r.Left;
                lastY = r.Bottom;
                double Y = 0;
                PenTrajectory.Color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                PenTrajectory.Width = 2;
                for (int X = 1; X <= TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) Y = Y + 1;
                    else Y = Y - 1;

                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);

                    g.DrawLine(PenTrajectory, lastX, lastY-r.Height/2, xCord, yCord - r.Height / 2);
                    lastX = xCord;
                    lastY = yCord;
                    if (X == TrialsCount)
                    {
                        results[lastY] += 5; //histogram bar increases by 5px 
                        g.DrawLine(PenHistogram, r2.Left, lastY - r.Height / 2, r2.Left + results[lastY], lastY - r.Height / 2);

                        sum += Y;

                        pictureBox1.Image = b;
                        pictureBox1.Update();
                    }
                    pictureBox1.Image = b;
                }

            }
            double mean = ((float)sum/(double)TrajectoryNumber);
            richTextBox1.Text = mean.ToString();
            richTextBox2.Text = ((int)(TrialsCount * (2* successProbability-1))).ToString();
        }

        public int linearTransformX(double X, double minX, double maxX, int Left, int W)
        {
            return Left + (int)(W * ((X - minX) / (maxX - minX)));
        }

        public int linearTransformY(double Y, double minY, double maxY, int Top, int H)
        {
            return Top + (int)(H - H * ((Y - minY) / (maxY * 2 - minY)));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Number of trials: " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Number of trajectories: " + trackBar2.Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}