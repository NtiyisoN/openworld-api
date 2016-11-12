namespace norwold.forms
{
    partial class frmCharacters
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
            this.lboxCharacters = new System.Windows.Forms.ListBox();
            this.bs_nwChar = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tbMain = new System.Windows.Forms.TabPage();
            this.btnJoin = new System.Windows.Forms.Button();
            this.lboxCampaigns = new System.Windows.Forms.ListBox();
            this.bs_nwCharCampaign = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lboxAlignment = new System.Windows.Forms.ListBox();
            this.bs_sysAlignment = new System.Windows.Forms.BindingSource(this.components);
            this.LblID = new System.Windows.Forms.Label();
            this.chkNPC = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxName = new System.Windows.Forms.TextBox();
            this.tboxLongName = new System.Windows.Forms.TextBox();
            this.tbItems = new System.Windows.Forms.TabPage();
            this.lblItemType = new System.Windows.Forms.Label();
            this.btnSetItem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bs_nwItem = new System.Windows.Forms.BindingSource(this.components);
            this.tboxItemLongName = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnItemNew = new System.Windows.Forms.Button();
            this.btnItemRemove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxItemNotes = new System.Windows.Forms.TextBox();
            this.tbStats = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bs_nwCharStat = new System.Windows.Forms.BindingSource(this.components);
            this.bs_hostCampaign = new System.Windows.Forms.BindingSource(this.components);
            this.tboxMsg = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bs_logons = new System.Windows.Forms.BindingSource(this.components);
            this.lboxLogon = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.statDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeStatistic = new System.Windows.Forms.TreeView();
            this.bs_sysTreeStatistic = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwChar)).BeginInit();
            this.tabDetails.SuspendLayout();
            this.tbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharCampaign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_sysAlignment)).BeginInit();
            this.tbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwItem)).BeginInit();
            this.tbStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostCampaign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_logons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_sysTreeStatistic)).BeginInit();
            this.SuspendLayout();
            // 
            // lboxCharacters
            // 
            this.lboxCharacters.DataSource = this.bs_nwChar;
            this.lboxCharacters.DisplayMember = "LongName";
            this.lboxCharacters.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxCharacters.FormattingEnabled = true;
            this.lboxCharacters.ItemHeight = 21;
            this.lboxCharacters.Location = new System.Drawing.Point(30, 14);
            this.lboxCharacters.Name = "lboxCharacters";
            this.lboxCharacters.Size = new System.Drawing.Size(255, 361);
            this.lboxCharacters.TabIndex = 0;
            // 
            // bs_nwChar
            // 
            this.bs_nwChar.DataSource = typeof(DataModel.libHosting.hostChar);
            this.bs_nwChar.Sort = "LongName";
            this.bs_nwChar.DataMemberChanged += new System.EventHandler(this.bs_nwChar_DataMemberChanged);
            this.bs_nwChar.CurrentChanged += new System.EventHandler(this.nwCharBindingSource_CurrentChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(694, 423);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 45);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add &New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tbMain);
            this.tabDetails.Controls.Add(this.tbItems);
            this.tabDetails.Controls.Add(this.tbStats);
            this.tabDetails.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetails.Location = new System.Drawing.Point(311, 14);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(694, 403);
            this.tabDetails.TabIndex = 2;
            // 
            // tbMain
            // 
            this.tbMain.BackColor = System.Drawing.Color.Gainsboro;
            this.tbMain.Controls.Add(this.btnJoin);
            this.tbMain.Controls.Add(this.lboxCampaigns);
            this.tbMain.Controls.Add(this.label3);
            this.tbMain.Controls.Add(this.label9);
            this.tbMain.Controls.Add(this.lboxAlignment);
            this.tbMain.Controls.Add(this.LblID);
            this.tbMain.Controls.Add(this.chkNPC);
            this.tbMain.Controls.Add(this.label4);
            this.tbMain.Controls.Add(this.tboxDescription);
            this.tbMain.Controls.Add(this.label2);
            this.tbMain.Controls.Add(this.label1);
            this.tbMain.Controls.Add(this.tboxName);
            this.tbMain.Controls.Add(this.tboxLongName);
            this.tbMain.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMain.Location = new System.Drawing.Point(4, 30);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(686, 369);
            this.tbMain.TabIndex = 2;
            this.tbMain.Text = "Char";
            // 
            // btnJoin
            // 
            this.btnJoin.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.Location = new System.Drawing.Point(419, 313);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(236, 36);
            this.btnJoin.TabIndex = 11;
            this.btnJoin.Text = "&Request to Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // lboxCampaigns
            // 
            this.lboxCampaigns.DataSource = this.bs_nwCharCampaign;
            this.lboxCampaigns.DisplayMember = "Campaign";
            this.lboxCampaigns.FormattingEnabled = true;
            this.lboxCampaigns.ItemHeight = 21;
            this.lboxCampaigns.Location = new System.Drawing.Point(112, 240);
            this.lboxCampaigns.Name = "lboxCampaigns";
            this.lboxCampaigns.Size = new System.Drawing.Size(543, 67);
            this.lboxCampaigns.TabIndex = 15;
            // 
            // bs_nwCharCampaign
            // 
            this.bs_nwCharCampaign.DataSource = typeof(DataModel.libCampaign.campCharCampaign);
            this.bs_nwCharCampaign.CurrentChanged += new System.EventHandler(this.nwCharCampaignBindingSource_CurrentChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Campaigns";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "Alignment";
            // 
            // lboxAlignment
            // 
            this.lboxAlignment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bs_nwChar, "Alignment", true));
            this.lboxAlignment.DataSource = this.bs_sysAlignment;
            this.lboxAlignment.DisplayMember = "LongName";
            this.lboxAlignment.FormattingEnabled = true;
            this.lboxAlignment.ItemHeight = 21;
            this.lboxAlignment.Location = new System.Drawing.Point(112, 86);
            this.lboxAlignment.Name = "lboxAlignment";
            this.lboxAlignment.Size = new System.Drawing.Size(543, 25);
            this.lboxAlignment.TabIndex = 11;
            this.lboxAlignment.ValueMember = "id";
            this.lboxAlignment.SelectedIndexChanged += new System.EventHandler(this.lboxAlignment_SelectedIndexChanged);
            // 
            // bs_sysAlignment
            // 
            this.bs_sysAlignment.DataSource = typeof(DataModel.libData.sysBaseAlignment);
            this.bs_sysAlignment.CurrentChanged += new System.EventHandler(this.bs_sysAlignment_CurrentChanged);
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwChar, "id", true));
            this.LblID.Location = new System.Drawing.Point(534, 16);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(24, 21);
            this.LblID.TabIndex = 10;
            this.LblID.Text = "ID";
            // 
            // chkNPC
            // 
            this.chkNPC.AutoSize = true;
            this.chkNPC.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_nwChar, "isNPC", true));
            this.chkNPC.Location = new System.Drawing.Point(342, 53);
            this.chkNPC.Name = "chkNPC";
            this.chkNPC.Size = new System.Drawing.Size(72, 25);
            this.chkNPC.TabIndex = 9;
            this.chkNPC.Text = "IsNPC";
            this.chkNPC.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notes";
            // 
            // tboxDescription
            // 
            this.tboxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwChar, "Description", true));
            this.tboxDescription.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDescription.Location = new System.Drawing.Point(112, 125);
            this.tboxDescription.MaxLength = 8000;
            this.tboxDescription.Multiline = true;
            this.tboxDescription.Name = "tboxDescription";
            this.tboxDescription.Size = new System.Drawing.Size(543, 61);
            this.tboxDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Long Name";
            // 
            // tboxName
            // 
            this.tboxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwChar, "Name", true));
            this.tboxName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxName.Location = new System.Drawing.Point(112, 50);
            this.tboxName.MaxLength = 10;
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(202, 28);
            this.tboxName.TabIndex = 1;
            // 
            // tboxLongName
            // 
            this.tboxLongName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwChar, "LongName", true));
            this.tboxLongName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxLongName.Location = new System.Drawing.Point(112, 16);
            this.tboxLongName.MaxLength = 42;
            this.tboxLongName.Name = "tboxLongName";
            this.tboxLongName.Size = new System.Drawing.Size(400, 28);
            this.tboxLongName.TabIndex = 0;
            // 
            // tbItems
            // 
            this.tbItems.BackColor = System.Drawing.Color.Gainsboro;
            this.tbItems.Controls.Add(this.lblItemType);
            this.tbItems.Controls.Add(this.btnSetItem);
            this.tbItems.Controls.Add(this.label10);
            this.tbItems.Controls.Add(this.label7);
            this.tbItems.Controls.Add(this.label8);
            this.tbItems.Controls.Add(this.textBox1);
            this.tbItems.Controls.Add(this.tboxItemLongName);
            this.tbItems.Controls.Add(this.lblItemID);
            this.tbItems.Controls.Add(this.btnItemNew);
            this.tbItems.Controls.Add(this.btnItemRemove);
            this.tbItems.Controls.Add(this.label6);
            this.tbItems.Controls.Add(this.listBox1);
            this.tbItems.Controls.Add(this.label5);
            this.tbItems.Controls.Add(this.tboxItemNotes);
            this.tbItems.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItems.Location = new System.Drawing.Point(4, 30);
            this.tbItems.Name = "tbItems";
            this.tbItems.Padding = new System.Windows.Forms.Padding(3);
            this.tbItems.Size = new System.Drawing.Size(686, 369);
            this.tbItems.TabIndex = 0;
            this.tbItems.Text = "Items";
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(102, 284);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(46, 21);
            this.lblItemType.TabIndex = 20;
            this.lblItemType.Text = "PATH";
            // 
            // btnSetItem
            // 
            this.btnSetItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetItem.Location = new System.Drawing.Point(554, 278);
            this.btnSetItem.Name = "btnSetItem";
            this.btnSetItem.Size = new System.Drawing.Size(121, 33);
            this.btnSetItem.TabIndex = 19;
            this.btnSetItem.Text = "&Set Item Type";
            this.btnSetItem.UseVisualStyleBackColor = true;
            this.btnSetItem.Click += new System.EventHandler(this.btnSetItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 21);
            this.label10.TabIndex = 18;
            this.label10.Text = "Item Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Long Name";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwItem, "Name", true));
            this.textBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(106, 181);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 28);
            this.textBox1.TabIndex = 15;
            // 
            // bs_nwItem
            // 
            this.bs_nwItem.DataSource = typeof(DataModel.libData.nwItem);
            this.bs_nwItem.Sort = "";
            this.bs_nwItem.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // tboxItemLongName
            // 
            this.tboxItemLongName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwItem, "LongName", true));
            this.tboxItemLongName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxItemLongName.Location = new System.Drawing.Point(106, 147);
            this.tboxItemLongName.MaxLength = 42;
            this.tboxItemLongName.Name = "tboxItemLongName";
            this.tboxItemLongName.Size = new System.Drawing.Size(400, 28);
            this.tboxItemLongName.TabIndex = 14;
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwItem, "id", true));
            this.lblItemID.Location = new System.Drawing.Point(592, 153);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(56, 21);
            this.lblItemID.TabIndex = 13;
            this.lblItemID.Text = "ItemID";
            // 
            // btnItemNew
            // 
            this.btnItemNew.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemNew.Location = new System.Drawing.Point(554, 327);
            this.btnItemNew.Name = "btnItemNew";
            this.btnItemNew.Size = new System.Drawing.Size(121, 33);
            this.btnItemNew.TabIndex = 12;
            this.btnItemNew.Text = "New &Item";
            this.btnItemNew.UseVisualStyleBackColor = true;
            this.btnItemNew.Click += new System.EventHandler(this.btnItemNew_Click);
            // 
            // btnItemRemove
            // 
            this.btnItemRemove.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemRemove.Location = new System.Drawing.Point(427, 327);
            this.btnItemRemove.Name = "btnItemRemove";
            this.btnItemRemove.Size = new System.Drawing.Size(121, 33);
            this.btnItemRemove.TabIndex = 5;
            this.btnItemRemove.Text = "&Remove Item";
            this.btnItemRemove.UseVisualStyleBackColor = true;
            this.btnItemRemove.Click += new System.EventHandler(this.btnItemRemove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Items";
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.bs_nwItem;
            this.listBox1.DisplayMember = "LongName";
            this.listBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(106, 8);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(574, 130);
            this.listBox1.TabIndex = 10;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notes";
            // 
            // tboxItemNotes
            // 
            this.tboxItemNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_nwItem, "Description", true));
            this.tboxItemNotes.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxItemNotes.Location = new System.Drawing.Point(106, 217);
            this.tboxItemNotes.MaxLength = 8000;
            this.tboxItemNotes.Multiline = true;
            this.tboxItemNotes.Name = "tboxItemNotes";
            this.tboxItemNotes.Size = new System.Drawing.Size(574, 55);
            this.tboxItemNotes.TabIndex = 8;
            // 
            // tbStats
            // 
            this.tbStats.BackColor = System.Drawing.Color.Gainsboro;
            this.tbStats.Controls.Add(this.treeStatistic);
            this.tbStats.Controls.Add(this.dataGridView1);
            this.tbStats.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStats.Location = new System.Drawing.Point(4, 30);
            this.tbStats.Name = "tbStats";
            this.tbStats.Padding = new System.Windows.Forms.Padding(3);
            this.tbStats.Size = new System.Drawing.Size(686, 369);
            this.tbStats.TabIndex = 1;
            this.tbStats.Text = "Stats";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bs_nwCharStat;
            this.dataGridView1.Location = new System.Drawing.Point(330, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(350, 341);
            this.dataGridView1.TabIndex = 0;
            // 
            // bs_nwCharStat
            // 
            this.bs_nwCharStat.AllowNew = false;
            this.bs_nwCharStat.DataSource = typeof(DataModel.libHosting.hostCharStat);
            this.bs_nwCharStat.CurrentChanged += new System.EventHandler(this.bs_nwCharStat_CurrentChanged);
            // 
            // bs_hostCampaign
            // 
            this.bs_hostCampaign.DataSource = typeof(DataModel.libCampaign.campCampaign);
            this.bs_hostCampaign.DataMemberChanged += new System.EventHandler(this.bs_campaigns_DataMemberChanged);
            // 
            // tboxMsg
            // 
            this.tboxMsg.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tboxMsg.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxMsg.Location = new System.Drawing.Point(-5, 474);
            this.tboxMsg.MaxLength = 42;
            this.tboxMsg.Name = "tboxMsg";
            this.tboxMsg.ReadOnly = true;
            this.tboxMsg.Size = new System.Drawing.Size(1043, 28);
            this.tboxMsg.TabIndex = 8;
            this.tboxMsg.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(536, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save to DB";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(378, 423);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 45);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete Current";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bs_logons
            // 
            this.bs_logons.DataSource = typeof(DataModel.libHosting.hostUser);
            this.bs_logons.CurrentChanged += new System.EventHandler(this.bs_logons_CurrentChanged);
            // 
            // lboxLogon
            // 
            this.lboxLogon.DataSource = this.bs_logons;
            this.lboxLogon.DisplayMember = "LongName";
            this.lboxLogon.FormattingEnabled = true;
            this.lboxLogon.ItemHeight = 16;
            this.lboxLogon.Location = new System.Drawing.Point(30, 382);
            this.lboxLogon.Name = "lboxLogon";
            this.lboxLogon.Size = new System.Drawing.Size(255, 36);
            this.lboxLogon.TabIndex = 9;
            this.lboxLogon.SelectedIndexChanged += new System.EventHandler(this.lboxLogon_SelectedIndexChanged);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(852, 423);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(152, 45);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // statDataGridViewTextBoxColumn
            // 
            this.statDataGridViewTextBoxColumn.DataPropertyName = "stat";
            this.statDataGridViewTextBoxColumn.HeaderText = "stat";
            this.statDataGridViewTextBoxColumn.Name = "statDataGridViewTextBoxColumn";
            this.statDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // treeStatistic
            // 
            this.treeStatistic.Location = new System.Drawing.Point(25, 7);
            this.treeStatistic.Name = "treeStatistic";
            this.treeStatistic.Size = new System.Drawing.Size(237, 341);
            this.treeStatistic.TabIndex = 32;
            this.treeStatistic.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeStatistic_AfterSelect);
            // 
            // bs_sysTreeStatistic
            // 
            this.bs_sysTreeStatistic.DataSource = typeof(DataModel.libData.sysTreeStatistic);
            this.bs_sysTreeStatistic.CurrentChanged += new System.EventHandler(this.bs_sysTreeStatistic_CurrentChanged);
            // 
            // frmCharacters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 499);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lboxLogon);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tboxMsg);
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lboxCharacters);
            this.Name = "frmCharacters";
            this.Text = "Norwold Character Database";
            this.Load += new System.EventHandler(this.frmCharacters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwChar)).EndInit();
            this.tabDetails.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharCampaign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_sysAlignment)).EndInit();
            this.tbItems.ResumeLayout(false);
            this.tbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwItem)).EndInit();
            this.tbStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwCharStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_hostCampaign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_logons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_sysTreeStatistic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxCharacters;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tbItems;
        private System.Windows.Forms.TabPage tbStats;
        private System.Windows.Forms.TabPage tbMain;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.TextBox tboxLongName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxDescription;
        private System.Windows.Forms.TextBox tboxMsg;
        private System.Windows.Forms.BindingSource bs_nwChar;
        private System.Windows.Forms.CheckBox chkNPC;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxItemNotes;
        private System.Windows.Forms.BindingSource bs_nwItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tboxItemLongName;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Button btnItemNew;
        private System.Windows.Forms.Button btnItemRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
//        private System.Windows.Forms.DataGridViewTextBoxColumn defaultvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bs_nwCharStat;
        private System.Windows.Forms.BindingSource bs_sysAlignment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lboxAlignment;
        private System.Windows.Forms.Button btnSetItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.BindingSource bs_logons;
        private System.Windows.Forms.ListBox lboxLogon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bs_hostCampaign;
        private System.Windows.Forms.ListBox lboxCampaigns;
        private System.Windows.Forms.BindingSource bs_nwCharCampaign;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.DataGridViewTextBoxColumn statDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.TreeView treeStatistic;
        private System.Windows.Forms.BindingSource bs_sysTreeStatistic;
    }
}

