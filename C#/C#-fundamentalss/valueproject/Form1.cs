﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace valueproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from, to;
            from = listBoxFrom.SelectedItem.ToString();
            to = listBoxTo.SelectedItem.ToString();
            webBrowser1.Navigate("https://www.google.com/search?q="AmountТb" "+from+" in "+to+"+eur&oq=100+bgn+in+eur");
        }
    }
}
