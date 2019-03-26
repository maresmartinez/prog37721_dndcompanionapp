namespace EncyclopaediaForms {
    partial class BackgroundTeaser {
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSeeMore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDescription.Location = new System.Drawing.Point(0, 17);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(105, 0, 0, 0);
            this.lblDescription.Size = new System.Drawing.Size(140, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "label1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(105, 0, 0, 0);
            this.lblName.Size = new System.Drawing.Size(154, 17);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // btnSeeMore
            // 
            this.btnSeeMore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSeeMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnSeeMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeMore.ForeColor = System.Drawing.Color.White;
            this.btnSeeMore.Location = new System.Drawing.Point(3, 3);
            this.btnSeeMore.Name = "btnSeeMore";
            this.btnSeeMore.Size = new System.Drawing.Size(96, 35);
            this.btnSeeMore.TabIndex = 126;
            this.btnSeeMore.Text = "See More";
            this.btnSeeMore.UseVisualStyleBackColor = false;
            this.btnSeeMore.Click += new System.EventHandler(this.btnSeeMore_Click);
            // 
            // BackgroundTeaser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSeeMore);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F);
            this.Name = "BackgroundTeaser";
            this.Size = new System.Drawing.Size(580, 40);
            this.Load += new System.EventHandler(this.BackgroundTeaser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSeeMore;
    }
}
