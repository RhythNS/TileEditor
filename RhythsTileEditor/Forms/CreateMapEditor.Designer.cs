namespace RhythsTileEditor.Forms
{
    partial class CreateMapEditor
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mapBasicsGroupBox = new System.Windows.Forms.GroupBox();
            this.mapDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.widthNumeric = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.tileHeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.tileWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.tileHeightLabel = new System.Windows.Forms.Label();
            this.tileWidthLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mapBasicsGroupBox.SuspendLayout();
            this.mapDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(52, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(189, 20);
            this.nameTextBox.TabIndex = 0;
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
            // mapBasicsGroupBox
            // 
            this.mapBasicsGroupBox.Controls.Add(this.nameTextBox);
            this.mapBasicsGroupBox.Controls.Add(this.label1);
            this.mapBasicsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.mapBasicsGroupBox.Name = "mapBasicsGroupBox";
            this.mapBasicsGroupBox.Size = new System.Drawing.Size(280, 83);
            this.mapBasicsGroupBox.TabIndex = 0;
            this.mapBasicsGroupBox.TabStop = false;
            this.mapBasicsGroupBox.Text = "Map";
            // 
            // mapDimensionsGroupBox
            // 
            this.mapDimensionsGroupBox.Controls.Add(this.heightNumeric);
            this.mapDimensionsGroupBox.Controls.Add(this.widthNumeric);
            this.mapDimensionsGroupBox.Controls.Add(this.heightLabel);
            this.mapDimensionsGroupBox.Controls.Add(this.widthLabel);
            this.mapDimensionsGroupBox.Controls.Add(this.tileHeightNumeric);
            this.mapDimensionsGroupBox.Controls.Add(this.tileWidthNumeric);
            this.mapDimensionsGroupBox.Controls.Add(this.tileHeightLabel);
            this.mapDimensionsGroupBox.Controls.Add(this.tileWidthLabel);
            this.mapDimensionsGroupBox.Location = new System.Drawing.Point(12, 102);
            this.mapDimensionsGroupBox.Name = "mapDimensionsGroupBox";
            this.mapDimensionsGroupBox.Size = new System.Drawing.Size(280, 87);
            this.mapDimensionsGroupBox.TabIndex = 1;
            this.mapDimensionsGroupBox.TabStop = false;
            this.mapDimensionsGroupBox.Text = "Dimensions";
            // 
            // heightNumeric
            // 
            this.heightNumeric.Location = new System.Drawing.Point(52, 51);
            this.heightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(70, 20);
            this.heightNumeric.TabIndex = 2;
            this.heightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heightNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // widthNumeric
            // 
            this.widthNumeric.Location = new System.Drawing.Point(52, 25);
            this.widthNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(70, 20);
            this.widthNumeric.TabIndex = 1;
            this.widthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.widthNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(8, 53);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 9;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(8, 27);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(38, 13);
            this.widthLabel.TabIndex = 8;
            this.widthLabel.Text = "Width:";
            // 
            // tileHeightNumeric
            // 
            this.tileHeightNumeric.Location = new System.Drawing.Point(195, 51);
            this.tileHeightNumeric.Maximum = new decimal(new int[] {
            10000,
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
            this.tileWidthNumeric.Location = new System.Drawing.Point(195, 25);
            this.tileWidthNumeric.Maximum = new decimal(new int[] {
            10000,
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
            this.tileHeightLabel.Location = new System.Drawing.Point(132, 53);
            this.tileHeightLabel.Name = "tileHeightLabel";
            this.tileHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.tileHeightLabel.TabIndex = 5;
            this.tileHeightLabel.Text = "Tile Height:";
            // 
            // tileWidthLabel
            // 
            this.tileWidthLabel.AutoSize = true;
            this.tileWidthLabel.Location = new System.Drawing.Point(132, 27);
            this.tileWidthLabel.Name = "tileWidthLabel";
            this.tileWidthLabel.Size = new System.Drawing.Size(58, 13);
            this.tileWidthLabel.TabIndex = 4;
            this.tileWidthLabel.Text = "Tile Width:";
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
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(217, 195);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 500;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Controls.Add(this.mapBasicsGroupBox);
            this.Controls.Add(this.mapDimensionsGroupBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMapEditor";
            this.Text = "Create new map";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CreateMapEditor_KeyUp);
            this.mapBasicsGroupBox.ResumeLayout(false);
            this.mapBasicsGroupBox.PerformLayout();
            this.mapDimensionsGroupBox.ResumeLayout(false);
            this.mapDimensionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mapBasicsGroupBox;
        private System.Windows.Forms.GroupBox mapDimensionsGroupBox;
        private System.Windows.Forms.NumericUpDown tileHeightNumeric;
        private System.Windows.Forms.NumericUpDown tileWidthNumeric;
        private System.Windows.Forms.Label tileHeightLabel;
        private System.Windows.Forms.Label tileWidthLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown heightNumeric;
        private System.Windows.Forms.NumericUpDown widthNumeric;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
    }
}