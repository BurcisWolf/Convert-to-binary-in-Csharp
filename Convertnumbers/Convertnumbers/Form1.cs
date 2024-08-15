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
Made by Tomas Bures | https://github.com/BurcisWolf | https://www.burcis.eu

To do:
Convert from Hexadezimal to others
Convert from Binär to others
Check all fields and convert from desired system to other systems // do as last
When press enter it automaticly converts the input into other systems
Converting negative numbers // as last
add button or something (About app, who made it etc)
Maybe change the format from Int32 to something else ? Int32 = Value from 0 to 4 294 967 295
Automatic size of a window
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
                }
                textBox2.Text = erg; // writing our result into textBox2
                label6.Text = text + "\n Wir lesen von unten nach oben";
            }
        }
        private void toHexa(Int32 number)
        {
            if(number == 0){
                textBox3.Text = Convert.ToString(number);
            } else {
                // label4.Text = number.ToString("X");
                // Thats the fastest what we could do , converts numbers direcly into Hexadezimal format
                // ToString("X") means direct convertion, we have more types of method with ToString ...
                string erg = "", text = "";
                int r, znumber;
                while(number > 0){   
                    r = number % 16;
                    string hexa = r.ToString("X");
                    znumber = number;
                    erg = hexa + erg;
                    number = number / 16;
                    text = text + "Rest = " + r.ToString("X") + " | " + znumber + " : 16 = " + number + "\n";
                }
                textBox3.Text = erg;
                label7.Text = text + "\nLesen von unten nach oben";
            }
        }
        private void CheckNumber(string number)
        {
            float parse; // Float variable | Only True or False
            if(!float.TryParse(number, out parse)) { // If it is not numbers print something or empty
                label4.Text = "Wrong Input!"; // Printing text in label4
            } else { // If is it number do some stuff
                toBinar(Convert.ToInt32(number)); // Calling funktion toBinar and also converting string to Int32
                toHexa(Convert.ToInt32(number));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           CheckNumber(textBox1.Text); // Callling a funktion CheckNumbers
           textBox1.Focus(); // sets a focus on the object - Cursor in textbox
        }
        private void checkHexa(string input)
        {
            if (!string.IsNullOrEmpty(input)) {
                char[] singleChar = input.ToCharArray(); //splitting our input (whole word in a single characters in an array)
                string splitted = "";
                foreach (char charakter in singleChar)
                {
                    splitted = splitted + charakter + "\n";
                }
                label7.Text = splitted;
            } else {
                label4.Text = "Wrong Input!";
            }
            
        }
        private void checkBinar(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {

            } else
            {
                label4.Text = "Wrong Input!";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen(); // centering element in the middle of the screen
            this.Text = "Convertor"; // changing name of the app (the thing we see at the top)
            this.Width = 650; 
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }
        private void Reset()
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
            checkHexa(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            checkBinar(textBox2.Text);
        }
    }
}
