using RhythsTileEditor.Main;
using System;
using System.Windows.Forms;

namespace RhyTiles.Forms
{
    /// <summary>
    /// Dialog for creating a new tileset.
    /// </summary>
    public partial class TileSetEditor : Form
    {
        /// <summary>
        /// Reference for a callback to the main form.
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// A reference to the tileset, if a tileset should be updated rather then created.
        /// </summary>
        private Tileset editingTileset;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public TileSetEditor()
        {
            InitializeComponent();
            ActiveControl = nameTextBox;
        }

        /// <summary>
        /// Callback when a key was just released.
        /// </summary>
        private void TileSetEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CreateButton_Click(sender, null);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        /// <summary>
        /// Sets all relevant fields.
        /// </summary>
        /// <param name="mainForm">Reference for a callback to the main form.</param>
        /// <param name="editingTileset">A reference to the tileset, if a tileset should be updated rather then created.</param>
        public void Set(MainForm mainForm, Tileset editingTileset = null)
        {
            this.mainForm = mainForm;

            if (editingTileset != null)
            {
                this.editingTileset = editingTileset;
                nameTextBox.Text = editingTileset.name;
                sourceTextBox.Text = editingTileset.imagePath;
                tileWidthNumeric.Value = editingTileset.tileWidth;
                tileHeightNumeric.Value = editingTileset.tileHeight;

                createButton.Text = "Update";
            }
            else
            {
                tileWidthNumeric.Value = Config.TilesetSizeWidth;
                tileHeightNumeric.Value = Config.TilesetSizeHeight;
            }
        }

        /// <summary>
        /// Callback when the user wants to open a OpenFileDialog to look for an image to use.
        /// </summary>
        private void SourceFileDialogButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (editingTileset != null)
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                }
                openFileDialog.Filter = Constants.FileDialogImageFilter;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Callback when the clicks the cancel button.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Callback when the user clicks the create button. Tries to create a new tileset.
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // is the name box empty?
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                ShowBasicError("Please give the tileset a name!");
                return;
            }

            // is the sourcebox empty?
            if (string.IsNullOrEmpty(sourceTextBox.Text))
            {
                ShowBasicError("Please provide the location for the image to be used for the tileset!");
                return;
            }

            // try to create the tileset.
            if (mainForm.TryCreateTileset(nameTextBox.Text, sourceTextBox.Text, (int)tileWidthNumeric.Value, (int)tileHeightNumeric.Value, editingTileset, out string error) == false)
            {
                if (string.IsNullOrEmpty(error) == false)
                    ShowBasicError(error);
                return;
            }

            // Everything successeded, close the form.
            Close();
        }

        /// <summary>
        /// Shows a basic error as a messagebox.
        /// </summary>
        /// <param name="error">The error to be displayed.</param>
        private void ShowBasicError(string error) => MessageBox.Show(this, error, "Error", MessageBoxButtons.OK);
    }
}
