namespace CharacterCreationForms {
    partial class CharacterPreviewForm {
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
            this.pnlSaveOrCancel = new System.Windows.Forms.Panel();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlCharacterPreview.SuspendLayout();
            this.pnlSaveOrCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(10, 38);
            this.lblLine.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblLine.Size = new System.Drawing.Size(756, 2);
            this.lblLine.TabIndex = 45;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(122, 33);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "Character";
            // 
            // pnlCharacterPreview
            // 
            this.pnlCharacterPreview.AutoScroll = true;
            this.pnlCharacterPreview.Controls.Add(this.pnlSaveOrCancel);
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(10, 40);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(756, 405);
            this.pnlCharacterPreview.TabIndex = 46;
            // 
            // pnlSaveOrCancel
            // 
            this.pnlSaveOrCancel.Controls.Add(this.btnDiscard);
            this.pnlSaveOrCancel.Controls.Add(this.btnSave);
            this.pnlSaveOrCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSaveOrCancel.Location = new System.Drawing.Point(0, 350);
            this.pnlSaveOrCancel.Name = "pnlSaveOrCancel";
            this.pnlSaveOrCancel.Size = new System.Drawing.Size(756, 55);
            this.pnlSaveOrCancel.TabIndex = 0;
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(162, 10);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 37);
            this.btnDiscard.TabIndex = 73;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 50);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save Character";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // CharacterPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.pnlCharacterPreview);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "CharacterPreviewForm";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Text = "CharacterPreviewForm";
            this.Load += new System.EventHandler(this.CharacterPreviewForm_Load);
            this.pnlCharacterPreview.ResumeLayout(false);
            this.pnlSaveOrCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCharacterPreview;
        private System.Windows.Forms.Panel pnlSaveOrCancel;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnSave;
    }
}