namespace RhythsTileEditor.Forms
{
    partial class RenameForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.renameGroup = new System.Windows.Forms.GroupBox();
            this.renameGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(9, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(185, 20);
            this.nameBox.TabIndex = 0;
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(38, 56);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(75, 23);
            this.okayButton.TabIndex = 1;
            this.okayButton.Text = "Ok";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(119, 56);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // renameGroup
            // 
            this.renameGroup.Controls.Add(this.okayButton);
            this.renameGroup.Controls.Add(this.nameBox);
            this.renameGroup.Controls.Add(this.cancelButton);
            this.renameGroup.Location = new System.Drawing.Point(3, 5);
            this.renameGroup.Name = "renameGroup";
            this.renameGroup.Size = new System.Drawing.Size(200, 91);
            this.renameGroup.TabIndex = 3;
            this.renameGroup.TabStop = false;
            this.renameGroup.Text = "Rename";
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 98);
            this.Controls.Add(this.renameGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameForm";
            this.Text = "Rename";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenameForm_KeyDown);
            this.renameGroup.ResumeLayout(false);
            this.renameGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox renameGroup;
    }
}