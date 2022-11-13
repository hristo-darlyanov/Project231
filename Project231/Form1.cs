using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project231
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            List<double> nums = new List<double>();
            string[] str = text.Split(' ');
            foreach (var item in str)
            {
                nums.Add(double.Parse(item));
            }

            averageLabel.Text.Remove(0);
            averageLabel.Text = "Average: " + Average(nums);

            medianLabel.Text.Remove(0);
            medianLabel.Text = "Median: " + Median(nums);

            modeLabel.Text.Remove(0);
            modeLabel.Text = "Mode: " + Mode(nums);

            histogram.Series[0].Points.Clear();
            foreach (double item in nums)
            {
                histogram.Series[0].Points.Add(item);
            }
        }

        private double Median(List<double> list)
        {
            list.Sort();
            if (list.Count % 2 != 0)
            {
                return list[list.Count / 2];
            }
            return (list[list.Count / 2] + list[(list.Count-1) / 2]) / 2;
        }

        private double Average(List<double> list)
        {
            double sum = 0;
            foreach (double item in list)
            {
                sum += item;
            }
            return sum/ list.Count;
        }

        private double Mode(List<double> list)
        {
            double mode = 0;
            int maxcount = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        count++;
                    }
                }
                if (count > maxcount)
                {
                    mode = list[i];
                    maxcount = count;
                }
            }
            return mode;
        }

        private void histogram_Click(object sender, EventArgs e)
        {

        }
    }
}
