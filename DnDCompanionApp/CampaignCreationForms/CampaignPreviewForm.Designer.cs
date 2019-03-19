namespace CampaignCreationForms {
    partial class CampaignPreviewForm {
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.pnlCharacterPreview = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlSaveOrCancel = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCharacterPreview.SuspendLayout();
            this.pnlSaveOrCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(6, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 50);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save Campaign";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDiscard
            // 
            this.btnDiscard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDiscard.Location = new System.Drawing.Point(165, 28);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 37);
            this.btnDiscard.TabIndex = 73;
            this.btnDiscard.Text = "Edit";
            this.btnDiscard.UseVisualStyleBackColor = true;
            // 
            // pnlCharacterPreview
            // 
            this.pnlCharacterPreview.AutoScroll = true;
            this.pnlCharacterPreview.Controls.Add(this.txtName);
            this.pnlCharacterPreview.Controls.Add(this.lblName);
            this.pnlCharacterPreview.Controls.Add(this.pnlSaveOrCancel);
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(0, 35);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(800, 415);
            this.pnlCharacterPreview.TabIndex = 49;
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
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // pnlSaveOrCancel
            // 
            this.pnlSaveOrCancel.Controls.Add(this.btnDiscard);
            this.pnlSaveOrCancel.Controls.Add(this.btnSave);
            this.pnlSaveOrCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSaveOrCancel.Location = new System.Drawing.Point(0, 341);
            this.pnlSaveOrCancel.Name = "pnlSaveOrCancel";
            this.pnlSaveOrCancel.Size = new System.Drawing.Size(800, 74);
            this.pnlSaveOrCancel.TabIndex = 0;
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblLine.Size = new System.Drawing.Size(800, 2);
            this.lblLine.TabIndex = 48;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 33);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "Character Preview";
            // 
            // CampaignPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCharacterPreview);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "CampaignPreviewForm";
            this.Text = "CampaignPreviewForm";
            this.Load += new System.EventHandler(this.CampaignPreviewForm_Load);
            this.pnlCharacterPreview.ResumeLayout(false);
            this.pnlCharacterPreview.PerformLayout();
            this.pnlSaveOrCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Panel pnlCharacterPreview;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlSaveOrCancel;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
    }
}