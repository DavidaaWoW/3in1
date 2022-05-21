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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text != "PASSWORD")
                Clipboard.SetText(label1.Text);
        }

        bool enteredNumberCheck(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return false;
            if (textBox2.Text == "")
            {
                if (e.KeyChar == '0')
                    return true;
                else
                    return false;
            }
            else if (textBox2.Text == "1")
            {
                if (e.KeyChar > '5')
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

        private void onEnter2(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar!='A' && e.KeyChar!='B'&&e.KeyChar!='C'&&e.KeyChar!='D'&&e.KeyChar!='E'&&e.KeyChar!='F')
            {
                e.Handled = true;
            }
        }

        bool parseText(string text, char max)
        {
            for(int a = 0; a<text.Length; a++)
            {
                if (text[a] > max)
                    return false;
            }
            return true;
        }

        bool allowDecode()
        {
            string text = textBox1.Text;
            if(textBox1.Text.Length!=80 || textBox2.Text=="")
            {
                return false;
            }
            else
            {
                switch (textBox2.Text)
                {
                    case "1":
                        if (parseText(text, '1'))
                            return true;
                        else
                            return false;
                        break;
                    case "2":
                        if (parseText(text, '2'))
                            return true;
                        else
                            return false;
                        break;
                    case "3":
                        if (parseText(text, '3'))
                            return true;
                        else
                            return false;
                        break;
                    case "4":
                        if (parseText(text, '4'))
                            return true;
                        else
                            return false;
                        break;
                    case "5":
                        if (parseText(text, '5'))
                            return true;
                        else
                            return false;
                        break;
                    case "6":
                        if (parseText(text, '6'))
                            return true;
                        else
                            return false;
                        break;
                    case "7":
                        if (parseText(text, '7'))
                            return true;
                        else
                            return false;
                        break;
                    case "8":
                        if (parseText(text, '8'))
                            return true;
                        else
                            return false;
                        break;
                    case "9":
                        if (parseText(text, '9'))
                            return true;
                        else
                            return false;
                        break;
                    case "10":
                        if (parseText(text, 'A'))
                            return true;
                        else
                            return false;
                        break;
                    case "11":
                        if (parseText(text, 'B'))
                            return true;
                        else
                            return false;
                        break;
                    case "12":
                        if (parseText(text, 'C'))
                            return true;
                        else
                            return false;
                        break;
                    case "13":
                        if (parseText(text, 'D'))
                            return true;
                        else
                            return false;
                        break;
                    case "14":
                        if (parseText(text, 'E'))
                            return true;
                        else
                            return false;
                        break;
                    case "15":
                        if (parseText(text, 'F'))
                            return true;
                        else
                            return false;
                        break;
                    default:
                        return false;


                }
            }
        }

        char turnToTen(string num, int key)
        {
            int result = 0;
            for(int a = 0; a<8; a++)
            {
                if(char.IsDigit(num[a]))
                {
                    result += (num[a] - 48)*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                }
                else
                {
                    switch(num[a])
                    {
                        case 'A':
                            result += 10*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        case 'B':
                            result += 11*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        case 'C':
                            result += 12*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        case 'D':
                            result += 13*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        case 'E':
                            result += 14*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        case 'F':
                            result += 15*Convert.ToInt32(Math.Pow(key+1, num.Length - (a + 1)));
                            break;
                        default:
                            break;
                    }
                }
            }
            return Convert.ToChar(result-key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!allowDecode())
            {
                MessageBox.Show("You can't use some of this symbols with key" , "ERROR");
                return;
            }
            char[] sym = new char[10];
            char[] num = new char[8];
            int temp = 0;
            string k;
            for (int b = 0; b < 10; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    num[a] = textBox1.Text[temp];
                    temp++;
                }
                sym[b] = turnToTen(k = new string(num), Convert.ToInt32(textBox2.Text));
            }
            string result = new string(sym);
            label1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            for(int a = 0; a<text.Length; a++)
            {
                if(!Char.IsDigit(text[a]) && (text[a]!='A' && text[a]!='B' && text[a]!='C' && text[a]!='D' && text[a]!='E' && text[a]!='F'))
                {
                    return;
                }
            }
            textBox1.Text = text;
        }
    }
}
