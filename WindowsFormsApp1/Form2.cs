using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel_semafor.Top = button1.Top;
            panel_semafor.Height = button1.Height;
            this.helpProvider1.SetShowHelp(this.textEmail, true);
            this.helpProvider1.SetHelpString(this.textEmail, "Enter the zip code here.");
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Set what the Help file will be for the HelpProvider.
            this.helpProvider1.HelpNamespace = "mspaint.chm";
        }

      
        private void button_fomenu_Click_1(object sender, EventArgs e)
        {
            panel_semafor.Top = ((Button)sender).Top;
            panel_semafor.Height  = ((Button)sender).Height;

            if (((Button)sender).Name == "button2")
            {
                Form3 new_design_2 = new Form3();
                new_design_2.IsMdiContainer = false;
                new_design_2.MdiParent = this;
                
                Label label_nev = new Label();
                label_nev.Text = "Nevem senki";
                label_nev.Top = 50;
                label_nev.Left = 100;
                new_design_2.Controls.Add(label_nev);   
                new_design_2.Show();
                new_design_2.WindowState = FormWindowState.Maximized;
                //((Button)sender).Enabled = false;
                panel1.Enabled = false;  
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close(); 
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                MyValidatingCode();
            }

            catch (Exception ex)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textEmail.Select(0, textEmail.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textEmail, ex.Message);
            }
        }

        private void textEmail_Validated(object sender, EventArgs e)
        {
            //If all conditions have been met, clear the error provider of errors.
            errorProvider1.SetError(textEmail, "");
        }
        private void MyValidatingCode()
        {
            // Confirm there is text in the control.
            if (textEmail.Text.Length == 0)
            {
                throw new Exception("Email address is a required field.");
            }
            // Confirm that there is a "." and an "@" in the email address.
            else if (textEmail.Text.IndexOf(".") == -1 || textEmail.Text.IndexOf("@") == -1)
            {
                throw new Exception("Email address must be valid email address format." +
                 "\nFor example: 'someone@example.com'");
            }
        }

        private void textEmail_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void textEmail_MouseClick(object sender, MouseEventArgs e)
        {
            helpProvider1.SetShowHelp(textEmail, true);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
