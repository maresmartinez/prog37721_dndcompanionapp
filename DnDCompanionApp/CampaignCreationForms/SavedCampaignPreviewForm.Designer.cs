namespace CampaignCreationForms {
    partial class SavedCampaignPreviewForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlCharacterPreview = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCharacterPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 26);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(193, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // pnlCharacterPreview
            // 
            this.pnlCharacterPreview.AutoScroll = true;
            this.pnlCharacterPreview.Controls.Add(this.txtName);
            this.pnlCharacterPreview.Controls.Add(this.lblName);
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(0, 35);
            this.pnlCharacterPreview.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(800, 415);
            this.pnlCharacterPreview.TabIndex = 77;
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(800, 2);
            this.lblLine.TabIndex = 76;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 33);
            this.lblTitle.TabIndex = 75;
            this.lblTitle.Text = "Campaign Details";
            // 
            // SavedCampaignPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCharacterPreview);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "SavedCampaignPreviewForm";
            this.Text = "SavedCampaignPreviewForm";
            this.Load += new System.EventHandler(this.SavedCampaignPreviewForm_Load);
            this.pnlCharacterPreview.ResumeLayout(false);
            this.pnlCharacterPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlCharacterPreview;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
    }
}