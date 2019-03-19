namespace CampaignCreationForms {
    partial class SavedCampaignControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavedCampaignControl));
            this.picCampaign = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCampaign)).BeginInit();
            this.SuspendLayout();
            // 
            // picCampaign
            // 
            this.picCampaign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCampaign.Image = ((System.Drawing.Image)(resources.GetObject("picCampaign.Image")));
            this.picCampaign.Location = new System.Drawing.Point(3, 3);
            this.picCampaign.Name = "picCampaign";
            this.picCampaign.Size = new System.Drawing.Size(300, 250);
            this.picCampaign.TabIndex = 4;
            this.picCampaign.TabStop = false;
            this.picCampaign.Click += new System.EventHandler(this.picCampaign_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(113, 267);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Campaign Name";
            // 
            // SavedCampaignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picCampaign);
            this.Controls.Add(this.lblName);
            this.Name = "SavedCampaignControl";
            this.Size = new System.Drawing.Size(306, 299);
            this.Load += new System.EventHandler(this.SavedCampaignControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCampaign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCampaign;
        private System.Windows.Forms.Label lblName;
    }
}
