namespace CampaignCreationForms {
    partial class SavedCampaignsPage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.flowSavedCampaigns = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowSavedCampaigns
            // 
            this.flowSavedCampaigns.AutoScroll = true;
            this.flowSavedCampaigns.AutoSize = true;
            this.flowSavedCampaigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSavedCampaigns.Location = new System.Drawing.Point(0, 35);
            this.flowSavedCampaigns.Name = "flowSavedCampaigns";
            this.flowSavedCampaigns.Size = new System.Drawing.Size(852, 461);
            this.flowSavedCampaigns.TabIndex = 8;
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(852, 2);
            this.lblLine.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 33);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Saved Campaigns";
            // 
            // SavedCampaignsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowSavedCampaigns);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "SavedCampaignsPage";
            this.Size = new System.Drawing.Size(852, 496);
            this.Load += new System.EventHandler(this.SavedCampaignsPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowSavedCampaigns;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
    }
}
