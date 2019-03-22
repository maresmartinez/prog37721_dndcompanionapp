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
            this.txtCharacterDesc = new System.Windows.Forms.TextBox();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.cbCharacters = new System.Windows.Forms.ComboBox();
            this.txtDungeonMaster = new System.Windows.Forms.TextBox();
            this.lblDungeonMaster = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
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
            this.btnSave.Location = new System.Drawing.Point(6, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 50);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save Campaign";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDiscard
            // 
            this.btnDiscard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDiscard.Location = new System.Drawing.Point(165, 12);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 37);
            this.btnDiscard.TabIndex = 73;
            this.btnDiscard.Text = "Edit";
            this.btnDiscard.UseVisualStyleBackColor = true;
            // 
            // pnlCharacterPreview
            // 
            this.pnlCharacterPreview.AutoScroll = true;
            this.pnlCharacterPreview.Controls.Add(this.txtCharacterDesc);
            this.pnlCharacterPreview.Controls.Add(this.lblCharacters);
            this.pnlCharacterPreview.Controls.Add(this.cbCharacters);
            this.pnlCharacterPreview.Controls.Add(this.txtDungeonMaster);
            this.pnlCharacterPreview.Controls.Add(this.lblDungeonMaster);
            this.pnlCharacterPreview.Controls.Add(this.txtDescription);
            this.pnlCharacterPreview.Controls.Add(this.lblDescription);
            this.pnlCharacterPreview.Controls.Add(this.txtName);
            this.pnlCharacterPreview.Controls.Add(this.lblName);
            this.pnlCharacterPreview.Controls.Add(this.pnlSaveOrCancel);
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(0, 35);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(609, 408);
            this.pnlCharacterPreview.TabIndex = 49;
            // 
            // txtCharacterDesc
            // 
            this.txtCharacterDesc.Location = new System.Drawing.Point(12, 247);
            this.txtCharacterDesc.Multiline = true;
            this.txtCharacterDesc.Name = "txtCharacterDesc";
            this.txtCharacterDesc.ReadOnly = true;
            this.txtCharacterDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCharacterDesc.Size = new System.Drawing.Size(484, 91);
            this.txtCharacterDesc.TabIndex = 18;
            // 
            // lblCharacters
            // 
            this.lblCharacters.AutoSize = true;
            this.lblCharacters.Location = new System.Drawing.Point(9, 206);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(77, 13);
            this.lblCharacters.TabIndex = 17;
            this.lblCharacters.Text = "Party Members";
            // 
            // cbCharacters
            // 
            this.cbCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharacters.FormattingEnabled = true;
            this.cbCharacters.Location = new System.Drawing.Point(12, 222);
            this.cbCharacters.Name = "cbCharacters";
            this.cbCharacters.Size = new System.Drawing.Size(484, 21);
            this.cbCharacters.TabIndex = 16;
            this.cbCharacters.SelectedIndexChanged += new System.EventHandler(this.cbCharacters_SelectedIndexChanged);
            // 
            // txtDungeonMaster
            // 
            this.txtDungeonMaster.Location = new System.Drawing.Point(12, 174);
            this.txtDungeonMaster.Name = "txtDungeonMaster";
            this.txtDungeonMaster.ReadOnly = true;
            this.txtDungeonMaster.Size = new System.Drawing.Size(484, 20);
            this.txtDungeonMaster.TabIndex = 15;
            // 
            // lblDungeonMaster
            // 
            this.lblDungeonMaster.AutoSize = true;
            this.lblDungeonMaster.Location = new System.Drawing.Point(9, 158);
            this.lblDungeonMaster.Name = "lblDungeonMaster";
            this.lblDungeonMaster.Size = new System.Drawing.Size(86, 13);
            this.lblDungeonMaster.TabIndex = 14;
            this.lblDungeonMaster.Text = "Dungeon Master";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 73);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(484, 74);
            this.txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 57);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 24);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(193, 20);
            this.txtName.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            // 
            // pnlSaveOrCancel
            // 
            this.pnlSaveOrCancel.Controls.Add(this.btnDiscard);
            this.pnlSaveOrCancel.Controls.Add(this.btnSave);
            this.pnlSaveOrCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSaveOrCancel.Location = new System.Drawing.Point(0, 348);
            this.pnlSaveOrCancel.Name = "pnlSaveOrCancel";
            this.pnlSaveOrCancel.Size = new System.Drawing.Size(609, 60);
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
            this.lblLine.Size = new System.Drawing.Size(609, 2);
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
            this.ClientSize = new System.Drawing.Size(609, 443);
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
        private System.Windows.Forms.Panel pnlSaveOrCancel;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCharacterDesc;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.ComboBox cbCharacters;
        private System.Windows.Forms.TextBox txtDungeonMaster;
        private System.Windows.Forms.Label lblDungeonMaster;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}