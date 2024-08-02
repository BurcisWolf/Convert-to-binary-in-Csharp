using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convertnumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckNumber(string number)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "";
            float parse = 0;
            if(!float.TryParse(number, out parse))
            {
                label4.Text = "Use only numbers!";
            } else {
                textBox2.Text = number;
                textBox3.Text = number;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckNumber(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Convertor";
        }
    }
}
