namespace DiceRollForms {
    partial class DiceRollPage {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiceRollPage));
            this.pnlDiceRollPage = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.numRolls = new System.Windows.Forms.NumericUpDown();
            this.rbD20 = new System.Windows.Forms.RadioButton();
            this.rbD12 = new System.Windows.Forms.RadioButton();
            this.rbD10 = new System.Windows.Forms.RadioButton();
            this.rbD8 = new System.Windows.Forms.RadioButton();
            this.rbD6 = new System.Windows.Forms.RadioButton();
            this.rbD4 = new System.Windows.Forms.RadioButton();
            this.btnRoll = new System.Windows.Forms.Button();
            this.lblNumRolls = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDiceRollPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRolls)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDiceRollPage
            // 
            this.pnlDiceRollPage.AutoScroll = true;
            this.pnlDiceRollPage.Controls.Add(this.lblResult);
            this.pnlDiceRollPage.Controls.Add(this.numRolls);
            this.pnlDiceRollPage.Controls.Add(this.rbD20);
            this.pnlDiceRollPage.Controls.Add(this.rbD12);
            this.pnlDiceRollPage.Controls.Add(this.rbD10);
            this.pnlDiceRollPage.Controls.Add(this.rbD8);
            this.pnlDiceRollPage.Controls.Add(this.rbD6);
            this.pnlDiceRollPage.Controls.Add(this.rbD4);
            this.pnlDiceRollPage.Controls.Add(this.btnRoll);
            this.pnlDiceRollPage.Controls.Add(this.lblNumRolls);
            this.pnlDiceRollPage.Controls.Add(this.lblInstructions);
            this.pnlDiceRollPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiceRollPage.Location = new System.Drawing.Point(0, 35);
            this.pnlDiceRollPage.Name = "pnlDiceRollPage";
            this.pnlDiceRollPage.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlDiceRollPage.Size = new System.Drawing.Size(800, 489);
            this.pnlDiceRollPage.TabIndex = 12;
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(9, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(771, 205);
            this.lblResult.TabIndex = 116;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numRolls
            // 
            this.numRolls.Location = new System.Drawing.Point(9, 390);
            this.numRolls.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRolls.Name = "numRolls";
            this.numRolls.Size = new System.Drawing.Size(771, 20);
            this.numRolls.TabIndex = 115;
            this.numRolls.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numRolls.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbD20
            // 
            this.rbD20.AutoSize = true;
            this.rbD20.Image = ((System.Drawing.Image)(resources.GetObject("rbD20.Image")));
            this.rbD20.Location = new System.Drawing.Point(657, 238);
            this.rbD20.Name = "rbD20";
            this.rbD20.Size = new System.Drawing.Size(124, 127);
            this.rbD20.TabIndex = 113;
            this.rbD20.TabStop = true;
            this.rbD20.Tag = "20";
            this.rbD20.Text = "D20";
            this.rbD20.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD20.UseVisualStyleBackColor = true;
            // 
            // rbD12
            // 
            this.rbD12.AutoSize = true;
            this.rbD12.Image = ((System.Drawing.Image)(resources.GetObject("rbD12.Image")));
            this.rbD12.Location = new System.Drawing.Point(527, 238);
            this.rbD12.Name = "rbD12";
            this.rbD12.Size = new System.Drawing.Size(124, 127);
            this.rbD12.TabIndex = 112;
            this.rbD12.TabStop = true;
            this.rbD12.Tag = "12";
            this.rbD12.Text = "D12";
            this.rbD12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD12.UseVisualStyleBackColor = true;
            // 
            // rbD10
            // 
            this.rbD10.AutoSize = true;
            this.rbD10.Image = ((System.Drawing.Image)(resources.GetObject("rbD10.Image")));
            this.rbD10.Location = new System.Drawing.Point(400, 238);
            this.rbD10.Name = "rbD10";
            this.rbD10.Size = new System.Drawing.Size(124, 127);
            this.rbD10.TabIndex = 110;
            this.rbD10.TabStop = true;
            this.rbD10.Tag = "10";
            this.rbD10.Text = "D10";
            this.rbD10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD10.UseVisualStyleBackColor = true;
            // 
            // rbD8
            // 
            this.rbD8.AutoSize = true;
            this.rbD8.Image = ((System.Drawing.Image)(resources.GetObject("rbD8.Image")));
            this.rbD8.Location = new System.Drawing.Point(270, 238);
            this.rbD8.Name = "rbD8";
            this.rbD8.Size = new System.Drawing.Size(124, 127);
            this.rbD8.TabIndex = 109;
            this.rbD8.TabStop = true;
            this.rbD8.Tag = "8";
            this.rbD8.Text = "D8";
            this.rbD8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD8.UseVisualStyleBackColor = true;
            // 
            // rbD6
            // 
            this.rbD6.AutoSize = true;
            this.rbD6.Image = ((System.Drawing.Image)(resources.GetObject("rbD6.Image")));
            this.rbD6.Location = new System.Drawing.Point(140, 238);
            this.rbD6.Name = "rbD6";
            this.rbD6.Size = new System.Drawing.Size(124, 127);
            this.rbD6.TabIndex = 108;
            this.rbD6.TabStop = true;
            this.rbD6.Tag = "6";
            this.rbD6.Text = "D6";
            this.rbD6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD6.UseVisualStyleBackColor = true;
            // 
            // rbD4
            // 
            this.rbD4.AutoSize = true;
            this.rbD4.Image = ((System.Drawing.Image)(resources.GetObject("rbD4.Image")));
            this.rbD4.Location = new System.Drawing.Point(10, 238);
            this.rbD4.Name = "rbD4";
            this.rbD4.Size = new System.Drawing.Size(124, 127);
            this.rbD4.TabIndex = 107;
            this.rbD4.TabStop = true;
            this.rbD4.Tag = "4";
            this.rbD4.Text = "D4";
            this.rbD4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbD4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.rbD4.UseVisualStyleBackColor = true;
            // 
            // btnRoll
            // 
            this.btnRoll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(74)))), ((int)(((byte)(52)))));
            this.btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoll.ForeColor = System.Drawing.Color.White;
            this.btnRoll.Location = new System.Drawing.Point(10, 416);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(771, 58);
            this.btnRoll.TabIndex = 106;
            this.btnRoll.Text = "ROLL";
            this.btnRoll.UseVisualStyleBackColor = false;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lblNumRolls
            // 
            this.lblNumRolls.AutoSize = true;
            this.lblNumRolls.Location = new System.Drawing.Point(6, 374);
            this.lblNumRolls.Name = "lblNumRolls";
            this.lblNumRolls.Size = new System.Drawing.Size(120, 13);
            this.lblNumRolls.TabIndex = 1;
            this.lblNumRolls.Text = "Number of Times to Roll";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(7, 222);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(101, 13);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Choose Dice to Roll";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Location = new System.Drawing.Point(0, 33);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(800, 2);
            this.lblLine.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 33);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Dice Roll Tool";
            // 
            // DiceRollPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDiceRollPage);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "DiceRollPage";
            this.Size = new System.Drawing.Size(800, 524);
            this.pnlDiceRollPage.ResumeLayout(false);
            this.pnlDiceRollPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRolls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDiceRollPage;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNumRolls;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.RadioButton rbD20;
        private System.Windows.Forms.RadioButton rbD12;
        private System.Windows.Forms.RadioButton rbD10;
        private System.Windows.Forms.RadioButton rbD8;
        private System.Windows.Forms.RadioButton rbD6;
        private System.Windows.Forms.RadioButton rbD4;
        private System.Windows.Forms.NumericUpDown numRolls;
        private System.Windows.Forms.Label lblResult;
    }
}
