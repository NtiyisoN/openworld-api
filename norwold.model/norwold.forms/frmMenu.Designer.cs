namespace norwold.forms
{
    partial class frmMenu
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnCharacters = new System.Windows.Forms.Button();
            this.btnWorldDesigner = new System.Windows.Forms.Button();
            this.btnSystemDesigner = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnCampaign = new System.Windows.Forms.Button();
            this.btnCampDesign = new System.Windows.Forms.Button();
            this.btnDevelopment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(15, 118);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(303, 46);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "&User Management";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnCharacters
            // 
            this.btnCharacters.Location = new System.Drawing.Point(14, 12);
            this.btnCharacters.Name = "btnCharacters";
            this.btnCharacters.Size = new System.Drawing.Size(303, 46);
            this.btnCharacters.TabIndex = 1;
            this.btnCharacters.Text = "Character &Management";
            this.btnCharacters.UseVisualStyleBackColor = true;
            this.btnCharacters.Click += new System.EventHandler(this.btnCharacters_Click);
            // 
            // btnWorldDesigner
            // 
            this.btnWorldDesigner.Location = new System.Drawing.Point(12, 244);
            this.btnWorldDesigner.Name = "btnWorldDesigner";
            this.btnWorldDesigner.Size = new System.Drawing.Size(303, 46);
            this.btnWorldDesigner.TabIndex = 3;
            this.btnWorldDesigner.Text = "&Map Designer";
            this.btnWorldDesigner.UseVisualStyleBackColor = true;
            this.btnWorldDesigner.Click += new System.EventHandler(this.btnWorldDesigner_Click);
            // 
            // btnSystemDesigner
            // 
            this.btnSystemDesigner.Location = new System.Drawing.Point(12, 297);
            this.btnSystemDesigner.Name = "btnSystemDesigner";
            this.btnSystemDesigner.Size = new System.Drawing.Size(303, 46);
            this.btnSystemDesigner.TabIndex = 4;
            this.btnSystemDesigner.Text = "&RuleSet Designer";
            this.btnSystemDesigner.UseVisualStyleBackColor = true;
            this.btnSystemDesigner.Click += new System.EventHandler(this.btnSystemDesigner_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 433);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(303, 46);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnCampaign
            // 
            this.btnCampaign.Location = new System.Drawing.Point(12, 64);
            this.btnCampaign.Name = "btnCampaign";
            this.btnCampaign.Size = new System.Drawing.Size(303, 46);
            this.btnCampaign.TabIndex = 2;
            this.btnCampaign.Text = "&Campaign Management";
            this.btnCampaign.UseVisualStyleBackColor = true;
            this.btnCampaign.Click += new System.EventHandler(this.btnCampaign_Click);
            // 
            // btnCampDesign
            // 
            this.btnCampDesign.Location = new System.Drawing.Point(13, 192);
            this.btnCampDesign.Name = "btnCampDesign";
            this.btnCampDesign.Size = new System.Drawing.Size(303, 46);
            this.btnCampDesign.TabIndex = 6;
            this.btnCampDesign.Text = "Campaign &Designer";
            this.btnCampDesign.UseVisualStyleBackColor = true;
            this.btnCampDesign.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDevelopment
            // 
            this.btnDevelopment.Location = new System.Drawing.Point(12, 487);
            this.btnDevelopment.Name = "btnDevelopment";
            this.btnDevelopment.Size = new System.Drawing.Size(303, 46);
            this.btnDevelopment.TabIndex = 7;
            this.btnDevelopment.Text = "&Development";
            this.btnDevelopment.UseVisualStyleBackColor = true;
            this.btnDevelopment.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 545);
            this.Controls.Add(this.btnDevelopment);
            this.Controls.Add(this.btnCampDesign);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSystemDesigner);
            this.Controls.Add(this.btnWorldDesigner);
            this.Controls.Add(this.btnCampaign);
            this.Controls.Add(this.btnCharacters);
            this.Controls.Add(this.btnUsers);
            this.Name = "frmMenu";
            this.Text = "OpenWorld Main Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnCharacters;
        private System.Windows.Forms.Button btnWorldDesigner;
        private System.Windows.Forms.Button btnSystemDesigner;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnCampaign;
        private System.Windows.Forms.Button btnCampDesign;
        private System.Windows.Forms.Button btnDevelopment;
    }
}