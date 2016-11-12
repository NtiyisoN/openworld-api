namespace norwold.forms
{
    partial class frmSelectPlayers
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
            this.chklboxPlayers = new System.Windows.Forms.CheckedListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklboxPlayers
            // 
            this.chklboxPlayers.FormattingEnabled = true;
            this.chklboxPlayers.Location = new System.Drawing.Point(13, 13);
            this.chklboxPlayers.Name = "chklboxPlayers";
            this.chklboxPlayers.Size = new System.Drawing.Size(514, 310);
            this.chklboxPlayers.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(293, 347);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(114, 43);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(413, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 43);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSelectPlayers
            // 
            this.ClientSize = new System.Drawing.Size(548, 414);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.chklboxPlayers);
            this.Name = "frmSelectPlayers";
            this.Load += new System.EventHandler(this.frmSelectPlayers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.CheckedListBox chklboxPlayers;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
    }
}