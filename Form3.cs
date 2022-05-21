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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        bool enteredNumberCheck(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return false;
            if(textBox1.Text=="")
            {
                if (e.KeyChar == '0')
                    return true;
                else
                return false;
            }
            else if(textBox1.Text=="1")
            {
                if(e.KeyChar > '5')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        private void onEnter(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back || enteredNumberCheck(e))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            textBox1.Text = Convert.ToString(rand.Next(1, 15));
        }

        string getRem(int k)
        {
            if (k < 10)
                return Convert.ToString(k);
            else
            {
                switch (k)
                {
                    case 10:
                        return "A";
                        break;
                    case 11:
                        return "B";
                        break;
                    case 12:
                        return "C";
                        break;
                    case 13:
                        return "D";
                        break;
                    case 14:
                        return "E";
                        break;
                    case 15:
                        return "F";
                        break;
                    default:
                        return "0";
                }
            }
        }

        string systemConvert(int first, int second)
        {
            string result = "";
            int temp;
            while(first>=second)
            {
                temp = first % second;
                result += getRem(temp);
                first /= second;
            }
            result += getRem(first);
            string output = new string(result.Reverse().ToArray());
            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string k = "";
            string text = "";
            if(textBox2.Text.Length<10 || textBox1.Text == "")
            {
                return;
            }
            int[] numbers = new int[10];
            int temp;
            for(int a = 0; a<10; a++)
            {
                numbers[a] = Convert.ToInt32(textBox2.Text[a]);
                k += systemConvert(numbers[a] + Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox1.Text) + 1);
                temp = 8-k.Length;
                for(int b = 0; b<temp; b++)
                {
                    text += '0';
                }
                text += k;
                k = "";
                temp = 0;
            }
            label1.Text = text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();
        }
    }
}
