namespace norwold.forms
{
    partial class frm_nwBase
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
            this.tboxMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tboxMsg
            // 
            this.tboxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tboxMsg.Enabled = false;
            this.tboxMsg.Location = new System.Drawing.Point(0, 233);
            this.tboxMsg.Name = "tboxMsg";
            this.tboxMsg.Size = new System.Drawing.Size(282, 22);
            this.tboxMsg.TabIndex = 0;
            this.tboxMsg.TabStop = false;
            // 
            // frm_nwBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.tboxMsg);
            this.Name = "frm_nwBase";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_nwBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxMsg;
    }
}