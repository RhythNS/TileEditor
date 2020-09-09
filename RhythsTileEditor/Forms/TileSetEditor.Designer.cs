namespace RhyTiles.Forms
{
    partial class TileSetEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.tilesetBasicsGroupBox = new System.Windows.Forms.GroupBox();
            this.sourceFileDialogButton = new System.Windows.Forms.Button();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.tilesetDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tileHeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.tileWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.tileHeightLabel = new System.Windows.Forms.Label();
            this.tileWidthLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.tilesetBasicsGroupBox.SuspendLayout();
            this.tilesetDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(52, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(189, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // tilesetBasicsGroupBox
            // 
            this.tilesetBasicsGroupBox.Controls.Add(this.sourceFileDialogButton);
            this.tilesetBasicsGroupBox.Controls.Add(this.sourceTextBox);
            this.tilesetBasicsGroupBox.Controls.Add(this.sourceLabel);
            this.tilesetBasicsGroupBox.Controls.Add(this.nameTextBox);
            this.tilesetBasicsGroupBox.Controls.Add(this.label1);
            this.tilesetBasicsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.tilesetBasicsGroupBox.Name = "tilesetBasicsGroupBox";
            this.tilesetBasicsGroupBox.Size = new System.Drawing.Size(280, 83);
            this.tilesetBasicsGroupBox.TabIndex = 2;
            this.tilesetBasicsGroupBox.TabStop = false;
            this.tilesetBasicsGroupBox.Text = "Tileset";
            // 
            // sourceFileDialogButton
            // 
            this.sourceFileDialogButton.Location = new System.Drawing.Point(247, 47);
            this.sourceFileDialogButton.Name = "sourceFileDialogButton";
            this.sourceFileDialogButton.Size = new System.Drawing.Size(27, 23);
            this.sourceFileDialogButton.TabIndex = 2;
            this.sourceFileDialogButton.Text = "...";
            this.sourceFileDialogButton.UseVisualStyleBackColor = true;
            this.sourceFileDialogButton.Click += new System.EventHandler(this.SourceFileDialogButton_Click);
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(52, 49);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(189, 20);
            this.sourceTextBox.TabIndex = 1;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(8, 52);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(44, 13);
            this.sourceLabel.TabIndex = 2;
            this.sourceLabel.Text = "Source:";
            // 
            // tilesetDimensionsGroupBox
            // 
            this.tilesetDimensionsGroupBox.Controls.Add(this.tileHeightNumeric);
            this.tilesetDimensionsGroupBox.Controls.Add(this.tileWidthNumeric);
            this.tilesetDimensionsGroupBox.Controls.Add(this.tileHeightLabel);
            this.tilesetDimensionsGroupBox.Controls.Add(this.tileWidthLabel);
            this.tilesetDimensionsGroupBox.Location = new System.Drawing.Point(12, 102);
            this.tilesetDimensionsGroupBox.Name = "tilesetDimensionsGroupBox";
            this.tilesetDimensionsGroupBox.Size = new System.Drawing.Size(280, 87);
            this.tilesetDimensionsGroupBox.TabIndex = 3;
            this.tilesetDimensionsGroupBox.TabStop = false;
            this.tilesetDimensionsGroupBox.Text = "Dimensions";
            // 
            // tileHeightNumeric
            // 
            this.tileHeightNumeric.Location = new System.Drawing.Point(72, 49);
            this.tileHeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tileHeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileHeightNumeric.Name = "tileHeightNumeric";
            this.tileHeightNumeric.Size = new System.Drawing.Size(70, 20);
            this.tileHeightNumeric.TabIndex = 4;
            this.tileHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tileHeightNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // tileWidthNumeric
            // 
            this.tileWidthNumeric.Location = new System.Drawing.Point(72, 23);
            this.tileWidthNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tileWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tileWidthNumeric.Name = "tileWidthNumeric";
            this.tileWidthNumeric.Size = new System.Drawing.Size(70, 20);
            this.tileWidthNumeric.TabIndex = 3;
            this.tileWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tileWidthNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // tileHeightLabel
            // 
            this.tileHeightLabel.AutoSize = true;
            this.tileHeightLabel.Location = new System.Drawing.Point(8, 51);
            this.tileHeightLabel.Name = "tileHeightLabel";
            this.tileHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.tileHeightLabel.TabIndex = 5;
            this.tileHeightLabel.Text = "Tile Height:";
            // 
            // tileWidthLabel
            // 
            this.tileWidthLabel.AutoSize = true;
            this.tileWidthLabel.Location = new System.Drawing.Point(8, 25);
            this.tileWidthLabel.Name = "tileWidthLabel";
            this.tileWidthLabel.Size = new System.Drawing.Size(58, 13);
            this.tileWidthLabel.TabIndex = 4;
            this.tileWidthLabel.Text = "Tile Width:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(217, 195);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(136, 195);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // TileSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 228);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tilesetDimensionsGroupBox);
            this.Controls.Add(this.tilesetBasicsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileSetEditor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TileSetEditor";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TileSetEditor_KeyUp);
            this.tilesetBasicsGroupBox.ResumeLayout(false);
            this.tilesetBasicsGroupBox.PerformLayout();
            this.tilesetDimensionsGroupBox.ResumeLayout(false);
            this.tilesetDimensionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox tilesetBasicsGroupBox;
        private System.Windows.Forms.Button sourceFileDialogButton;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.GroupBox tilesetDimensionsGroupBox;
        private System.Windows.Forms.NumericUpDown tileHeightNumeric;
        private System.Windows.Forms.NumericUpDown tileWidthNumeric;
        private System.Windows.Forms.Label tileHeightLabel;
        private System.Windows.Forms.Label tileWidthLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
    }
}