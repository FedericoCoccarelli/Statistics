using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series["Salary"].Points.AddXY("Peter", 1000);
            chart1.Series["Salary"].Points.AddXY("John", 5000);
            chart1.Series["Salary"].Points.AddXY("Tan", 1500);
            chart1.Series["Salary"].Points.AddXY("Lucy", 7000);
            chart1.Series["Salary"].Points.Add(1000);
            chart1.Series["Salary"].Points[0].Color = Color.Red;
            chart1.Series["Salary"].Points[0].AxisLabel = "Peter";
            chart1.Series["Salary"].Points[0].LegendText = "Peter";
            chart1.Series["Salary"].Points[0].Label = "1000";
            //Init data
            chart1.Series["Salary"].Points.Add(5000);
            chart1.Series["Salary"].Points[1].Color = Color.Green;
            chart1.Series["Salary"].Points[1].AxisLabel = "John";
            chart1.Series["Salary"].Points[1].LegendText = "John";
            chart1.Series["Salary"].Points[1].Label = "5000";
            //
            chart1.Series["Salary"].Points.Add(1500);
            chart1.Series["Salary"].Points[2].Color = Color.Yellow;
            chart1.Series["Salary"].Points[2].AxisLabel = "Tan";
            chart1.Series["Salary"].Points[2].LegendText = "Tan";
            chart1.Series["Salary"].Points[2].Label = "1500";
            //
            chart1.Series["Salary"].Points.Add(7000);
            chart1.Series["Salary"].Points[3].Color = Color.Blue;
            chart1.Series["Salary"].Points[3].AxisLabel = "Lucy";
            chart1.Series["Salary"].Points[3].LegendText = "Lucy";
            chart1.Series["Salary"].Points[3].Label = "7000";
        }
    }
}
