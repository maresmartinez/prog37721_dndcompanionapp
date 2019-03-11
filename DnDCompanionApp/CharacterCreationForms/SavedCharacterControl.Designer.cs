namespace CharacterCreationForms {
    partial class SavedCharacterControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavedCharacterControl));
            this.lblName = new System.Windows.Forms.Label();
            this.picCharacter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(86, 265);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Character Name";
            // 
            // picCharacter
            // 
            this.picCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCharacter.Image = ((System.Drawing.Image)(resources.GetObject("picCharacter.Image")));
            this.picCharacter.Location = new System.Drawing.Point(4, 3);
            this.picCharacter.Name = "picCharacter";
            this.picCharacter.Size = new System.Drawing.Size(250, 250);
            this.picCharacter.TabIndex = 2;
            this.picCharacter.TabStop = false;
            this.picCharacter.Click += new System.EventHandler(this.picCharacter_Click);
            // 
            // SavedCharacterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picCharacter);
            this.Controls.Add(this.lblName);
            this.Name = "SavedCharacterControl";
            this.Size = new System.Drawing.Size(257, 295);
            this.Load += new System.EventHandler(this.SavedCharacterControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picCharacter;
    }
}
