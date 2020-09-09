using System;
using System.Windows.Forms;

namespace RhythsTileEditor.Forms
{
    /// <summary>
    /// Dialog for renaming something.
    /// </summary>
    public partial class RenameForm : Form
    {
        /// <summary>
        /// If it should change an existing string.
        /// </summary>
        public bool ShouldChange { get; private set; }
        /// <summary>
        /// What the string has been changed into to.
        /// </summary>
        public string ChangeTo { get; private set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public RenameForm(string renameFrom)
        {
            InitializeComponent();
            nameBox.Text = renameFrom;
            ActiveControl = nameBox;
        }

        /// <summary>
        /// Callback when a key was pressed.
        /// </summary>
        private void RenameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OkayButton_Click(null, null); // try to rename.
            else if (e.KeyCode == Keys.Escape)
                CancelButton_Click(null, null); // close the form.
        }

        /// <summary>
        /// Callback when the cancel button was clicked.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            ShouldChange = false;
            Close();
        }

        /// <summary>
        /// Callback when the okay button was clicked.
        /// </summary>
        private void OkayButton_Click(object sender, EventArgs e)
        {
            ChangeTo = nameBox.Text;
            // Is nameBox empty?
            if (string.IsNullOrEmpty(ChangeTo))
            {
                MessageBox.Show(this, "Please enter a valid name!", "Error", MessageBoxButtons.OK);
                return;
            }

            ShouldChange = true;
            Close();
        }

    }
}
