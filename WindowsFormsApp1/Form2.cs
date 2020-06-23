using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;




namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        static class NativeMethods
        {

            [DllImport("netapi32.dll")]
            public static extern void NetApiBufferFree(IntPtr bufptr);

            [DllImport("netapi32.dll")]
            public static extern UInt32 NetUserEnum([MarshalAs(UnmanagedType.LPWStr)] String servername, UInt32 level, UInt32 filter, ref IntPtr bufptr, UInt32 prefmaxlen, ref UInt32 entriesread, ref UInt32 totalentries, IntPtr resumehandle);

            [DllImport("netapi32.dll")]
            public static extern UInt32 NetLocalGroupEnum([MarshalAs(UnmanagedType.LPWStr)] String servername, UInt32 level, ref IntPtr bufptr, UInt32 prefmaxlen, ref UInt32 entriesread, ref UInt32 totalentries, IntPtr resumehandle);

            [DllImport("Netapi32.dll")]
            public extern static UInt32 NetLocalGroupGetMembers([MarshalAs(UnmanagedType.LPWStr)] String servername, [MarshalAs(UnmanagedType.LPWStr)] String localgroupname, UInt32 level, ref IntPtr bufptr, UInt32 prefmaxlen, ref UInt32 entriesread, ref UInt32 totalentries, IntPtr resumehandle);

        }
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
                    label_nev.Top = 150;
                    label_nev.Left = 100;
                    new_design_2.Controls.Add(label_nev);
               
                

                new_design_2.WindowState = FormWindowState.Maximized; 
                //((Button)sender).Enabled = false;

                panel1.Enabled = false;
                    new_design_2.Show();
                
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
            IEnumerable<String> usernames = GetUserNames();

            foreach (string user in usernames)
            {
               listBox1.Items.Add(user);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IEnumerable<String> usernames = GetUserNames();

            foreach (string user in usernames)
            {
                MessageBox.Show(user); 
            }
            MessageBox.Show(Environment.MachineName);  
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IEnumerable<String> groupnames = GetLocalGroupNames();
            //IEnumerable<String> usernames;
            //string currentUser = Environment.MachineName + "\\" + Environment.UserName;
            string currentUser = Environment.MachineName + "\\" + "Vendég";
            //foreach (string group in groupnames)
            //{
            //    usernames = GetLocalGroupUsers(group);
            //    foreach (string user in usernames)
            //    {
            //        MessageBox.Show("Csoport: " + group + Environment.NewLine + "Felhasználó: " + user);
            //    }  
            //}
            foreach (string group in groupnames)
            {
                if(GetLocalGroupUsers(group).Contains(currentUser))
                {
                    MessageBox.Show("Csoport: " + group + Environment.NewLine + "Felhasználó: " + currentUser);
                }
            }

        }

        IEnumerable<String> GetUserNames()
        {
            var buffer = IntPtr.Zero;
            try
            {
                UInt32 entriesRead = 0;
                UInt32 totalEntries = 0;
                var result = NativeMethods.NetUserEnum(null, 0, 0, ref buffer, UInt32.MaxValue, ref entriesRead, ref totalEntries, IntPtr.Zero);
                if (result != 0)
                    throw new Win32Exception((Int32)result);
                var userNames = Enumerable
                  .Range(0, (Int32)entriesRead)
                  .Select(
                    i => {
                        var userInfo = Marshal.ReadIntPtr(buffer, i * IntPtr.Size);
                        var userName = Marshal.PtrToStringAuto(userInfo);
                        return userName;
                    }
                  )
                  .ToList();
                return userNames;
            }
            finally
            {
                NativeMethods.NetApiBufferFree(buffer);
            }
        }

        IEnumerable<String> GetLocalGroupNames()
        {
            var buffer = IntPtr.Zero;
            try
            {
                UInt32 entriesRead = 0;
                UInt32 totalEntries = 0;
                var result = NativeMethods.NetLocalGroupEnum(null, 0, ref buffer, UInt32.MaxValue, ref entriesRead, ref totalEntries, IntPtr.Zero);
                if (result != 0)
                    throw new Win32Exception((Int32)result);
                var localGroupNames = Enumerable
                  .Range(0, (Int32)entriesRead)
                  .Select(
                    i => {
                        var localGroupInfo = Marshal.ReadIntPtr(buffer, i * IntPtr.Size);
                        var groupName = Marshal.PtrToStringAuto(localGroupInfo);
                        return groupName;
                    }
                  )
                  .ToList();
                return localGroupNames;
            }
            finally
            {
                NativeMethods.NetApiBufferFree(buffer);
            }
        }

        IEnumerable<String> GetLocalGroupUsers(String localGroupName)
        {
            var buffer = IntPtr.Zero;
            try
            {
                UInt32 entriesRead = 0;
                UInt32 totalEntries = 0;
                var result = NativeMethods.NetLocalGroupGetMembers(null, localGroupName, 3, ref buffer, UInt32.MaxValue, ref entriesRead, ref totalEntries, IntPtr.Zero);
                if (result != 0)
                    throw new Win32Exception((Int32)result);
                var userNames = Enumerable
                  .Range(0, (Int32)entriesRead)
                  .Select(
                    i => {
                        var membersInfo = Marshal.ReadIntPtr(buffer, i * IntPtr.Size);
                        var userName = Marshal.PtrToStringAuto(membersInfo);
                        return userName;
                    }
                  )
                  .ToList();
                return userNames;
            }
            finally
            {
                NativeMethods.NetApiBufferFree(buffer);
            }
        }

    }
}
