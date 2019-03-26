namespace EncyclopaediaForms {
    partial class RaceDetailsPage {
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
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.AutoScroll = true;
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 35);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlDetails.Size = new System.Drawing.Size(800, 415);
            this.pnlDetails.TabIndex = 12;
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(800, 2);
            this.lblLine.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 33);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Race Details";
            // 
            // RaceDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "RaceDetailsPage";
            this.Text = "RaceDetailsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
    }
}