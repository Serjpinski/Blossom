namespace Blossom {
    partial class Settings {
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cellSize = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.framerate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.sparsity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sparsity)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(20, 181);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(129, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // cellSize
            // 
            this.cellSize.Location = new System.Drawing.Point(147, 22);
            this.cellSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.cellSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cellSize.Name = "cellSize";
            this.cellSize.Size = new System.Drawing.Size(42, 20);
            this.cellSize.TabIndex = 3;
            this.cellSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cellSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(20, 144);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(184, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://github.com/Serjpinski/Blossom";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Made by Sergio Larrodera. More info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cell size (default 1)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Framerate (default 30)";
            // 
            // framerate
            // 
            this.framerate.Location = new System.Drawing.Point(147, 56);
            this.framerate.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.framerate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.framerate.Name = "framerate";
            this.framerate.Size = new System.Drawing.Size(42, 20);
            this.framerate.TabIndex = 7;
            this.framerate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.framerate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sparsity (default 0.5)";
            // 
            // sparsity
            // 
            this.sparsity.DecimalPlaces = 1;
            this.sparsity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.sparsity.Location = new System.Drawing.Point(147, 90);
            this.sparsity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sparsity.Name = "sparsity";
            this.sparsity.Size = new System.Drawing.Size(42, 20);
            this.sparsity.TabIndex = 9;
            this.sparsity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sparsity.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // Settings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(229, 219);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sparsity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.framerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cellSize);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sparsity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown cellSize;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown framerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sparsity;
    }
}