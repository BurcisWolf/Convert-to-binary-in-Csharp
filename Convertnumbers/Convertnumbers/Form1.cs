using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Made by Tomas Bures

To do
Add how do we count from Dezimal to Hexadezimal, same like we added from Dezimal to Binäry
When press enter it automaticly converts
Chech all fields and convert from desired system to other systems
Converting negative numbers
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
                string erg = "", text = ""; ; // our end result in string
                int r, znumber; // our rest
                while(number > 0){
                    r = number % 2; // count our rest from number, it is always 1 or 0
                    erg = Convert.ToString(r) + erg; // converting our r to string + adding that what we already had to the string
                    znumber = number;
                    number = number / 2; // diving number by 2 to slowly get to the 0
                    text = text + (" Rest = " + r + " | " + znumber + " : 2 = " + number + "\n");
                    label6.Text = Convert.ToString(text);
                }
                textBox2.Text = erg; // writing our result into textBox2
                label6.Text = label6.Text + "\n Wir lesen von unten nach oben";
            }
        }
        private void toHexa(Int32 number)
        {
            if(number == 0)
            {
                textBox3.Text = Convert.ToString(number);
            } else {
                // label4.Text = number.ToString("X");
                // Thats the fastest what we could do , converts numbers direcly into Hexadezimal format
                // ToString("X") means direct convertion, we have more types of method with ToString ...
                string erg = "";
                int r;
                while(number > 0)
                {   
                    r = number % 16;
                    string hexa = r.ToString("X");
                    erg = hexa + erg;
                    number = number / 16;
                }
                textBox3.Text = erg;  
            }
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
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }
    }
}
