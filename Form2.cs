using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3in1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void closeApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        string randomGenAll()
        {
            Random rand = new Random();
            int value;
            char ch;
            string result = "";
            for (int a = 0; a<10; a++)
            {
                value = rand.Next(33, 122);
                ch = Convert.ToChar(value);
                result += ch;
            }
            return result;
        }

        string randomGenLN()
        {
            Random rand = new Random();
            int value;
            char ch;
            string result = "";
            for (int a = 0; a < 10; a++)
            {
                do
                {
                    value = rand.Next(48, 122);
                }
                while ((value>57 && value<65)||(value>90&&value<97));
                ch = Convert.ToChar(value);
                result += ch;
            }
            return result;
        }

        string randomGenLe()
        {
            Random rand = new Random();
            int value;
            char ch;
            string result = "";
            for (int a = 0; a < 10; a++)
            {
                do
                {
                    value = rand.Next(65, 122);
                }
                while (value > 90 && value < 97);
                ch = Convert.ToChar(value);
                result += ch;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = "";
            if(radioButton1.Checked)
            {
                password = randomGenAll();
            }
            else if(radioButton2.Checked)
            {
                password = randomGenLN();
            }
            else if(radioButton3.Checked)
            {
                password = randomGenLe();
            }
            label1.Text = password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label1.Text!="PASSWORD")
            Clipboard.SetText(label1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
