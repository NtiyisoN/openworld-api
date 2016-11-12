namespace norwold.forms
{
    partial class FrmMapDesigner
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
            this.tabData = new System.Windows.Forms.TabControl();
            this.tbTileset = new System.Windows.Forms.TabPage();
            this.lblTreeID = new System.Windows.Forms.Label();
            this.bs_mapDetail = new System.Windows.Forms.BindingSource(this.components);
            this.tboxBranchValue = new System.Windows.Forms.TextBox();
            this.tboxBranchName = new System.Windows.Forms.TextBox();
            this.lblTreeName = new System.Windows.Forms.Label();
            this.owTree = new norwold.forms.base_classes.openwTreeView();
            this.bs_mapTree = new System.Windows.Forms.BindingSource(this.components);
            this.lblMasterDetailID = new System.Windows.Forms.Label();
            this.tboxMasterDetailLongName = new System.Windows.Forms.TextBox();
            this.tboxMasterDetailName = new System.Windows.Forms.TextBox();
            this.lboxMDDetails = new System.Windows.Forms.ListBox();
            this.btnMDSaveDetail = new System.Windows.Forms.Button();
            this.tabMDGboxes = new System.Windows.Forms.TabControl();
            this.tbTerrain = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.tboxTerrainTypeValue = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tboxTerrainTypeImportName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tboxTerrainTypeResName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tboxTerrainTypeStepCost = new System.Windows.Forms.TextBox();
            this.tboxTerrainTypeHeight = new System.Windows.Forms.TextBox();
            this.tboxTerrainTypeElevation = new System.Windows.Forms.TextBox();
            this.picTerrainTypeGraphic = new System.Windows.Forms.PictureBox();
            this.btnMDRemove = new System.Windows.Forms.Button();
            this.btnMDAdd = new System.Windows.Forms.Button();
            this.btnMDChangePath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMasterPath = new System.Windows.Forms.Label();
            this.treeMasterDetail = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.bs_mapPOI = new System.Windows.Forms.BindingSource(this.components);
            this.lboxMapMenu = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabData.SuspendLayout();
            this.tbTileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapTree)).BeginInit();
            this.tabMDGboxes.SuspendLayout();
            this.tbTerrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTerrainTypeGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapPOI)).BeginInit();
            this.SuspendLayout();
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.tbTileset);
            this.tabData.Location = new System.Drawing.Point(192, 4);
            this.tabData.Name = "tabData";
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(1029, 453);
            this.tabData.TabIndex = 4;
            // 
            // tbTileset
            // 
            this.tbTileset.Controls.Add(this.lblTreeID);
            this.tbTileset.Controls.Add(this.tboxBranchValue);
            this.tbTileset.Controls.Add(this.tboxBranchName);
            this.tbTileset.Controls.Add(this.lblTreeName);
            this.tbTileset.Controls.Add(this.owTree);
            this.tbTileset.Controls.Add(this.btnMDSaveDetail);
            this.tbTileset.Controls.Add(this.tabMDGboxes);
            this.tbTileset.Controls.Add(this.btnMDRemove);
            this.tbTileset.Controls.Add(this.btnMDAdd);
            this.tbTileset.Controls.Add(this.btnMDChangePath);
            this.tbTileset.Controls.Add(this.label6);
            this.tbTileset.Controls.Add(this.tboxMasterDetailLongName);
            this.tbTileset.Controls.Add(this.lblMasterDetailID);
            this.tbTileset.Controls.Add(this.label3);
            this.tbTileset.Controls.Add(this.tboxMasterDetailName);
            this.tbTileset.Controls.Add(this.lboxMDDetails);
            this.tbTileset.Controls.Add(this.lblMasterPath);
            this.tbTileset.Controls.Add(this.treeMasterDetail);
            this.tbTileset.Location = new System.Drawing.Point(4, 25);
            this.tbTileset.Name = "tbTileset";
            this.tbTileset.Padding = new System.Windows.Forms.Padding(3);
            this.tbTileset.Size = new System.Drawing.Size(1021, 424);
            this.tbTileset.TabIndex = 0;
            this.tbTileset.Text = "TileSets";
            this.tbTileset.UseVisualStyleBackColor = true;
            // 
            // lblTreeID
            // 
            this.lblTreeID.AutoSize = true;
            this.lblTreeID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_mapDetail, "ID", true));
            this.lblTreeID.Location = new System.Drawing.Point(175, 364);
            this.lblTreeID.Name = "lblTreeID";
            this.lblTreeID.Size = new System.Drawing.Size(21, 17);
            this.lblTreeID.TabIndex = 65;
            this.lblTreeID.Text = "ID";
            // 
            // bs_mapDetail
            // 
            this.bs_mapDetail.DataSource = typeof(DataModel.libMapping.mapTreeTerrain);
            this.bs_mapDetail.CurrentChanged += new System.EventHandler(this.bs_mapTreeTerrain_CurrentChanged);
            // 
            // tboxBranchValue
            // 
            this.tboxBranchValue.Location = new System.Drawing.Point(181, 385);
            this.tboxBranchValue.Name = "tboxBranchValue";
            this.tboxBranchValue.Size = new System.Drawing.Size(73, 22);
            this.tboxBranchValue.TabIndex = 64;
            // 
            // tboxBranchName
            // 
            this.tboxBranchName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_mapDetail, "Name", true));
            this.tboxBranchName.Location = new System.Drawing.Point(10, 385);
            this.tboxBranchName.Name = "tboxBranchName";
            this.tboxBranchName.Size = new System.Drawing.Size(165, 22);
            this.tboxBranchName.TabIndex = 63;
            // 
            // lblTreeName
            // 
            this.lblTreeName.AutoSize = true;
            this.lblTreeName.Location = new System.Drawing.Point(7, 364);
            this.lblTreeName.Name = "lblTreeName";
            this.lblTreeName.Size = new System.Drawing.Size(79, 17);
            this.lblTreeName.TabIndex = 62;
            this.lblTreeName.Text = "Tree Name";
            // 
            // owTree
            // 
            this.owTree.DetailBindingSource = this.bs_mapTree;
            this.owTree.DetailEditID = this.lblMasterDetailID;
            this.owTree.DetailEditLongName = this.tboxMasterDetailLongName;
            this.owTree.DetailEditName = this.tboxMasterDetailName;
            this.owTree.DetailGroupBox = null;
            this.owTree.DetailListBox = this.lboxMDDetails;
            this.owTree.ListBoxTreeSelect = null;
            this.owTree.Location = new System.Drawing.Point(4, 15);
            this.owTree.Name = "owTree";
            this.owTree.nwdbTree = null;
            this.owTree.Session = null;
            this.owTree.Size = new System.Drawing.Size(253, 342);
            this.owTree.TabIndex = 61;
            this.owTree.TreeBindingSource = this.bs_mapDetail;
            this.owTree.TreeEditID = this.lblTreeID;
            this.owTree.TreeEditMode = false;
            this.owTree.TreeEditName = this.tboxBranchName;
            this.owTree.TreeEditTreeName = this.lblTreeName;
            this.owTree.TreeEditValue = this.tboxBranchValue;
            this.owTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.owTree_AfterSelect);
            // 
            // bs_mapTree
            // 
            this.bs_mapTree.DataSource = typeof(DataModel.libMapping.mapTerrainType);
            // 
            // lblMasterDetailID
            // 
            this.lblMasterDetailID.AutoSize = true;
            this.lblMasterDetailID.Location = new System.Drawing.Point(771, 50);
            this.lblMasterDetailID.Name = "lblMasterDetailID";
            this.lblMasterDetailID.Size = new System.Drawing.Size(21, 17);
            this.lblMasterDetailID.TabIndex = 36;
            this.lblMasterDetailID.Text = "ID";
            // 
            // tboxMasterDetailLongName
            // 
            this.tboxMasterDetailLongName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxMasterDetailLongName.Location = new System.Drawing.Point(563, 16);
            this.tboxMasterDetailLongName.MaxLength = 42;
            this.tboxMasterDetailLongName.Name = "tboxMasterDetailLongName";
            this.tboxMasterDetailLongName.Size = new System.Drawing.Size(305, 28);
            this.tboxMasterDetailLongName.TabIndex = 37;
            // 
            // tboxMasterDetailName
            // 
            this.tboxMasterDetailName.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxMasterDetailName.Location = new System.Drawing.Point(563, 50);
            this.tboxMasterDetailName.MaxLength = 10;
            this.tboxMasterDetailName.Name = "tboxMasterDetailName";
            this.tboxMasterDetailName.Size = new System.Drawing.Size(202, 28);
            this.tboxMasterDetailName.TabIndex = 34;
            // 
            // lboxMDDetails
            // 
            this.lboxMDDetails.DataSource = this.bs_mapTree;
            this.lboxMDDetails.DisplayMember = "LongName";
            this.lboxMDDetails.FormattingEnabled = true;
            this.lboxMDDetails.ItemHeight = 16;
            this.lboxMDDetails.Location = new System.Drawing.Point(263, 17);
            this.lboxMDDetails.Name = "lboxMDDetails";
            this.lboxMDDetails.Size = new System.Drawing.Size(198, 340);
            this.lboxMDDetails.TabIndex = 33;
            // 
            // btnMDSaveDetail
            // 
            this.btnMDSaveDetail.Location = new System.Drawing.Point(603, 340);
            this.btnMDSaveDetail.Name = "btnMDSaveDetail";
            this.btnMDSaveDetail.Size = new System.Drawing.Size(112, 38);
            this.btnMDSaveDetail.TabIndex = 60;
            this.btnMDSaveDetail.Text = "Save &Detail";
            this.btnMDSaveDetail.UseVisualStyleBackColor = true;
            // 
            // tabMDGboxes
            // 
            this.tabMDGboxes.Controls.Add(this.tbTerrain);
            this.tabMDGboxes.Location = new System.Drawing.Point(563, 113);
            this.tabMDGboxes.Name = "tabMDGboxes";
            this.tabMDGboxes.SelectedIndex = 0;
            this.tabMDGboxes.Size = new System.Drawing.Size(450, 221);
            this.tabMDGboxes.TabIndex = 59;
            // 
            // tbTerrain
            // 
            this.tbTerrain.Controls.Add(this.label22);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeValue);
            this.tbTerrain.Controls.Add(this.label21);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeImportName);
            this.tbTerrain.Controls.Add(this.label20);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeResName);
            this.tbTerrain.Controls.Add(this.label19);
            this.tbTerrain.Controls.Add(this.label18);
            this.tbTerrain.Controls.Add(this.label13);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeStepCost);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeHeight);
            this.tbTerrain.Controls.Add(this.tboxTerrainTypeElevation);
            this.tbTerrain.Controls.Add(this.picTerrainTypeGraphic);
            this.tbTerrain.Location = new System.Drawing.Point(4, 25);
            this.tbTerrain.Name = "tbTerrain";
            this.tbTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tbTerrain.Size = new System.Drawing.Size(442, 192);
            this.tbTerrain.TabIndex = 0;
            this.tbTerrain.Text = "Terrain";
            this.tbTerrain.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 163);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 17);
            this.label22.TabIndex = 24;
            this.label22.Text = "Value";
            // 
            // tboxTerrainTypeValue
            // 
            this.tboxTerrainTypeValue.Location = new System.Drawing.Point(89, 160);
            this.tboxTerrainTypeValue.MaxLength = 1;
            this.tboxTerrainTypeValue.Name = "tboxTerrainTypeValue";
            this.tboxTerrainTypeValue.Size = new System.Drawing.Size(24, 22);
            this.tboxTerrainTypeValue.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(2, 130);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 17);
            this.label21.TabIndex = 22;
            this.label21.Text = "ImportName";
            // 
            // tboxTerrainTypeImportName
            // 
            this.tboxTerrainTypeImportName.Location = new System.Drawing.Point(89, 127);
            this.tboxTerrainTypeImportName.Name = "tboxTerrainTypeImportName";
            this.tboxTerrainTypeImportName.Size = new System.Drawing.Size(204, 22);
            this.tboxTerrainTypeImportName.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 20;
            this.label20.Text = "Resname";
            // 
            // tboxTerrainTypeResName
            // 
            this.tboxTerrainTypeResName.Location = new System.Drawing.Point(89, 99);
            this.tboxTerrainTypeResName.Name = "tboxTerrainTypeResName";
            this.tboxTerrainTypeResName.Size = new System.Drawing.Size(204, 22);
            this.tboxTerrainTypeResName.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 17);
            this.label19.TabIndex = 18;
            this.label19.Text = "StepCost";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 17);
            this.label18.TabIndex = 17;
            this.label18.Text = "Height";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "Elevation";
            // 
            // tboxTerrainTypeStepCost
            // 
            this.tboxTerrainTypeStepCost.Location = new System.Drawing.Point(89, 70);
            this.tboxTerrainTypeStepCost.Name = "tboxTerrainTypeStepCost";
            this.tboxTerrainTypeStepCost.Size = new System.Drawing.Size(100, 22);
            this.tboxTerrainTypeStepCost.TabIndex = 15;
            // 
            // tboxTerrainTypeHeight
            // 
            this.tboxTerrainTypeHeight.Location = new System.Drawing.Point(89, 42);
            this.tboxTerrainTypeHeight.Name = "tboxTerrainTypeHeight";
            this.tboxTerrainTypeHeight.Size = new System.Drawing.Size(100, 22);
            this.tboxTerrainTypeHeight.TabIndex = 14;
            // 
            // tboxTerrainTypeElevation
            // 
            this.tboxTerrainTypeElevation.Location = new System.Drawing.Point(89, 14);
            this.tboxTerrainTypeElevation.Name = "tboxTerrainTypeElevation";
            this.tboxTerrainTypeElevation.Size = new System.Drawing.Size(100, 22);
            this.tboxTerrainTypeElevation.TabIndex = 13;
            // 
            // picTerrainTypeGraphic
            // 
            this.picTerrainTypeGraphic.Location = new System.Drawing.Point(300, 3);
            this.picTerrainTypeGraphic.Margin = new System.Windows.Forms.Padding(0);
            this.picTerrainTypeGraphic.Name = "picTerrainTypeGraphic";
            this.picTerrainTypeGraphic.Size = new System.Drawing.Size(139, 122);
            this.picTerrainTypeGraphic.TabIndex = 0;
            this.picTerrainTypeGraphic.TabStop = false;
            this.picTerrainTypeGraphic.Click += new System.EventHandler(this.picTerrain_Click);
            // 
            // btnMDRemove
            // 
            this.btnMDRemove.Location = new System.Drawing.Point(742, 338);
            this.btnMDRemove.Name = "btnMDRemove";
            this.btnMDRemove.Size = new System.Drawing.Size(126, 38);
            this.btnMDRemove.TabIndex = 42;
            this.btnMDRemove.Text = "Remove Detail";
            this.btnMDRemove.UseVisualStyleBackColor = true;
            // 
            // btnMDAdd
            // 
            this.btnMDAdd.Location = new System.Drawing.Point(467, 338);
            this.btnMDAdd.Name = "btnMDAdd";
            this.btnMDAdd.Size = new System.Drawing.Size(98, 38);
            this.btnMDAdd.TabIndex = 40;
            this.btnMDAdd.Text = "Add Detail";
            this.btnMDAdd.UseVisualStyleBackColor = true;
            // 
            // btnMDChangePath
            // 
            this.btnMDChangePath.Location = new System.Drawing.Point(475, 84);
            this.btnMDChangePath.Name = "btnMDChangePath";
            this.btnMDChangePath.Size = new System.Drawing.Size(90, 25);
            this.btnMDChangePath.TabIndex = 31;
            this.btnMDChangePath.Text = "&Change";
            this.btnMDChangePath.UseVisualStyleBackColor = true;
            this.btnMDChangePath.Click += new System.EventHandler(this.btnMDChangePath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "LongName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Name";
            // 
            // lblMasterPath
            // 
            this.lblMasterPath.AutoSize = true;
            this.lblMasterPath.Location = new System.Drawing.Point(571, 88);
            this.lblMasterPath.Name = "lblMasterPath";
            this.lblMasterPath.Size = new System.Drawing.Size(80, 17);
            this.lblMasterPath.TabIndex = 32;
            this.lblMasterPath.Text = "MasterPath";
            this.lblMasterPath.Click += new System.EventHandler(this.lblMasterPath_Click);
            // 
            // treeMasterDetail
            // 
            this.treeMasterDetail.Location = new System.Drawing.Point(17, 15);
            this.treeMasterDetail.Name = "treeMasterDetail";
            this.treeMasterDetail.Size = new System.Drawing.Size(237, 342);
            this.treeMasterDetail.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load Tree";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bs_mapPOI
            // 
            this.bs_mapPOI.DataSource = typeof(DataModel.libMapping.mapPOIType);
            // 
            // lboxMapMenu
            // 
            this.lboxMapMenu.FormattingEnabled = true;
            this.lboxMapMenu.ItemHeight = 16;
            this.lboxMapMenu.Location = new System.Drawing.Point(13, 29);
            this.lboxMapMenu.Name = "lboxMapMenu";
            this.lboxMapMenu.Size = new System.Drawing.Size(173, 84);
            this.lboxMapMenu.TabIndex = 6;
            this.lboxMapMenu.SelectedIndexChanged += new System.EventHandler(this.lboxMapMenu_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMapDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1221, 485);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lboxMapMenu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabData);
            this.Name = "FrmMapDesigner";
            this.Text = "Map Designer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.tabData, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.lboxMapMenu, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.tabData.ResumeLayout(false);
            this.tbTileset.ResumeLayout(false);
            this.tbTileset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapTree)).EndInit();
            this.tabMDGboxes.ResumeLayout(false);
            this.tbTerrain.ResumeLayout(false);
            this.tbTerrain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTerrainTypeGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_mapPOI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabData;
        private System.Windows.Forms.TabPage tbTileset;
        private System.Windows.Forms.Button btnMDSaveDetail;
        private System.Windows.Forms.Button btnMDRemove;
        private System.Windows.Forms.Button btnMDAdd;
        private System.Windows.Forms.Button btnMDChangePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboxMasterDetailLongName;
        private System.Windows.Forms.Label lblMasterDetailID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxMasterDetailName;
        private System.Windows.Forms.ListBox lboxMDDetails;
        private System.Windows.Forms.Label lblMasterPath;
        private System.Windows.Forms.TreeView treeMasterDetail;
        private base_classes.openwTreeView owTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bs_mapTree;
        private System.Windows.Forms.BindingSource bs_mapDetail;
        private System.Windows.Forms.BindingSource bs_mapPOI;
        private System.Windows.Forms.ListBox lboxMapMenu;
        private System.Windows.Forms.TabControl tabMDGboxes;
        private System.Windows.Forms.TabPage tbTerrain;
        private System.Windows.Forms.PictureBox picTerrainTypeGraphic;
        private System.Windows.Forms.Label lblTreeName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tboxBranchValue;
        private System.Windows.Forms.TextBox tboxBranchName;
        private System.Windows.Forms.Label lblTreeID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tboxTerrainTypeValue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tboxTerrainTypeImportName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tboxTerrainTypeResName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tboxTerrainTypeStepCost;
        private System.Windows.Forms.TextBox tboxTerrainTypeHeight;
        private System.Windows.Forms.TextBox tboxTerrainTypeElevation;
    }
}
