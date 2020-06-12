namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnWebapi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbPOST = new System.Windows.Forms.RadioButton();
            this.rbGET = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Viktor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnWebapi
            // 
            this.btnWebapi.Location = new System.Drawing.Point(620, 22);
            this.btnWebapi.Name = "btnWebapi";
            this.btnWebapi.Size = new System.Drawing.Size(87, 28);
            this.btnWebapi.TabIndex = 3;
            this.btnWebapi.Text = "Web Services";
            this.btnWebapi.UseVisualStyleBackColor = true;
            this.btnWebapi.Click += new System.EventHandler(this.btnWebapi_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(433, 23);
            this.textBox1.TabIndex = 4;
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(113, 99);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(644, 322);
            this.txtResponse.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbPOST);
            this.panel1.Controls.Add(this.rbGET);
            this.panel1.Location = new System.Drawing.Point(517, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 72);
            this.panel1.TabIndex = 6;
            // 
            // rbPOST
            // 
            this.rbPOST.AutoSize = true;
            this.rbPOST.Checked = true;
            this.rbPOST.Location = new System.Drawing.Point(3, 35);
            this.rbPOST.Name = "rbPOST";
            this.rbPOST.Size = new System.Drawing.Size(53, 19);
            this.rbPOST.TabIndex = 8;
            this.rbPOST.TabStop = true;
            this.rbPOST.Tag = "1";
            this.rbPOST.Text = "POST";
            this.rbPOST.UseVisualStyleBackColor = true;
            this.rbPOST.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbGET
            // 
            this.rbGET.AutoSize = true;
            this.rbGET.Location = new System.Drawing.Point(3, 10);
            this.rbGET.Name = "rbGET";
            this.rbGET.Size = new System.Drawing.Size(45, 19);
            this.rbGET.TabIndex = 7;
            this.rbGET.Tag = "0";
            this.rbGET.Text = "GET";
            this.rbGET.UseVisualStyleBackColor = true;
            this.rbGET.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnWebapi);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWebapi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbPOST;
        private System.Windows.Forms.RadioButton rbGET;
    }
}

