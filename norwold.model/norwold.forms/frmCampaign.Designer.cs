namespace norwold.forms
{
    partial class frmCampaign
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lboxCampaigns = new System.Windows.Forms.ListBox();
            this.bs_hostCampaign = new System.Windows.Forms.BindingSource(this.components);
            this.lboxLogon = new System.Windows.Forms.ListBox();
            this.bs_hostUser = new System.Windows.Forms.BindingSource(this.components);
            this.tabCampaign = new System.Windows.Forms.TabControl();
            this.tbCampaign = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dateStarted = new System.Windows.Forms.DateTimePicker();
            this.LblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxName = new System.Windows.Forms.TextBox();
            this.tboxLongName = new System.Windows.Forms.TextBox();
            this.tbCharacters = new System.Windows.Forms.TabPage();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxRejectText = new System.Windows.Forms.TextBox();
            this.chkListBoxRejected = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCharApprove = new System.Windows.Forms.Button();
            this.btnCampaignReject = new System.Windows.Forms.Button();
            this.btnCampaignRemove = new System.Windows.Forms.Button();
            this.chkListBoxPlayersPending = new System.Windows.Forms.CheckedListBox();
            this.chkListBoxPlayers = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAdventures = new System.Windows.Forms.TabPage();
            this.btnNewAdventure = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.bs_nwAdventure = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tboxAdventureShortName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxAdventureBiog = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.Label();
            this.dtpAdventureDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tboxAdventureName = new System.Windows.Forms.TextBox();
            this.tbApprovals = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddCampaign = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tboxMsg = new System.Windows.Forms.TextBox();
            this.bs_nwCharCampaign = new System.Windows.Forms.BindingSource(this.components);
            this.bs_nwChar = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dGridAdventure = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostCampaign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostUser)).BeginInit();
            this.tabCampaign.SuspendLayout();
            this.tbCampaign.SuspendLayout();
            this.tbCharacters.SuspendLayout();
            this.tbAdventures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwAdventure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharCampaign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAdventure)).BeginInit();
            this.SuspendLayout();
            // 
            // lboxCampaigns
            // 
            this.lboxCampaigns.DataSource = this.bs_hostCampaign;
            this.lboxCampaigns.DisplayMember = "LongName";
            this.lboxCampaigns.FormattingEnabled = true;
            this.lboxCampaigns.ItemHeight = 16;
            this.lboxCampaigns.Location = new System.Drawing.Point(13, 13);
            this.lboxCampaigns.Name = "lboxCampaigns";
            this.lboxCampaigns.Size = new System.Drawing.Size(313, 372);
            this.lboxCampaigns.TabIndex = 0;
            // 
            // bs_hostCampaign
            // 
            this.bs_hostCampaign.DataSource = typeof(DataModel.libCampaign.campCampaign);
            this.bs_hostCampaign.CurrentChanged += new System.EventHandler(this.bs_hostCampaign_CurrentChanged);
            // 
            // lboxLogon
            // 
            this.lboxLogon.DataSource = this.bs_hostUser;
            this.lboxLogon.DisplayMember = "LongName";
            this.lboxLogon.FormattingEnabled = true;
            this.lboxLogon.ItemHeight = 16;
            this.lboxLogon.Location = new System.Drawing.Point(13, 391);
            this.lboxLogon.Name = "lboxLogon";
            this.lboxLogon.Size = new System.Drawing.Size(313, 36);
            this.lboxLogon.TabIndex = 10;
            // 
            // bs_hostUser
            // 
            this.bs_hostUser.DataSource = typeof(DataModel.libHosting.hostUser);
            this.bs_hostUser.CurrentChanged += new System.EventHandler(this.bs_hostUser_CurrentChanged);
            // 
            // tabCampaign
            // 
            this.tabCampaign.Controls.Add(this.tbCampaign);
            this.tabCampaign.Controls.Add(this.tbCharacters);
            this.tabCampaign.Controls.Add(this.tbAdventures);
            this.tabCampaign.Controls.Add(this.tbApprovals);
            this.tabCampaign.Location = new System.Drawing.Point(349, 13);
            this.tabCampaign.Name = "tabCampaign";
            this.tabCampaign.SelectedIndex = 0;
            this.tabCampaign.Size = new System.Drawing.Size(1003, 372);
            this.tabCampaign.TabIndex = 11;
            // 
            // tbCampaign
            // 
            this.tbCampaign.Controls.Add(this.label3);
            this.tbCampaign.Controls.Add(this.dateStarted);
            this.tbCampaign.Controls.Add(this.LblID);
            this.tbCampaign.Controls.Add(this.label4);
            this.tbCampaign.Controls.Add(this.tboxDescription);
            this.tbCampaign.Controls.Add(this.label2);
            this.tbCampaign.Controls.Add(this.label1);
            this.tbCampaign.Controls.Add(this.tboxName);
            this.tbCampaign.Controls.Add(this.tboxLongName);
            this.tbCampaign.Location = new System.Drawing.Point(4, 25);
            this.tbCampaign.Name = "tbCampaign";
            this.tbCampaign.Padding = new System.Windows.Forms.Padding(3);
            this.tbCampaign.Size = new System.Drawing.Size(995, 343);
            this.tbCampaign.TabIndex = 0;
            this.tbCampaign.Text = "Campaign Data";
            this.tbCampaign.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Started";
            // 
            // dateStarted
            // 
            this.dateStarted.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bs_hostCampaign, "DateStarted", true));
            this.dateStarted.Location = new System.Drawing.Point(111, 87);
            this.dateStarted.Name = "dateStarted";
            this.dateStarted.Size = new System.Drawing.Size(247, 22);
            this.dateStarted.TabIndex = 18;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostCampaign, "id", true));
            this.LblID.Location = new System.Drawing.Point(533, 18);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(21, 17);
            this.LblID.TabIndex = 17;
            this.LblID.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Biog";
            // 
            // tboxDescription
            // 
            this.tboxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostCampaign, "Description", true));
            this.tboxDescription.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDescription.Location = new System.Drawing.Point(111, 127);
            this.tboxDescription.MaxLength = 8000;
            this.tboxDescription.Multiline = true;
            this.tboxDescription.Name = "tboxDescription";
            this.tboxDescription.Size = new System.Drawing.Size(606, 161);
            this.tboxDescription.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Long Name";
            // 
            // tboxName
            // 
            this.tboxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostCampaign, "Name", true));
            this.tboxName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxName.Location = new System.Drawing.Point(111, 52);
            this.tboxName.MaxLength = 10;
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(247, 28);
            this.tboxName.TabIndex = 12;
            // 
            // tboxLongName
            // 
            this.tboxLongName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_hostCampaign, "LongName", true));
            this.tboxLongName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxLongName.Location = new System.Drawing.Point(111, 18);
            this.tboxLongName.MaxLength = 42;
            this.tboxLongName.Name = "tboxLongName";
            this.tboxLongName.Size = new System.Drawing.Size(400, 28);
            this.tboxLongName.TabIndex = 11;
            // 
            // tbCharacters
            // 
            this.tbCharacters.Controls.Add(this.btnDeleteComment);
            this.tbCharacters.Controls.Add(this.label9);
            this.tbCharacters.Controls.Add(this.tboxRejectText);
            this.tbCharacters.Controls.Add(this.chkListBoxRejected);
            this.tbCharacters.Controls.Add(this.label8);
            this.tbCharacters.Controls.Add(this.btnCharApprove);
            this.tbCharacters.Controls.Add(this.btnCampaignReject);
            this.tbCharacters.Controls.Add(this.btnCampaignRemove);
            this.tbCharacters.Controls.Add(this.chkListBoxPlayersPending);
            this.tbCharacters.Controls.Add(this.chkListBoxPlayers);
            this.tbCharacters.Controls.Add(this.label7);
            this.tbCharacters.Controls.Add(this.label6);
            this.tbCharacters.Location = new System.Drawing.Point(4, 25);
            this.tbCharacters.Name = "tbCharacters";
            this.tbCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.tbCharacters.Size = new System.Drawing.Size(995, 343);
            this.tbCharacters.TabIndex = 1;
            this.tbCharacters.Text = "Characters";
            this.tbCharacters.UseVisualStyleBackColor = true;
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Location = new System.Drawing.Point(830, 276);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(149, 27);
            this.btnDeleteComment.TabIndex = 28;
            this.btnDeleteComment.Text = "&Delete Comment";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(655, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Reject/Remove comment";
            // 
            // tboxRejectText
            // 
            this.tboxRejectText.Location = new System.Drawing.Point(655, 226);
            this.tboxRejectText.Multiline = true;
            this.tboxRejectText.Name = "tboxRejectText";
            this.tboxRejectText.Size = new System.Drawing.Size(324, 44);
            this.tboxRejectText.TabIndex = 26;
            // 
            // chkListBoxRejected
            // 
            this.chkListBoxRejected.FormattingEnabled = true;
            this.chkListBoxRejected.Location = new System.Drawing.Point(655, 45);
            this.chkListBoxRejected.Name = "chkListBoxRejected";
            this.chkListBoxRejected.Size = new System.Drawing.Size(324, 140);
            this.chkListBoxRejected.TabIndex = 25;
            this.chkListBoxRejected.SelectedIndexChanged += new System.EventHandler(this.chkListBoxRejected_SelectedIndexChanged);
            this.chkListBoxRejected.DoubleClick += new System.EventHandler(this.LoadSelectedChar);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(652, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Rejected / Removed";
            // 
            // btnCharApprove
            // 
            this.btnCharApprove.Location = new System.Drawing.Point(500, 275);
            this.btnCharApprove.Name = "btnCharApprove";
            this.btnCharApprove.Size = new System.Drawing.Size(149, 39);
            this.btnCharApprove.TabIndex = 23;
            this.btnCharApprove.Text = "&Approve";
            this.btnCharApprove.UseVisualStyleBackColor = true;
            this.btnCharApprove.Click += new System.EventHandler(this.btnCharApprove_Click);
            // 
            // btnCampaignReject
            // 
            this.btnCampaignReject.Location = new System.Drawing.Point(325, 275);
            this.btnCampaignReject.Name = "btnCampaignReject";
            this.btnCampaignReject.Size = new System.Drawing.Size(149, 39);
            this.btnCampaignReject.TabIndex = 22;
            this.btnCampaignReject.Text = "&Reject";
            this.btnCampaignReject.UseVisualStyleBackColor = true;
            this.btnCampaignReject.Click += new System.EventHandler(this.btnCampaignReject_Click);
            // 
            // btnCampaignRemove
            // 
            this.btnCampaignRemove.Location = new System.Drawing.Point(140, 276);
            this.btnCampaignRemove.Name = "btnCampaignRemove";
            this.btnCampaignRemove.Size = new System.Drawing.Size(167, 39);
            this.btnCampaignRemove.TabIndex = 21;
            this.btnCampaignRemove.Text = "&Remove";
            this.btnCampaignRemove.UseVisualStyleBackColor = true;
            this.btnCampaignRemove.Click += new System.EventHandler(this.btnCampaignRemove_Click);
            // 
            // chkListBoxPlayersPending
            // 
            this.chkListBoxPlayersPending.FormattingEnabled = true;
            this.chkListBoxPlayersPending.Location = new System.Drawing.Point(325, 44);
            this.chkListBoxPlayersPending.Name = "chkListBoxPlayersPending";
            this.chkListBoxPlayersPending.Size = new System.Drawing.Size(324, 225);
            this.chkListBoxPlayersPending.TabIndex = 20;
            this.chkListBoxPlayersPending.DoubleClick += new System.EventHandler(this.LoadSelectedChar);
            // 
            // chkListBoxPlayers
            // 
            this.chkListBoxPlayers.FormattingEnabled = true;
            this.chkListBoxPlayers.Location = new System.Drawing.Point(19, 45);
            this.chkListBoxPlayers.Name = "chkListBoxPlayers";
            this.chkListBoxPlayers.Size = new System.Drawing.Size(288, 225);
            this.chkListBoxPlayers.TabIndex = 19;
            this.chkListBoxPlayers.SelectedIndexChanged += new System.EventHandler(this.chkListBoxPlayers_SelectedIndexChanged);
            this.chkListBoxPlayers.DoubleClick += new System.EventHandler(this.LoadSelectedChar);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Players Requesting Access";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Players in the Campaign";
            // 
            // tbAdventures
            // 
            this.tbAdventures.BackColor = System.Drawing.Color.Silver;
            this.tbAdventures.Controls.Add(this.dGridAdventure);
            this.tbAdventures.Controls.Add(this.textBox2);
            this.tbAdventures.Controls.Add(this.textBox1);
            this.tbAdventures.Controls.Add(this.label14);
            this.tbAdventures.Controls.Add(this.label15);
            this.tbAdventures.Controls.Add(this.btnNewAdventure);
            this.tbAdventures.Controls.Add(this.btnDetails);
            this.tbAdventures.Controls.Add(this.label13);
            this.tbAdventures.Controls.Add(this.label11);
            this.tbAdventures.Controls.Add(this.tboxAdventureShortName);
            this.tbAdventures.Controls.Add(this.label5);
            this.tbAdventures.Controls.Add(this.tboxAdventureBiog);
            this.tbAdventures.Controls.Add(this.Date);
            this.tbAdventures.Controls.Add(this.dtpAdventureDate);
            this.tbAdventures.Controls.Add(this.label10);
            this.tbAdventures.Controls.Add(this.label12);
            this.tbAdventures.Controls.Add(this.tboxAdventureName);
            this.tbAdventures.Location = new System.Drawing.Point(4, 25);
            this.tbAdventures.Name = "tbAdventures";
            this.tbAdventures.Size = new System.Drawing.Size(995, 343);
            this.tbAdventures.TabIndex = 2;
            this.tbAdventures.Text = "Adventures";
            // 
            // btnNewAdventure
            // 
            this.btnNewAdventure.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAdventure.Location = new System.Drawing.Point(138, 262);
            this.btnNewAdventure.Name = "btnNewAdventure";
            this.btnNewAdventure.Size = new System.Drawing.Size(152, 45);
            this.btnNewAdventure.TabIndex = 34;
            this.btnNewAdventure.Text = "New Ad&venture";
            this.btnNewAdventure.UseVisualStyleBackColor = true;
            this.btnNewAdventure.Click += new System.EventHandler(this.btnNewAdventure_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.Location = new System.Drawing.Point(296, 262);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(152, 45);
            this.btnDetails.TabIndex = 17;
            this.btnDetails.Text = "&Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Players";
            // 
            // bs_nwAdventure
            // 
            this.bs_nwAdventure.AllowNew = true;
            this.bs_nwAdventure.DataSource = typeof(DataModel.libCampaign.campAdventure);
            this.bs_nwAdventure.Sort = "Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(479, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Name";
            // 
            // tboxAdventureShortName
            // 
            this.tboxAdventureShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "Name", true));
            this.tboxAdventureShortName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAdventureShortName.Location = new System.Drawing.Point(578, 55);
            this.tboxAdventureShortName.MaxLength = 10;
            this.tboxAdventureShortName.Name = "tboxAdventureShortName";
            this.tboxAdventureShortName.Size = new System.Drawing.Size(247, 28);
            this.tboxAdventureShortName.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Adv Biog";
            // 
            // tboxAdventureBiog
            // 
            this.tboxAdventureBiog.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "Description", true));
            this.tboxAdventureBiog.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAdventureBiog.Location = new System.Drawing.Point(578, 123);
            this.tboxAdventureBiog.MaxLength = 8000;
            this.tboxAdventureBiog.Multiline = true;
            this.tboxAdventureBiog.Name = "tboxAdventureBiog";
            this.tboxAdventureBiog.Size = new System.Drawing.Size(400, 116);
            this.tboxAdventureBiog.TabIndex = 27;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(480, 93);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(54, 17);
            this.Date.TabIndex = 26;
            this.Date.Text = "Started";
            // 
            // dtpAdventureDate
            // 
            this.dtpAdventureDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bs_nwAdventure, "Date", true));
            this.dtpAdventureDate.Location = new System.Drawing.Point(579, 93);
            this.dtpAdventureDate.Name = "dtpAdventureDate";
            this.dtpAdventureDate.Size = new System.Drawing.Size(247, 22);
            this.dtpAdventureDate.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "id", true));
            this.label10.Location = new System.Drawing.Point(831, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(479, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Long Name";
            // 
            // tboxAdventureName
            // 
            this.tboxAdventureName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "LongName", true));
            this.tboxAdventureName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxAdventureName.Location = new System.Drawing.Point(578, 21);
            this.tboxAdventureName.MaxLength = 42;
            this.tboxAdventureName.Name = "tboxAdventureName";
            this.tboxAdventureName.Size = new System.Drawing.Size(400, 28);
            this.tboxAdventureName.TabIndex = 20;
            // 
            // tbApprovals
            // 
            this.tbApprovals.Location = new System.Drawing.Point(4, 25);
            this.tbApprovals.Name = "tbApprovals";
            this.tbApprovals.Size = new System.Drawing.Size(995, 343);
            this.tbApprovals.TabIndex = 3;
            this.tbApprovals.Text = "Approvals";
            this.tbApprovals.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(712, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 45);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "&Delete Current";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(870, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 45);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save to DB";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddCampaign
            // 
            this.btnAddCampaign.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCampaign.Location = new System.Drawing.Point(1028, 387);
            this.btnAddCampaign.Name = "btnAddCampaign";
            this.btnAddCampaign.Size = new System.Drawing.Size(152, 45);
            this.btnAddCampaign.TabIndex = 12;
            this.btnAddCampaign.Text = "Add &New";
            this.btnAddCampaign.UseVisualStyleBackColor = true;
            this.btnAddCampaign.Click += new System.EventHandler(this.btnLoadChar_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(1196, 387);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(152, 45);
            this.btnQuit.TabIndex = 15;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // tboxMsg
            // 
            this.tboxMsg.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tboxMsg.Location = new System.Drawing.Point(0, 443);
            this.tboxMsg.Name = "tboxMsg";
            this.tboxMsg.Size = new System.Drawing.Size(1363, 22);
            this.tboxMsg.TabIndex = 16;
            // 
            // bs_nwCharCampaign
            // 
            this.bs_nwCharCampaign.AllowNew = false;
            this.bs_nwCharCampaign.DataSource = typeof(DataModel.libCampaign.campCharCampaign);
            this.bs_nwCharCampaign.CurrentChanged += new System.EventHandler(this.bs_nwCharCampaign_Queue_CurrentChanged);
            // 
            // bs_nwChar
            // 
            this.bs_nwChar.AllowNew = false;
            this.bs_nwChar.DataSource = typeof(DataModel.libHosting.hostChar);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "LongName", true));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(578, 279);
            this.textBox2.MaxLength = 42;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(400, 28);
            this.textBox2.TabIndex = 53;
            this.textBox2.Text = "not implemented yet";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwAdventure, "LongName", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(578, 245);
            this.textBox1.MaxLength = 42;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 28);
            this.textBox1.TabIndex = 52;
            this.textBox1.Text = "not implemented yet";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(481, 277);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 17);
            this.label14.TabIndex = 51;
            this.label14.Text = "Location";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(480, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 50;
            this.label15.Text = "Region";
            // 
            // dGridAdventure
            // 
            this.dGridAdventure.AllowUserToAddRows = false;
            this.dGridAdventure.AllowUserToDeleteRows = false;
            this.dGridAdventure.AutoGenerateColumns = false;
            this.dGridAdventure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridAdventure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.longNameDataGridViewTextBoxColumn});
            this.dGridAdventure.DataSource = this.bs_nwAdventure;
            this.dGridAdventure.Location = new System.Drawing.Point(12, 21);
            this.dGridAdventure.Name = "dGridAdventure";
            this.dGridAdventure.RowTemplate.Height = 24;
            this.dGridAdventure.Size = new System.Drawing.Size(436, 235);
            this.dGridAdventure.TabIndex = 54;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // longNameDataGridViewTextBoxColumn
            // 
            this.longNameDataGridViewTextBoxColumn.DataPropertyName = "LongName";
            this.longNameDataGridViewTextBoxColumn.HeaderText = "LongName";
            this.longNameDataGridViewTextBoxColumn.MaxInputLength = 42;
            this.longNameDataGridViewTextBoxColumn.Name = "longNameDataGridViewTextBoxColumn";
            this.longNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.longNameDataGridViewTextBoxColumn.Width = 290;
            // 
            // frmCampaign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 468);
            this.Controls.Add(this.tboxMsg);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddCampaign);
            this.Controls.Add(this.tabCampaign);
            this.Controls.Add(this.lboxLogon);
            this.Controls.Add(this.lboxCampaigns);
            this.Name = "frmCampaign";
            this.Text = "frmCampaign";
            this.Load += new System.EventHandler(this.frmCampaign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostCampaign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostUser)).EndInit();
            this.tabCampaign.ResumeLayout(false);
            this.tbCampaign.ResumeLayout(false);
            this.tbCampaign.PerformLayout();
            this.tbCharacters.ResumeLayout(false);
            this.tbCharacters.PerformLayout();
            this.tbAdventures.ResumeLayout(false);
            this.tbAdventures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwAdventure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharCampaign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAdventure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxCampaigns;
        private System.Windows.Forms.BindingSource bs_hostCampaign;
        private System.Windows.Forms.ListBox lboxLogon;
        private System.Windows.Forms.BindingSource bs_hostUser;
        private System.Windows.Forms.TabControl tabCampaign;
        private System.Windows.Forms.TabPage tbCampaign;
        private System.Windows.Forms.TabPage tbCharacters;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddCampaign;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TabPage tbAdventures;
        private System.Windows.Forms.TabPage tbApprovals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateStarted;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.TextBox tboxLongName;
        private System.Windows.Forms.Button btnCampaignReject;
        private System.Windows.Forms.Button btnCampaignRemove;
        private System.Windows.Forms.CheckedListBox chkListBoxPlayersPending;
        private System.Windows.Forms.CheckedListBox chkListBoxPlayers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboxMsg;
        private System.Windows.Forms.BindingSource bs_nwCharCampaign;
        private System.Windows.Forms.BindingSource bs_nwChar;
        private System.Windows.Forms.Button btnCharApprove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxRejectText;
        private System.Windows.Forms.CheckedListBox chkListBoxRejected;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnNewAdventure;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tboxAdventureShortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxAdventureBiog;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.DateTimePicker dtpAdventureDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tboxAdventureName;
        private System.Windows.Forms.BindingSource bs_nwAdventure;
        private System.Windows.Forms.DataGridView dGridAdventure;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longNameDataGridViewTextBoxColumn;
    }
}