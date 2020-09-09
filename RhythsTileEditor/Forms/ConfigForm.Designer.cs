namespace RhythsTileEditor.Forms
{
    partial class ConfigForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.clearRecentFilesButton = new System.Windows.Forms.Button();
            this.tilesetDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tilesetHeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.tilesetWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mapHeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.mapWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.mapTileHeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.mapTileWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.tileHeightLabel = new System.Windows.Forms.Label();
            this.tileWidthLabel = new System.Windows.Forms.Label();
            this.numberOfRecentFilesNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.baseLayerColorButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.highlightColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tilesetDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWidthNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTileHeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTileWidthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRecentFilesNumeric)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(296, 283);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.clearRecentFilesButton);
            this.tabPage1.Controls.Add(this.tilesetDimensionsGroupBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.numberOfRecentFilesNumeric);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(288, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Clear recent files";
            // 
            // clearRecentFilesButton
            // 
            this.clearRecentFilesButton.Location = new System.Drawing.Point(6, 41);
            this.clearRecentFilesButton.Name = "clearRecentFilesButton";
            this.clearRecentFilesButton.Size = new System.Drawing.Size(46, 23);
            this.clearRecentFilesButton.TabIndex = 5;
            this.clearRecentFilesButton.Text = "Clear";
            this.clearRecentFilesButton.UseVisualStyleBackColor = true;
            this.clearRecentFilesButton.Click += new System.EventHandler(this.ClearRecentFilesButton_Click);
            // 
            // tilesetDimensionsGroupBox
            // 
            this.tilesetDimensionsGroupBox.Controls.Add(this.tilesetHeightNumeric);
            this.tilesetDimensionsGroupBox.Controls.Add(this.tilesetWidthNumeric);
            this.tilesetDimensionsGroupBox.Controls.Add(this.label2);
            this.tilesetDimensionsGroupBox.Controls.Add(this.label3);
            this.tilesetDimensionsGroupBox.Location = new System.Drawing.Point(6, 165);
            this.tilesetDimensionsGroupBox.Name = "tilesetDimensionsGroupBox";
            this.tilesetDimensionsGroupBox.Size = new System.Drawing.Size(278, 87);
            this.tilesetDimensionsGroupBox.TabIndex = 4;
            this.tilesetDimensionsGroupBox.TabStop = false;
            this.tilesetDimensionsGroupBox.Text = "Default Tileset Size";
            // 
            // tilesetHeightNumeric
            // 
            this.tilesetHeightNumeric.Location = new System.Drawing.Point(72, 49);
            this.tilesetHeightNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.tilesetHeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tilesetHeightNumeric.Name = "tilesetHeightNumeric";
            this.tilesetHeightNumeric.Size = new System.Drawing.Size(70, 20);
            this.tilesetHeightNumeric.TabIndex = 5;
            this.tilesetHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tilesetHeightNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tilesetHeightNumeric.ValueChanged += new System.EventHandler(this.TilesetHeightNumeric_ValueChanged);
            // 
            // tilesetWidthNumeric
            // 
            this.tilesetWidthNumeric.Location = new System.Drawing.Point(72, 23);
            this.tilesetWidthNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.tilesetWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tilesetWidthNumeric.Name = "tilesetWidthNumeric";
            this.tilesetWidthNumeric.Size = new System.Drawing.Size(70, 20);
            this.tilesetWidthNumeric.TabIndex = 4;
            this.tilesetWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tilesetWidthNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.tilesetWidthNumeric.ValueChanged += new System.EventHandler(this.TilesetWidthNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tile Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tile Width:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mapHeightNumeric);
            this.groupBox1.Controls.Add(this.mapWidthNumeric);
            this.groupBox1.Controls.Add(this.heightLabel);
            this.groupBox1.Controls.Add(this.widthLabel);
            this.groupBox1.Controls.Add(this.mapTileHeightNumeric);
            this.groupBox1.Controls.Add(this.mapTileWidthNumeric);
            this.groupBox1.Controls.Add(this.tileHeightLabel);
            this.groupBox1.Controls.Add(this.tileWidthLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Map Size";
            // 
            // mapHeightNumeric
            // 
            this.mapHeightNumeric.Location = new System.Drawing.Point(52, 49);
            this.mapHeightNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mapHeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapHeightNumeric.Name = "mapHeightNumeric";
            this.mapHeightNumeric.Size = new System.Drawing.Size(70, 20);
            this.mapHeightNumeric.TabIndex = 11;
            this.mapHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mapHeightNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.mapHeightNumeric.ValueChanged += new System.EventHandler(this.MapHeightNumeric_ValueChanged);
            // 
            // mapWidthNumeric
            // 
            this.mapWidthNumeric.Location = new System.Drawing.Point(52, 23);
            this.mapWidthNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mapWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapWidthNumeric.Name = "mapWidthNumeric";
            this.mapWidthNumeric.Size = new System.Drawing.Size(70, 20);
            this.mapWidthNumeric.TabIndex = 10;
            this.mapWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mapWidthNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.mapWidthNumeric.ValueChanged += new System.EventHandler(this.MapWidthNumeric_ValueChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(8, 51);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 17;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(8, 25);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(38, 13);
            this.widthLabel.TabIndex = 16;
            this.widthLabel.Text = "Width:";
            // 
            // mapTileHeightNumeric
            // 
            this.mapTileHeightNumeric.Location = new System.Drawing.Point(195, 49);
            this.mapTileHeightNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.mapTileHeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapTileHeightNumeric.Name = "mapTileHeightNumeric";
            this.mapTileHeightNumeric.Size = new System.Drawing.Size(70, 20);
            this.mapTileHeightNumeric.TabIndex = 13;
            this.mapTileHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mapTileHeightNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.mapTileHeightNumeric.ValueChanged += new System.EventHandler(this.MapTileHeightNumeric_ValueChanged);
            // 
            // mapTileWidthNumeric
            // 
            this.mapTileWidthNumeric.Location = new System.Drawing.Point(195, 23);
            this.mapTileWidthNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.mapTileWidthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mapTileWidthNumeric.Name = "mapTileWidthNumeric";
            this.mapTileWidthNumeric.Size = new System.Drawing.Size(70, 20);
            this.mapTileWidthNumeric.TabIndex = 12;
            this.mapTileWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mapTileWidthNumeric.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.mapTileWidthNumeric.ValueChanged += new System.EventHandler(this.MapTileWidthNumeric_ValueChanged);
            // 
            // tileHeightLabel
            // 
            this.tileHeightLabel.AutoSize = true;
            this.tileHeightLabel.Location = new System.Drawing.Point(132, 51);
            this.tileHeightLabel.Name = "tileHeightLabel";
            this.tileHeightLabel.Size = new System.Drawing.Size(61, 13);
            this.tileHeightLabel.TabIndex = 15;
            this.tileHeightLabel.Text = "Tile Height:";
            // 
            // tileWidthLabel
            // 
            this.tileWidthLabel.AutoSize = true;
            this.tileWidthLabel.Location = new System.Drawing.Point(132, 25);
            this.tileWidthLabel.Name = "tileWidthLabel";
            this.tileWidthLabel.Size = new System.Drawing.Size(58, 13);
            this.tileWidthLabel.TabIndex = 14;
            this.tileWidthLabel.Text = "Tile Width:";
            // 
            // numberOfRecentFilesNumeric
            // 
            this.numberOfRecentFilesNumeric.Location = new System.Drawing.Point(6, 15);
            this.numberOfRecentFilesNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberOfRecentFilesNumeric.Name = "numberOfRecentFilesNumeric";
            this.numberOfRecentFilesNumeric.Size = new System.Drawing.Size(46, 20);
            this.numberOfRecentFilesNumeric.TabIndex = 1;
            this.numberOfRecentFilesNumeric.ValueChanged += new System.EventHandler(this.NumberOfRecentFilesNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max number of files kept in recent files";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.baseLayerColorButton);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.highlightColorButton);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.backgroundColorButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(288, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Display";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // baseLayerColorButton
            // 
            this.baseLayerColorButton.Location = new System.Drawing.Point(7, 67);
            this.baseLayerColorButton.Name = "baseLayerColorButton";
            this.baseLayerColorButton.Size = new System.Drawing.Size(28, 23);
            this.baseLayerColorButton.TabIndex = 5;
            this.baseLayerColorButton.Text = "...";
            this.baseLayerColorButton.UseVisualStyleBackColor = true;
            this.baseLayerColorButton.Click += new System.EventHandler(this.BaseLayerColorButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Baselayer empty tile highlighter";
            // 
            // highlightColorButton
            // 
            this.highlightColorButton.Location = new System.Drawing.Point(7, 38);
            this.highlightColorButton.Name = "highlightColorButton";
            this.highlightColorButton.Size = new System.Drawing.Size(28, 23);
            this.highlightColorButton.TabIndex = 3;
            this.highlightColorButton.Text = "...";
            this.highlightColorButton.UseVisualStyleBackColor = true;
            this.highlightColorButton.Click += new System.EventHandler(this.HighlightColorButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tile highlight color";
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(7, 9);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(28, 23);
            this.backgroundColorButton.TabIndex = 1;
            this.backgroundColorButton.Text = "...";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Editor background color";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(229, 297);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(148, 297);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 325);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tilesetDimensionsGroupBox.ResumeLayout(false);
            this.tilesetDimensionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWidthNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTileHeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapTileWidthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRecentFilesNumeric)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numberOfRecentFilesNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown mapHeightNumeric;
        private System.Windows.Forms.NumericUpDown mapWidthNumeric;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown mapTileHeightNumeric;
        private System.Windows.Forms.NumericUpDown mapTileWidthNumeric;
        private System.Windows.Forms.Label tileHeightLabel;
        private System.Windows.Forms.Label tileWidthLabel;
        private System.Windows.Forms.GroupBox tilesetDimensionsGroupBox;
        private System.Windows.Forms.NumericUpDown tilesetHeightNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button highlightColorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button baseLayerColorButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clearRecentFilesButton;
        private System.Windows.Forms.NumericUpDown tilesetWidthNumeric;
    }
}