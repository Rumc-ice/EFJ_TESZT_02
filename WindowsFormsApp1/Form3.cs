using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form3)((Button)sender).Parent).Close();  
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
           
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

            //ActiveForm.Controls["panel1"].Controls["button2"].Enabled = true;             
            ActiveForm.Controls["panel1"].Enabled = true;             
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
