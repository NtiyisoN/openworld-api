namespace norwold.forms
{
    partial class frmReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bsrep_nwAdventure = new System.Windows.Forms.BindingSource(this.components);
            this.bsrep_nwXPGained = new System.Windows.Forms.BindingSource(this.components);
            this.bsrep_Campaign = new System.Windows.Forms.BindingSource(this.components);
            this.bsrep_nwChar = new System.Windows.Forms.BindingSource(this.components);
            this.bs_nwAdventure = new System.Windows.Forms.BindingSource(this.components);
            this.gboxReportSelect = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.lboxSelections = new System.Windows.Forms.ListBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblReportTypes = new System.Windows.Forms.Label();
            this.lboxReports = new System.Windows.Forms.ListBox();
            this.bsrep_ = new System.Windows.Forms.BindingSource(this.components);
            this.rptViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.nwAdventureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hostCampaignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwAdventure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwXPGained)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_Campaign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwAdventure)).BeginInit();
            this.gboxReportSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwAdventureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostCampaignBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bsrep_nwAdventure
            // 
            this.bsrep_nwAdventure.DataSource = typeof(DataModel.libCampaign.campAdventure);
            this.bsrep_nwAdventure.CurrentChanged += new System.EventHandler(this.bs_nwAdventure_CurrentChanged);
            // 
            // bsrep_nwXPGained
            // 
            this.bsrep_nwXPGained.DataSource = typeof(DataModel.libCampaign.campXPGained);
            this.bsrep_nwXPGained.CurrentChanged += new System.EventHandler(this.bsrep_nwXPGained_CurrentChanged);
            // 
            // bsrep_Campaign
            // 
            this.bsrep_Campaign.DataSource = typeof(DataModel.libCampaign.campCampaign);
            // 
            // bsrep_nwChar
            // 
            this.bsrep_nwChar.DataSource = typeof(DataModel.libHosting.hostChar);
            this.bsrep_nwChar.CurrentChanged += new System.EventHandler(this.bsrep_nwChar_CurrentChanged);
            // 
            // bs_nwAdventure
            // 
            this.bs_nwAdventure.DataSource = typeof(DataModel.libCampaign.campAdventure);
            this.bs_nwAdventure.CurrentChanged += new System.EventHandler(this.bs_nwAdventure_CurrentChanged_1);
            // 
            // gboxReportSelect
            // 
            this.gboxReportSelect.Controls.Add(this.btnQuit);
            this.gboxReportSelect.Controls.Add(this.btnLoadReport);
            this.gboxReportSelect.Controls.Add(this.lboxSelections);
            this.gboxReportSelect.Controls.Add(this.lblSelected);
            this.gboxReportSelect.Controls.Add(this.lblReportTypes);
            this.gboxReportSelect.Controls.Add(this.lboxReports);
            this.gboxReportSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.gboxReportSelect.Location = new System.Drawing.Point(900, 0);
            this.gboxReportSelect.Name = "gboxReportSelect";
            this.gboxReportSelect.Size = new System.Drawing.Size(301, 509);
            this.gboxReportSelect.TabIndex = 6;
            this.gboxReportSelect.TabStop = false;
            this.gboxReportSelect.Text = "Report Selection";
            this.gboxReportSelect.Enter += new System.EventHandler(this.gboxReportSelect_Enter);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(25, 455);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(270, 48);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(25, 383);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(270, 48);
            this.btnLoadReport.TabIndex = 10;
            this.btnLoadReport.Text = "&Load Report";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // lboxSelections
            // 
            this.lboxSelections.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lboxSelections.DataSource = this.bs_nwAdventure;
            this.lboxSelections.FormattingEnabled = true;
            this.lboxSelections.ItemHeight = 16;
            this.lboxSelections.Location = new System.Drawing.Point(25, 244);
            this.lboxSelections.Name = "lboxSelections";
            this.lboxSelections.Size = new System.Drawing.Size(270, 132);
            this.lboxSelections.TabIndex = 9;
            this.lboxSelections.SelectedIndexChanged += new System.EventHandler(this.lboxSelections_SelectedIndexChanged);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(25, 224);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(97, 17);
            this.lblSelected.TabIndex = 8;
            this.lblSelected.Text = "Selected Data";
            // 
            // lblReportTypes
            // 
            this.lblReportTypes.AutoSize = true;
            this.lblReportTypes.Location = new System.Drawing.Point(25, 22);
            this.lblReportTypes.Name = "lblReportTypes";
            this.lblReportTypes.Size = new System.Drawing.Size(94, 17);
            this.lblReportTypes.TabIndex = 7;
            this.lblReportTypes.Text = "Report Types";
            // 
            // lboxReports
            // 
            this.lboxReports.FormattingEnabled = true;
            this.lboxReports.ItemHeight = 16;
            this.lboxReports.Items.AddRange(new object[] {
            "Adventure Summary"});
            this.lboxReports.Location = new System.Drawing.Point(25, 45);
            this.lboxReports.Name = "lboxReports";
            this.lboxReports.Size = new System.Drawing.Size(270, 164);
            this.lboxReports.TabIndex = 6;
            // 
            // rptViewer1
            // 
            this.rptViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ds_Adventure";
            reportDataSource1.Value = this.bsrep_nwAdventure;
            reportDataSource2.Name = "ds_AdventureRewards";
            reportDataSource2.Value = this.bsrep_nwXPGained;
            reportDataSource3.Name = "ds_Campaign";
            reportDataSource3.Value = this.bsrep_Campaign;
            reportDataSource4.Name = "ds_char";
            reportDataSource4.Value = this.bsrep_nwChar;
            reportDataSource5.Name = "SQLconn_nwRun";
            reportDataSource5.Value = this.nwAdventureBindingSource;
            this.rptViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.rptViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.rptViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.rptViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.rptViewer1.LocalReport.ReportEmbeddedResource = "norwold.forms.printing.Adventure Summary.rdlc";
            this.rptViewer1.Location = new System.Drawing.Point(0, 0);
            this.rptViewer1.Name = "rptViewer1";
            this.rptViewer1.Size = new System.Drawing.Size(900, 509);
            this.rptViewer1.TabIndex = 7;
            this.rptViewer1.Load += new System.EventHandler(this.rptViewer1_Load);
            // 
            // nwAdventureBindingSource
            // 
            this.nwAdventureBindingSource.DataSource = this.hostCampaignBindingSource;
            this.nwAdventureBindingSource.CurrentChanged += new System.EventHandler(this.nwAdventureBindingSource_CurrentChanged);
            // 
            // hostCampaignBindingSource
            // 
            this.hostCampaignBindingSource.DataSource = typeof(DataModel.libCampaign.campCampaign);
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1201, 509);
            this.Controls.Add(this.rptViewer1);
            this.Controls.Add(this.gboxReportSelect);
            this.Name = "frmReportViewer";
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwAdventure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwXPGained)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_Campaign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_nwChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_nwAdventure)).EndInit();
            this.gboxReportSelect.ResumeLayout(false);
            this.gboxReportSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsrep_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nwAdventureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostCampaignBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsrep_nwAdventure;
        private System.Windows.Forms.BindingSource bsrep_nwXPGained;
        private System.Windows.Forms.GroupBox gboxReportSelect;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.ListBox lboxSelections;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblReportTypes;
        private System.Windows.Forms.ListBox lboxReports;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.BindingSource bsrep_nwChar;
        private System.Windows.Forms.BindingSource bs_nwAdventure;
        private System.Windows.Forms.BindingSource bsrep_Campaign;
        private System.Windows.Forms.BindingSource bsrep_;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer1;
        private System.Windows.Forms.BindingSource nwAdventureBindingSource;
        private System.Windows.Forms.BindingSource hostCampaignBindingSource;
    }
}
