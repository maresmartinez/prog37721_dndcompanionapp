namespace MainNavigationForms {
    partial class HomePage {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.pnlAppDescription = new System.Windows.Forms.Panel();
            this.txtAppDescription = new System.Windows.Forms.TextBox();
            this.pnlAppDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(432, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome to the DnD Companion App";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(760, 2);
            this.lblLine.TabIndex = 2;
            // 
            // pnlAppDescription
            // 
            this.pnlAppDescription.AutoScroll = true;
            this.pnlAppDescription.Controls.Add(this.txtAppDescription);
            this.pnlAppDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAppDescription.Location = new System.Drawing.Point(0, 35);
            this.pnlAppDescription.Name = "pnlAppDescription";
            this.pnlAppDescription.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlAppDescription.Size = new System.Drawing.Size(760, 465);
            this.pnlAppDescription.TabIndex = 3;
            // 
            // txtAppDescription
            // 
            this.txtAppDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAppDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAppDescription.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppDescription.Location = new System.Drawing.Point(5, 10);
            this.txtAppDescription.Margin = new System.Windows.Forms.Padding(10);
            this.txtAppDescription.Multiline = true;
            this.txtAppDescription.Name = "txtAppDescription";
            this.txtAppDescription.ReadOnly = true;
            this.txtAppDescription.Size = new System.Drawing.Size(750, 445);
            this.txtAppDescription.TabIndex = 4;
            this.txtAppDescription.TabStop = false;
            this.txtAppDescription.Text = resources.GetString("txtAppDescription.Text");
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlAppDescription);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(760, 500);
            this.pnlAppDescription.ResumeLayout(false);
            this.pnlAppDescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Panel pnlAppDescription;
        private System.Windows.Forms.TextBox txtAppDescription;
    }
}
