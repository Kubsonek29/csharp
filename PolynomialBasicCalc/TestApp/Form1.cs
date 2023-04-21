using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TestApp
{
    public partial class PolynomialCalc : Form
    {
        public PolynomialCalc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.SelectedIndex = 0;
            label1.Text = "Wielomian1";
            label2.Text = "Wielomian2";
            label3.Text = "Zmienne(int) = 'X' || 'x' oraz bez odstepów";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label3.Font = new Font("Arial", 14, FontStyle.Bold);
            button2.Text = "Calculate!";
            button1.Text = "Exit";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string wielomian1;
            string wielomian2;
            wielomian1 = richTextBox1.Text;
            wielomian2 = richTextBox2.Text;
            try
            {
                if (wielomian1=="")
                {
                    throw new Exception("Pusty wielomian: wielomian1");
                }
                if (wielomian1[0] == '^')
                {
                    throw new Exception("Bledny wielomian1");
                }
                for (int i = 0; i < wielomian1.Length; i++)
                {
                    if (wielomian1[i]!='^' && wielomian1[i]!='X' && wielomian1[i] != 'x' && wielomian1[i] != '+' && wielomian1[i] != '-' && wielomian1[i] != '0' && wielomian1[i] != '1' && wielomian1[i] != '2' && wielomian1[i] != '3' && wielomian1[i] != '4' && wielomian1[i] != '5' && wielomian1[i] != '6' && wielomian1[i] != '7' && wielomian1[i] != '8' && wielomian1[i] != '9')
                    {
                        throw new Exception("Bledny wielomian w polu: wielomian1");
                    }
                    if (i + 1 < wielomian1.Length && (wielomian1[i] == 'X' || wielomian1[i] == 'x') && (wielomian1[i + 1] != '^' && wielomian1[i + 1] != '+' && wielomian1[i + 1] != '-') || (wielomian1[i]== '+' && wielomian1[i+1] == '+') || (wielomian1[i] == '-' && wielomian1[i+1] == '-') || (wielomian1[i] == '^' && (wielomian1[i+1] == '+' || wielomian1[i + 1] == '-' || wielomian1[i + 1] == 'X')))
                    {
                        throw new Exception("Blednie wpisany wielomian: wielomian1");
                    }
                }
                if (wielomian2 == "")
                {
                    throw new Exception("Pusty wielomian: wielomian2");
                }
                if (wielomian2[0] == '^')
                {
                    throw new Exception("Bledny wielomian2");
                }
                for(int i = 0; i < wielomian2.Length; i++)
                {
                    if (wielomian2[i] != '^' && wielomian2[i] != 'X' && wielomian2[i] != 'x' && wielomian2[i] != '+' && wielomian2[i] != '-' && wielomian2[i] != '0' && wielomian2[i] != '1' && wielomian2[i] != '2' && wielomian2[i] != '3' && wielomian2[i] != '4' && wielomian2[i] != '5' && wielomian2[i] != '6' && wielomian2[i] != '7' && wielomian2[i] != '8' && wielomian2[i] != '9')
                    {
                        throw new Exception("Bledny wielomian w polu: wielomian2");
                    }
                    if (i+1<wielomian2.Length && (wielomian2[i] == 'X' || wielomian2[i] == 'x') && (wielomian2[i + 1] != '^' && wielomian2[i + 1] != '+' && wielomian2[i + 1] != '-') || (wielomian2[i] == '+' && wielomian2[i + 1] == '+') || (wielomian2[i] == '-' && wielomian2[i + 1] == '-') || (wielomian2[i] == '^' && (wielomian2[i + 1] == '+' || wielomian2[i + 1] == '-' || wielomian2[i + 1] == 'X')))
                    {
                        throw new Exception("Blednie wpisany wielomian: wielomian2");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            wielomian w1 = new wielomian(wielomian1);
            wielomian w2 = new wielomian(wielomian2);
            wielomian output = new wielomian();
            if (comboBox1.SelectedIndex == 0)
            {
                output = w1 + w2;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                output = w1 - w2;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                output = w1 * w2;
            }
            MessageBox.Show("Wynik = " + output.output());
        }
    }
}
internal class wielomian
{
    public int st;
    public dynamic wsp;
    public wielomian()
    {
        st = 0;
        wsp = new dynamic[1];
        wsp = 0;
    }
    public wielomian(int st, dynamic wsp)
    {
        this.st = st;
        this.wsp = new dynamic[st + 1];
        for(int i = 0; i < st+1; i++)
        {
            this.wsp[i] = wsp[i];
        }
    }
    public wielomian(string Wstring)
    {
        string tmp1 = null;
        string tmp2 = null;
        ////////obrobka
        if (Wstring[0] == 'X' || Wstring[0] == 'x')
        {
            Wstring = '1' + Wstring;
        }
        if (Wstring[0] != '-' && Wstring[0]!='+')
        {
            Wstring = '+' + Wstring;
        }
        Wstring += '+';
        for(int i=0; i < Wstring.Length; i++)
        {
            if(i+1 > Wstring.Length-1)
            {
                break;
            }
            if ((Wstring[i]=='X' || Wstring[i] == 'x') && Wstring[i-1] != '-' && Wstring[i-1] != '+' && Wstring[i + 1] != '^')
            {
                Wstring = Wstring.Insert(i + 1, "^1");
            }
            if (Wstring[i]=='+' || Wstring[i] == '-')
            {
                if (Wstring[i + 1] == 'X' || Wstring[i+1] == 'x')
                {
                    Wstring = Wstring.Insert(i + 1, "1");
                }
                else
                {
                    tmp1 = Wstring.Substring(i + 1);
                    int size = tmp1.IndexOf("+");
                    int size2 = tmp1.IndexOf("-");
                    if (size == -1)
                    {
                        size = size2;
                    }
                    else if (size2 != -1 && size != -1)
                    {
                        if (size2 < size) { size = size2; }
                    }
                    tmp1 = tmp1.Substring(0, size);
                    if ((tmp1.IndexOf('X') == -1 && tmp1.IndexOf('x') == -1) && tmp1 != "")
                    {
                        Wstring = Wstring.Insert(i + size + 1, "X^0");
                    }
                }
            }
        }
        ////
        int counter = 0;
        int[] tabST = new int[Wstring.Length];
        dynamic[] tabWSP = new dynamic[Wstring.Length];
        for(int i = 0; i < Wstring.Length; i++)
        {
            if (Wstring[i] == 'X' || Wstring[i] == 'x')
            {
                if (counter == 0)
                {
                    tmp1 = Wstring.Substring(0, i);
                }
                else
                {
                    int size = tmp1.IndexOf('^');
                    tmp1 = tmp1.Substring(0,size-1);
                }
                //dodac wsp
                tabWSP[counter] = Convert.ToDouble(tmp1);
                if (Wstring[i + 1] == '^')
                {
                    tmp1 = Wstring.Substring(i + 2);
                    int size = tmp1.IndexOf("+"); //dodac - u gory tez
                    int size2 = tmp1.IndexOf("-");
                    if (size == -1)
                    {
                        size = size2;
                    }
                    else if (size2 != -1 && size != -1)
                    {
                        if(size2 < size) { size = size2; }
                    }
                    tmp2 = tmp1;
                    tmp1 = Wstring.Substring(i + 2, size);
                    //dodac st
                    tabST[counter] = Convert.ToInt32(tmp1);
                    if (tmp1.Length == tmp2.Length)
                    {
                        break;
                    }
                    else
                    {
                        tmp1 = tmp2.Substring(size);
                    }
                }
                else
                {
                    tmp1 = Wstring.Substring(i + 1);
                    tmp2 = tmp1;
                    //st = 1;
                    tabST[counter] = 1;
                }
                counter++;
            }
        }

        int sizeS = 0;
        for (int i = 0; i < counter; i++)
        {
            if (tabST[i] > sizeS)
            {
                sizeS = tabST[i];
            }
        }

        this.wsp = new dynamic[sizeS + 1];
        this.st = sizeS;
        for(int i = 0; i <= sizeS; i++)
        {
            this.wsp[i] = 0;
        }

        for (int i = 0; i < counter; i++)
        {
            wsp[st - tabST[i]] += tabWSP[i];
        }
    }
    public static wielomian operator+ (wielomian o, wielomian x)
    {
        wielomian abc = new wielomian();
        int tmp;
        if (x.st > o.st)
        {
            abc.st = x.st;
            tmp = x.st - o.st;
        }
        else
        {
            abc.st = o.st;
            tmp = o.st - x.st;
        }
        abc.wsp = new dynamic[abc.st + 1];
        for (int i = 0; i <= abc.st; i++)
        {
            abc.wsp[i] = 0;
        }
        if (x.st > o.st)
        {
            for (int i = 0; i < tmp; i++)
            {
                abc.wsp[i] = x.wsp[i];
            }
            for (int i = tmp; i <= abc.st; i++)
            {
                abc.wsp[i] = x.wsp[i] + o.wsp[i - tmp];
            }
        }
        else if (x.st < o.st)
        {
            for (int i = 0; i < tmp; i++)
            {
                abc.wsp[i] = o.wsp[i];
            }
            for (int i = tmp; i <= abc.st; i++)
            {
                abc.wsp[i] = x.wsp[i - tmp] + o.wsp[i];
            }
        }
        else
        {
            for (int i = 0; i <= abc.st; i++)
            {
                abc.wsp[i] = x.wsp[i] + o.wsp[i];
            }
        }
        return abc;
    }
    public static wielomian operator* (wielomian o, wielomian x)
    {
        wielomian abc = new wielomian();
        abc.st = x.st + o.st;
        abc.wsp = new dynamic[abc.st + 1];
        for (int i = 0; i <= abc.st; i++)
        {
            abc.wsp[i] = 0;
        }
        for (int i = 0; i <= o.st; i++)
        {
            for (int j = 0; j <= x.st; j++)
            {
                abc.wsp[i + j] += o.wsp[i] * x.wsp[j];
            }
        }
        return abc;
    }
    public static wielomian operator- (wielomian o, wielomian x)
    {
        wielomian abc = new wielomian();
        int tmp;
        if (x.st > o.st)
        {
            abc.st = x.st;
            tmp = x.st - o.st;
        }
        else
        {
            abc.st = o.st;
            tmp = o.st - x.st;
        }
        abc.wsp = new dynamic[abc.st + 1];
        for (int i = 0; i <= abc.st; i++)
        {
            abc.wsp[i] = 0;
        }
        if (x.st > o.st)
        {
            for (int i = 0; i < tmp; i++)
            {
                abc.wsp[i] = x.wsp[i];
            }
            for (int i = tmp; i <= abc.st; i++)
            {
                abc.wsp[i] = o.wsp[i] - x.wsp[i - tmp];
            }
        }
        else if (x.st < o.st)
        {
            for (int i = 0; i < tmp; i++)
            {
                abc.wsp[i] = o.wsp[i];
            }
            for (int i = tmp; i <= abc.st; i++)
            {
                abc.wsp[i] = o.wsp[i] - x.wsp[i-tmp];
            }
        }
        else
        {
            for (int i = 0; i <= abc.st; i++)
            {
                abc.wsp[i] = o.wsp[i] - x.wsp[i];
            }
        }
        return abc;
    }
    public string output()
    {
        string output = null;
        for (int i = 0; i < st + 1; i++)
        {
            if (wsp[i] > 0 && i != 0)
            {
                output += "+";
            }
            if (wsp[i] != 0)
            {
                if (i == st)
                {
                    output += wsp[i];
                }
                else if (i == st - 1)
                {
                    if (wsp[i] == 1)
                    {
                        output += "X";
                    }
                    else if (wsp[i] == -1)
                    {
                        output += "-X";
                    }
                    else
                    {
                        output += (wsp[i]+"X");
                    }
                }
                else if (wsp[i] == 1)
                {
                    output += ("X^" + (st - i));
                }
                else
                {
                    output += (wsp[i] + "X^" + (st - i));
                }
            }
        }
        return output;
    }
}





