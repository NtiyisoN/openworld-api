namespace norwold.forms
{
    partial class FrmLogon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxRegister = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.pboxLogin = new System.Windows.Forms.PictureBox();
            this.tboxMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(25, 13);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(745, 335);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login in with your facebook Account to associate your login with Facebook.\r\nYou m" +
    "ust have a valid email address to confirm your logon";
            // 
            // tboxRegister
            // 
            this.tboxRegister.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tboxRegister.Enabled = false;
            this.tboxRegister.Location = new System.Drawing.Point(104, 366);
            this.tboxRegister.Name = "tboxRegister";
            this.tboxRegister.Size = new System.Drawing.Size(395, 22);
            this.tboxRegister.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(635, 359);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(119, 37);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "&Login (FB)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            this.btnPost.Enabled = false;
            this.btnPost.Location = new System.Drawing.Point(510, 359);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(119, 37);
            this.btnPost.TabIndex = 7;
            this.btnPost.Text = "&Post to FB";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(635, 414);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(119, 37);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // pboxLogin
            // 
            this.pboxLogin.Image = global::norwold.forms.Properties.Resources.demons;
            this.pboxLogin.Location = new System.Drawing.Point(28, 20);
            this.pboxLogin.Name = "pboxLogin";
            this.pboxLogin.Size = new System.Drawing.Size(745, 325);
            this.pboxLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxLogin.TabIndex = 9;
            this.pboxLogin.TabStop = false;
            // 
            // tboxMsg
            // 
            this.tboxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tboxMsg.Enabled = false;
            this.tboxMsg.Location = new System.Drawing.Point(0, 472);
            this.tboxMsg.Name = "tboxMsg";
            this.tboxMsg.Size = new System.Drawing.Size(782, 22);
            this.tboxMsg.TabIndex = 10;
            this.tboxMsg.TabStop = false;
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 494);
            this.Controls.Add(this.tboxMsg);
            this.Controls.Add(this.pboxLogin);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "FrmLogon";
            this.Text = "OpenWorld - Login";
            this.Load += new System.EventHandler(this.FrmLogon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.PictureBox pboxLogin;
        private System.Windows.Forms.TextBox tboxMsg;
    }
}