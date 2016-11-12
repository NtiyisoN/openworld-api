namespace norwold.forms
{
    partial class frmUserManager
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
            this.components = new System.ComponentModel.Container();
            this.btnQuit = new System.Windows.Forms.Button();
            this.bs_hostUser = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lboxUserType = new System.Windows.Forms.ListBox();
            this.bs_userType = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnNewCampaign = new System.Windows.Forms.Button();
            this.btnCreateCharacter = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lboxGMCampaigns = new System.Windows.Forms.ListBox();
            this.bs_campaigns = new System.Windows.Forms.BindingSource(this.components);
            this.lboxCharacters = new System.Windows.Forms.ListBox();
            this.bs_chars = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxEmail = new System.Windows.Forms.TextBox();
            this.tboxName = new System.Windows.Forms.TextBox();
            this.tboxLongName = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tboxMsg = new System.Windows.Forms.TextBox();
            this.lboxUsers = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_userType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_campaigns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_chars)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(895, 408);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(117, 40);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // bs_hostUser
            // 
            this.bs_hostUser.DataSource = typeof(DataModel.libHosting.hostUser);
            this.bs_hostUser.CurrentChanged += new System.EventHandler(this.hostUserBindingSource_CurrentChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lboxUserType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnNewCampaign);
            this.groupBox1.Controls.Add(this.btnCreateCharacter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tboxEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lboxGMCampaigns);
            this.groupBox1.Controls.Add(this.lboxCharacters);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tboxPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tboxName);
            this.groupBox1.Controls.Add(this.tboxLongName);
            this.groupBox1.Controls.Add(this.lblUserID);
            this.groupBox1.Location = new System.Drawing.Point(368, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 399);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gboxUsers";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lboxUserType
            // 
            this.lboxUserType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bs_hostUser, "UserType", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.lboxUserType.DataSource = this.bs_userType;
            this.lboxUserType.DisplayMember = "LongName";
            this.lboxUserType.FormattingEnabled = true;
            this.lboxUserType.ItemHeight = 16;
            this.lboxUserType.Location = new System.Drawing.Point(109, 98);
            this.lboxUserType.Name = "lboxUserType";
            this.lboxUserType.Size = new System.Drawing.Size(170, 20);
            this.lboxUserType.TabIndex = 24;
            this.lboxUserType.ValueMember = "id";
            this.lboxUserType.SelectedIndexChanged += new System.EventHandler(this.lboxUserType_SelectedIndexChanged);
            // 
            // bs_userType
            // 
            this.bs_userType.DataSource = typeof(DataModel.libHosting.hostUserType);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "UserType";
            // 
            // btnNewCampaign
            // 
            this.btnNewCampaign.Location = new System.Drawing.Point(470, 225);
            this.btnNewCampaign.Name = "btnNewCampaign";
            this.btnNewCampaign.Size = new System.Drawing.Size(117, 27);
            this.btnNewCampaign.TabIndex = 22;
            this.btnNewCampaign.Text = "&New Campaign";
            this.btnNewCampaign.UseVisualStyleBackColor = true;
            this.btnNewCampaign.Click += new System.EventHandler(this.btnNewCampaign_Click);
            // 
            // btnCreateCharacter
            // 
            this.btnCreateCharacter.Location = new System.Drawing.Point(162, 224);
            this.btnCreateCharacter.Name = "btnCreateCharacter";
            this.btnCreateCharacter.Size = new System.Drawing.Size(117, 27);
            this.btnCreateCharacter.TabIndex = 6;
            this.btnCreateCharacter.Text = "&Create";
            this.btnCreateCharacter.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "GM of following campaigns";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Characters";
            // 
            // lboxGMCampaigns
            // 
            this.lboxGMCampaigns.DataSource = this.bs_campaigns;
            this.lboxGMCampaigns.DisplayMember = "LongName";
            this.lboxGMCampaigns.FormattingEnabled = true;
            this.lboxGMCampaigns.ItemHeight = 16;
            this.lboxGMCampaigns.Location = new System.Drawing.Point(321, 151);
            this.lboxGMCampaigns.Name = "lboxGMCampaigns";
            this.lboxGMCampaigns.Size = new System.Drawing.Size(266, 68);
            this.lboxGMCampaigns.TabIndex = 19;
            // 
            // bs_campaigns
            // 
            this.bs_campaigns.DataSource = typeof(DataModel.libCampaign.campCampaign);
            // 
            // lboxCharacters
            // 
            this.lboxCharacters.DataSource = this.bs_chars;
            this.lboxCharacters.DisplayMember = "LongName";
            this.lboxCharacters.FormattingEnabled = true;
            this.lboxCharacters.ItemHeight = 16;
            this.lboxCharacters.Location = new System.Drawing.Point(13, 151);
            this.lboxCharacters.Name = "lboxCharacters";
            this.lboxCharacters.Size = new System.Drawing.Size(266, 68);
            this.lboxCharacters.TabIndex = 18;
            // 
            // bs_chars
            // 
            this.bs_chars.DataSource = typeof(DataModel.libHosting.hostChar);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password";
            // 
            // tboxPassword
            // 
            this.tboxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "Password", true));
            this.tboxPassword.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPassword.Location = new System.Drawing.Point(404, 61);
            this.tboxPassword.MaxLength = 255;
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.Size = new System.Drawing.Size(183, 28);
            this.tboxPassword.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Long Name";
            // 
            // tboxEmail
            // 
            this.tboxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "Email", true));
            this.tboxEmail.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxEmail.Location = new System.Drawing.Point(109, 289);
            this.tboxEmail.MaxLength = 255;
            this.tboxEmail.Name = "tboxEmail";
            this.tboxEmail.ReadOnly = true;
            this.tboxEmail.Size = new System.Drawing.Size(478, 28);
            this.tboxEmail.TabIndex = 12;
            // 
            // tboxName
            // 
            this.tboxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "Name", true));
            this.tboxName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxName.Location = new System.Drawing.Point(109, 64);
            this.tboxName.MaxLength = 10;
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(202, 28);
            this.tboxName.TabIndex = 11;
            // 
            // tboxLongName
            // 
            this.tboxLongName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "LongName", true));
            this.tboxLongName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxLongName.Location = new System.Drawing.Point(109, 30);
            this.tboxLongName.MaxLength = 42;
            this.tboxLongName.Name = "tboxLongName";
            this.tboxLongName.Size = new System.Drawing.Size(400, 28);
            this.tboxLongName.TabIndex = 10;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "id", true));
            this.lblUserID.Location = new System.Drawing.Point(524, 30);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(21, 17);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "ID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(772, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(632, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tboxMsg
            // 
            this.tboxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tboxMsg.Location = new System.Drawing.Point(0, 456);
            this.tboxMsg.Name = "tboxMsg";
            this.tboxMsg.Size = new System.Drawing.Size(1040, 22);
            this.tboxMsg.TabIndex = 5;
            // 
            // lboxUsers
            // 
            this.lboxUsers.DataSource = this.bs_hostUser;
            this.lboxUsers.DisplayMember = "LongName";
            this.lboxUsers.FormattingEnabled = true;
            this.lboxUsers.ItemHeight = 16;
            this.lboxUsers.Location = new System.Drawing.Point(13, 13);
            this.lboxUsers.Name = "lboxUsers";
            this.lboxUsers.Size = new System.Drawing.Size(342, 420);
            this.lboxUsers.TabIndex = 6;
            this.lboxUsers.ValueMember = "id";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "fbFirstName", true));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(109, 323);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(170, 28);
            this.textBox1.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "fbFirstName";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "fbSurname", true));
            this.textBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(417, 323);
            this.textBox2.MaxLength = 255;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(170, 28);
            this.textBox2.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "fbSurname";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "fbID", true));
            this.textBox3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(109, 357);
            this.textBox3.MaxLength = 255;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(202, 28);
            this.textBox3.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 360);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "fbID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "fbGender";
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostUser, "fbGender", true));
            this.textBox4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(417, 363);
            this.textBox4.MaxLength = 255;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(170, 28);
            this.textBox4.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(75, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(446, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "THE FOLLOWING SECTION IS  SET BY THE FACEBOOK ACCOUNT:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // frmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 478);
            this.Controls.Add(this.lboxUsers);
            this.Controls.Add(this.tboxMsg);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Name = "frmUserManager";
            this.Text = "frmUserManager";
            this.Load += new System.EventHandler(this.frmUserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_userType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_campaigns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_chars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.BindingSource bs_hostUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxEmail;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.TextBox tboxLongName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tboxMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lboxGMCampaigns;
        private System.Windows.Forms.ListBox lboxCharacters;
        private System.Windows.Forms.BindingSource bs_chars;
        private System.Windows.Forms.BindingSource bs_campaigns;
        private System.Windows.Forms.Button btnNewCampaign;
        private System.Windows.Forms.Button btnCreateCharacter;
        private System.Windows.Forms.ListBox lboxUsers;
        private System.Windows.Forms.ListBox lboxUserType;
        private System.Windows.Forms.BindingSource bs_userType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
    }
}