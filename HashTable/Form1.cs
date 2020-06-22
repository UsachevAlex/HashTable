using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HashTable
{
    public partial class Form1 : Form
    {
        HashTableGraphics<Subscriber> hashTable = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hashTable = new HashTableGraphics<Subscriber>();
            if (radioButton1.Checked)
                hashTable.IsHashParam = false;
            else
                hashTable.IsHashParam = true;
            panel2.Refresh();
            if (radioButton2.Checked)
            {
                int.TryParse(textBox1.Text, out hashTable.Params[0]);
                int.TryParse(textBox2.Text, out hashTable.Params[1]);
                int.TryParse(textBox3.Text, out hashTable.Params[2]);
            }
            LoadSubscribers("ASTRA.txt");
            hashTable.Draw(panel2);
        }

        private void LoadSubscribers(string fname)
        {
            using (StreamReader fReader = new StreamReader(fname))
            {
                string s = "";
                while (true)
                {
                    s = fReader.ReadLine();
                    if (s == null)
                        break;
                    string[] str = { s.Substring(0, 5), s.Substring(6, 21).Trim(' '), s.Substring(28, s.Length - 28).Trim(' ') };
                    hashTable.Add(new Subscriber(str[1], str[0], str[2]));
                }
                fReader.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subscriber s = hashTable.Find(textBox4.Text);
            if (s != null)
            {
                label5.Text = "Name: " + s.Name;
                label6.Text = "Address: " + s.Address;
            }
            else
                MessageBox.Show("Не найдено");
        }
    }
}
