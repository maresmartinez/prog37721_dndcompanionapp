namespace CampaignCreationForms {
    partial class CampaignCreationPage {
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
            this.pnlAppDescription = new System.Windows.Forms.Panel();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnAddPartyMember = new System.Windows.Forms.Button();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbCharacters = new System.Windows.Forms.ComboBox();
            this.lstSelectedCharacters = new System.Windows.Forms.ListBox();
            this.lblPartyMembers = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.lblDungeonMaster = new System.Windows.Forms.Label();
            this.cbDungeonMaster = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlAppDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAppDescription
            // 
            this.pnlAppDescription.AutoScroll = true;
            this.pnlAppDescription.Controls.Add(this.lblInstructions);
            this.pnlAppDescription.Controls.Add(this.btnAddPartyMember);
            this.pnlAppDescription.Controls.Add(this.lblCharacter);
            this.pnlAppDescription.Controls.Add(this.lblUser);
            this.pnlAppDescription.Controls.Add(this.cbCharacters);
            this.pnlAppDescription.Controls.Add(this.lstSelectedCharacters);
            this.pnlAppDescription.Controls.Add(this.lblPartyMembers);
            this.pnlAppDescription.Controls.Add(this.cbUsers);
            this.pnlAppDescription.Controls.Add(this.lblDungeonMaster);
            this.pnlAppDescription.Controls.Add(this.cbDungeonMaster);
            this.pnlAppDescription.Controls.Add(this.txtDescription);
            this.pnlAppDescription.Controls.Add(this.lblDescription);
            this.pnlAppDescription.Controls.Add(this.btnGenerate);
            this.pnlAppDescription.Controls.Add(this.txtName);
            this.pnlAppDescription.Controls.Add(this.lblName);
            this.pnlAppDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAppDescription.Location = new System.Drawing.Point(0, 35);
            this.pnlAppDescription.Name = "pnlAppDescription";
            this.pnlAppDescription.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlAppDescription.Size = new System.Drawing.Size(767, 526);
            this.pnlAppDescription.TabIndex = 6;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(5, 204);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(391, 33);
            this.lblInstructions.TabIndex = 106;
            this.lblInstructions.Text = "Add party members by selecting a User, and choosing which of their characters to " +
    "add. The characters you have added will appear in the list below.";
            // 
            // btnAddPartyMember
            // 
            this.btnAddPartyMember.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddPartyMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnAddPartyMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPartyMember.ForeColor = System.Drawing.Color.White;
            this.btnAddPartyMember.Location = new System.Drawing.Point(254, 296);
            this.btnAddPartyMember.Name = "btnAddPartyMember";
            this.btnAddPartyMember.Size = new System.Drawing.Size(142, 29);
            this.btnAddPartyMember.TabIndex = 105;
            this.btnAddPartyMember.Text = "Add Character";
            this.btnAddPartyMember.UseVisualStyleBackColor = false;
            this.btnAddPartyMember.Click += new System.EventHandler(this.btnAddPartyMember_Click);
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.Location = new System.Drawing.Point(5, 285);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(53, 13);
            this.lblCharacter.TabIndex = 104;
            this.lblCharacter.Text = "Character";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(5, 239);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 103;
            this.lblUser.Text = "User";
            // 
            // cbCharacters
            // 
            this.cbCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharacters.FormattingEnabled = true;
            this.cbCharacters.Location = new System.Drawing.Point(8, 301);
            this.cbCharacters.Name = "cbCharacters";
            this.cbCharacters.Size = new System.Drawing.Size(240, 21);
            this.cbCharacters.TabIndex = 102;
            // 
            // lstSelectedCharacters
            // 
            this.lstSelectedCharacters.FormattingEnabled = true;
            this.lstSelectedCharacters.Location = new System.Drawing.Point(8, 352);
            this.lstSelectedCharacters.Name = "lstSelectedCharacters";
            this.lstSelectedCharacters.Size = new System.Drawing.Size(388, 95);
            this.lstSelectedCharacters.TabIndex = 101;
            // 
            // lblPartyMembers
            // 
            this.lblPartyMembers.AutoSize = true;
            this.lblPartyMembers.Location = new System.Drawing.Point(5, 336);
            this.lblPartyMembers.Name = "lblPartyMembers";
            this.lblPartyMembers.Size = new System.Drawing.Size(80, 13);
            this.lblPartyMembers.TabIndex = 100;
            this.lblPartyMembers.Text = "Party Members ";
            // 
            // cbUsers
            // 
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(8, 255);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(111, 21);
            this.cbUsers.TabIndex = 99;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // lblDungeonMaster
            // 
            this.lblDungeonMaster.AutoSize = true;
            this.lblDungeonMaster.Location = new System.Drawing.Point(5, 152);
            this.lblDungeonMaster.Name = "lblDungeonMaster";
            this.lblDungeonMaster.Size = new System.Drawing.Size(86, 13);
            this.lblDungeonMaster.TabIndex = 98;
            this.lblDungeonMaster.Text = "Dungeon Master";
            // 
            // cbDungeonMaster
            // 
            this.cbDungeonMaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDungeonMaster.FormattingEnabled = true;
            this.cbDungeonMaster.Location = new System.Drawing.Point(8, 168);
            this.cbDungeonMaster.Name = "cbDungeonMaster";
            this.cbDungeonMaster.Size = new System.Drawing.Size(388, 21);
            this.cbDungeonMaster.TabIndex = 97;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(8, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(388, 74);
            this.txtDescription.TabIndex = 96;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(5, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 95;
            this.lblDescription.Text = "Description";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(6, 463);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(153, 50);
            this.btnGenerate.TabIndex = 94;
            this.btnGenerate.Text = "Generate Campaign";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 20);
            this.txtName.TabIndex = 72;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 71;
            this.lblName.Text = "Name";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(767, 2);
            this.lblLine.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 33);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Campaign Creation";
            // 
            // CampaignCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAppDescription);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "CampaignCreationPage";
            this.Size = new System.Drawing.Size(767, 561);
            this.Load += new System.EventHandler(this.CampaignCreationPage_Load);
            this.pnlAppDescription.ResumeLayout(false);
            this.pnlAppDescription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAppDescription;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnAddPartyMember;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbCharacters;
        private System.Windows.Forms.ListBox lstSelectedCharacters;
        private System.Windows.Forms.Label lblPartyMembers;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label lblDungeonMaster;
        private System.Windows.Forms.ComboBox cbDungeonMaster;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
    }
}
