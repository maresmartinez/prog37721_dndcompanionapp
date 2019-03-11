namespace CharacterCreationForms {
    partial class DnDApplicationForm {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.navigationMenuStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterNavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeAllCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.campaignsNavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeAllCampaignsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCampaignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diceRollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encyclopediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignmentQuizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPageView = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigationMenuStripToolStripMenuItem,
            this.characterNavToolStripMenuItem,
            this.campaignsNavToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(884, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // navigationMenuStripToolStripMenuItem
            // 
            this.navigationMenuStripToolStripMenuItem.Name = "navigationMenuStripToolStripMenuItem";
            this.navigationMenuStripToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.navigationMenuStripToolStripMenuItem.Text = "Home";
            this.navigationMenuStripToolStripMenuItem.Click += new System.EventHandler(this.navigationMenuStripToolStripMenuItem_Click);
            // 
            // characterNavToolStripMenuItem
            // 
            this.characterNavToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seeAllCharactersToolStripMenuItem,
            this.createNewCharacterToolStripMenuItem});
            this.characterNavToolStripMenuItem.Name = "characterNavToolStripMenuItem";
            this.characterNavToolStripMenuItem.Size = new System.Drawing.Size(96, 25);
            this.characterNavToolStripMenuItem.Text = "Characters";
            // 
            // seeAllCharactersToolStripMenuItem
            // 
            this.seeAllCharactersToolStripMenuItem.Name = "seeAllCharactersToolStripMenuItem";
            this.seeAllCharactersToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.seeAllCharactersToolStripMenuItem.Text = "See All Characters";
            this.seeAllCharactersToolStripMenuItem.Click += new System.EventHandler(this.seeAllCharactersToolStripMenuItem_Click);
            // 
            // createNewCharacterToolStripMenuItem
            // 
            this.createNewCharacterToolStripMenuItem.Name = "createNewCharacterToolStripMenuItem";
            this.createNewCharacterToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.createNewCharacterToolStripMenuItem.Text = "Create New Character";
            this.createNewCharacterToolStripMenuItem.Click += new System.EventHandler(this.createNewCharacterToolStripMenuItem_Click);
            // 
            // campaignsNavToolStripMenuItem
            // 
            this.campaignsNavToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seeAllCampaignsToolStripMenuItem,
            this.createNewCampaignToolStripMenuItem});
            this.campaignsNavToolStripMenuItem.Name = "campaignsNavToolStripMenuItem";
            this.campaignsNavToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.campaignsNavToolStripMenuItem.Text = "Campaigns";
            // 
            // seeAllCampaignsToolStripMenuItem
            // 
            this.seeAllCampaignsToolStripMenuItem.Name = "seeAllCampaignsToolStripMenuItem";
            this.seeAllCampaignsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.seeAllCampaignsToolStripMenuItem.Text = "See All Campaigns";
            // 
            // createNewCampaignToolStripMenuItem
            // 
            this.createNewCampaignToolStripMenuItem.Name = "createNewCampaignToolStripMenuItem";
            this.createNewCampaignToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.createNewCampaignToolStripMenuItem.Text = "Create New Campaign";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diceRollToolStripMenuItem,
            this.encyclopediaToolStripMenuItem,
            this.alignmentQuizToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 25);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // diceRollToolStripMenuItem
            // 
            this.diceRollToolStripMenuItem.Name = "diceRollToolStripMenuItem";
            this.diceRollToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.diceRollToolStripMenuItem.Text = "Dice Roll";
            // 
            // encyclopediaToolStripMenuItem
            // 
            this.encyclopediaToolStripMenuItem.Name = "encyclopediaToolStripMenuItem";
            this.encyclopediaToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.encyclopediaToolStripMenuItem.Text = "Encyclopedia";
            // 
            // alignmentQuizToolStripMenuItem
            // 
            this.alignmentQuizToolStripMenuItem.Name = "alignmentQuizToolStripMenuItem";
            this.alignmentQuizToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.alignmentQuizToolStripMenuItem.Text = "Alignment Quiz";
            // 
            // pnlPageView
            // 
            this.pnlPageView.AutoScroll = true;
            this.pnlPageView.AutoSize = true;
            this.pnlPageView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageView.Location = new System.Drawing.Point(0, 35);
            this.pnlPageView.Name = "pnlPageView";
            this.pnlPageView.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlPageView.Size = new System.Drawing.Size(884, 529);
            this.pnlPageView.TabIndex = 1;
            // 
            // DnDApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 564);
            this.Controls.Add(this.pnlPageView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DnDApplicationForm";
            this.Text = "DnDApplicationForm";
            this.Load += new System.EventHandler(this.DnDApplicationForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem navigationMenuStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterNavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeAllCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem campaignsNavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeAllCampaignsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCampaignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diceRollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encyclopediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignmentQuizToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPageView;
    }
}