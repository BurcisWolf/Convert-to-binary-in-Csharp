using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Made by Tomas Bures
2.8.2024 - Made basic look and basic funktions we will need

To do
Convert to Hexadezimal
Convert also negative number
 */

namespace Convertnumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void toBinar(Int32 number)
        {
            if(number == 0){
                textBox2.Text = Convert.ToString(number); // If input is 0 than write back 0
            } else { 
                string erg = ""; // our end result in string
                int r; // our rest
                while(number > 0){
                    r = number % 2; // count our rest from number, it is always 1 or 0
                    erg = Convert.ToString(r) + erg; // converting our r to string + adding that what we already had to the string
                    number = number / 2; // diving number by 2 to slowly get to the 0
                }
                textBox2.Text = erg; // writing our result into textBox2
            }
        }
        private void toHexa(Int32 number)
        {
            // to do
        }
        private void CheckNumber(string number)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "";
            float parse; // Float variable
            if(!float.TryParse(number, out parse)) { // If it is not numbers print something
                label4.Text = "Use only numbers!"; // Printing text in label4
            } else { // If is it number do some stuff
                toBinar(Convert.ToInt32(number)); // Calling funktion toBinar and also converting string to Int32
                toHexa(Convert.ToInt32(number));
            }
            //Int32 = Value from 0 to 4 294 967 295
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckNumber(textBox1.Text); // Callling a funktion CheckNumbers
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Convertor";
        }
    }
}
