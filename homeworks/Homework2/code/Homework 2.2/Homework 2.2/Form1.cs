using Microsoft.VisualBasic.FileIO;
namespace Homework_2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var path = @"C:\Users\Corsair\OneDrive\Cybersecurity\Statistics\Statistics Homeworks\homeworks\Homework2\code\Homework 2.2\trees.csv";
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Corsair\OneDrive\Cybersecurity\Statistics\Statistics Homeworks\homeworks\Homework2\code\Homework 2.2\trees.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                    //Process row
                var strings = File.ReadAllLines(path);
                foreach (var s in strings)
                {
                    var fields = s.Split(",");

                    foreach (var field in fields)
                        richTextBox1.Text = richTextBox1.Text + field;
                }
            }
        }
    }
}