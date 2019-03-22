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
            this.txtCharacterDesc = new System.Windows.Forms.TextBox();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.cbCharacters = new System.Windows.Forms.ComboBox();
            this.txtDungeonMaster = new System.Windows.Forms.TextBox();
            this.lblDungeonMaster = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
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
            this.pnlCharacterPreview.Controls.Add(this.txtCharacterDesc);
            this.pnlCharacterPreview.Controls.Add(this.lblCharacters);
            this.pnlCharacterPreview.Controls.Add(this.cbCharacters);
            this.pnlCharacterPreview.Controls.Add(this.txtDungeonMaster);
            this.pnlCharacterPreview.Controls.Add(this.lblDungeonMaster);
            this.pnlCharacterPreview.Controls.Add(this.txtDescription);
            this.pnlCharacterPreview.Controls.Add(this.lblDescription);
            this.pnlCharacterPreview.Controls.Add(this.txtName);
            this.pnlCharacterPreview.Controls.Add(this.lblName);
            this.pnlCharacterPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterPreview.Location = new System.Drawing.Point(0, 35);
            this.pnlCharacterPreview.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.pnlCharacterPreview.Name = "pnlCharacterPreview";
            this.pnlCharacterPreview.Size = new System.Drawing.Size(609, 356);
            this.pnlCharacterPreview.TabIndex = 77;
            // 
            // txtCharacterDesc
            // 
            this.txtCharacterDesc.Location = new System.Drawing.Point(6, 249);
            this.txtCharacterDesc.Multiline = true;
            this.txtCharacterDesc.Name = "txtCharacterDesc";
            this.txtCharacterDesc.ReadOnly = true;
            this.txtCharacterDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCharacterDesc.Size = new System.Drawing.Size(484, 91);
            this.txtCharacterDesc.TabIndex = 9;
            // 
            // lblCharacters
            // 
            this.lblCharacters.AutoSize = true;
            this.lblCharacters.Location = new System.Drawing.Point(3, 208);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(77, 13);
            this.lblCharacters.TabIndex = 8;
            this.lblCharacters.Text = "Party Members";
            // 
            // cbCharacters
            // 
            this.cbCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharacters.FormattingEnabled = true;
            this.cbCharacters.Location = new System.Drawing.Point(6, 224);
            this.cbCharacters.Name = "cbCharacters";
            this.cbCharacters.Size = new System.Drawing.Size(484, 21);
            this.cbCharacters.TabIndex = 7;
            this.cbCharacters.SelectedIndexChanged += new System.EventHandler(this.cbCharacters_SelectedIndexChanged);
            // 
            // txtDungeonMaster
            // 
            this.txtDungeonMaster.Location = new System.Drawing.Point(6, 176);
            this.txtDungeonMaster.Name = "txtDungeonMaster";
            this.txtDungeonMaster.ReadOnly = true;
            this.txtDungeonMaster.Size = new System.Drawing.Size(484, 20);
            this.txtDungeonMaster.TabIndex = 6;
            // 
            // lblDungeonMaster
            // 
            this.lblDungeonMaster.AutoSize = true;
            this.lblDungeonMaster.Location = new System.Drawing.Point(3, 160);
            this.lblDungeonMaster.Name = "lblDungeonMaster";
            this.lblDungeonMaster.Size = new System.Drawing.Size(86, 13);
            this.lblDungeonMaster.TabIndex = 5;
            this.lblDungeonMaster.Text = "Dungeon Master";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(484, 74);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 59);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(609, 2);
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
            this.ClientSize = new System.Drawing.Size(609, 391);
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
        private System.Windows.Forms.TextBox txtCharacterDesc;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.ComboBox cbCharacters;
        private System.Windows.Forms.TextBox txtDungeonMaster;
        private System.Windows.Forms.Label lblDungeonMaster;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}