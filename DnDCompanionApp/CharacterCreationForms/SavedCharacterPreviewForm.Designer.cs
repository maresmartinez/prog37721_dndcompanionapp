namespace CharacterCreationForms {
    partial class SavedCharacterPreviewForm {
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
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCharacterPreview = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(10, 38);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(780, 2);
            this.lblLine.TabIndex = 73;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(122, 33);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Character";
            // 
            // pnlCharacterPreview
            // 
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(10, 40);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(780, 405);
            this.pnlCharacterPreview.TabIndex = 74;
            // 
            // SavedCharacterPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCharacterPreview);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "SavedCharacterPreviewForm";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "SavedCharacterPreviewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCharacterPreview;
    }
}