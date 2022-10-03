using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<char> l = new List<char>();
        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            l.Clear();
            int n = (int)numericUpDown1.Value;
            for(int i = 0;i<n;i++)
            {
                l.Add((char)r.Next(32, 128));
            }
            Vypis(l, textBox1);
            Vypis(l, listBox1);
            Vypis2(l, listBox2);
            Median(l);
        }

        private void Vypis(List<char> ls, TextBox tb)
        {
            string vystup = "";
            foreach(char c in ls)
            {
                if(c!=' ')
                    vystup += c;
            }
            tb.Text = vystup;
        }
        private void Vypis(List<char> ls, ListBox lb)
        {
            lb.Items.Clear();
            string slovo = "";
            foreach(char c in ls)
            {
                if (c == ' ')
                {
                    if(slovo.Length >1)
                        lb.Items.Add(slovo);
                    slovo = "";
                }
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    slovo += c;
            }
            if (slovo.Length > 1)
                lb.Items.Add(slovo);
        }
        private void Vypis2(List<char> ls, ListBox lb)
        {
            List<char> ch = new List<char>();
            foreach (char c in ls)
            {

                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                    ch.Add(c);
            }
            ch.Sort();
            lb.Items.Clear();
            foreach(char c in ch)
            {
                lb.Items.Add(c);
            }
        }
        private void Median(List<char> ls)
        {
            List<int> cisla = new List<int>();
            foreach(char c in ls)
            {
                if (c >= '0' && c <= '9')
                    cisla.Add((int)(c - '0'));
            }
            cisla.Sort();
            if(cisla.Count != 0 && cisla.Count %2 == 0)
                MessageBox.Show("Median = " + ((cisla[(int)(cisla.Count / 2)]+ cisla[(int)(cisla.Count / 2-1)])/2),"Median");
            if (cisla.Count != 0 && cisla.Count % 2 != 0)
                MessageBox.Show("Median = " + cisla[(int)(cisla.Count / 2)], "Median");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0, e1 = 0;
            if(Mezera(textBox2.Text, ref a, ref e1))
            {
                label1.Text = "Obsahuje mezeru\na: " + a + "krát\ne: " + e1 + "krát";
            }
            else
                label1.Text = "Neobsahuje mezeru\na: " + a + "krát\ne: " + e1 + "krát";
        }

        private bool Mezera(string vstup, ref int a, ref int e1)
        {
            vstup = vstup.ToLower();
            foreach(char c in vstup)
            {
                if (c == 'a')
                    a++;
                if (c == 'e')
                    e1++;
            }
            return vstup.Contains(' ');
        }
    }
}
