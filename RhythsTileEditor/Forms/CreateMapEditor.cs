using RhythsTileEditor.Main;
using RhyTiles;
using System;
using System.Windows.Forms;

namespace RhythsTileEditor.Forms
{
    /// <summary>
    /// Dialog for creating a new map.
    /// </summary>
    public partial class CreateMapEditor : Form
    {
        /// <summary>
        /// Reference for a callback to the main form.
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// A reference to the map, if a map should be updated rather then created.
        /// </summary>
        private Map editingMap;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public CreateMapEditor()
        {
            InitializeComponent();
            ActiveControl = nameTextBox; // set the active control to be the first textbox.
        }

        /// <summary>
        /// Callback when a key was unpressed.
        /// </summary>
        private void CreateMapEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CreateButton_Click(sender, null); // try to create the map.
            else if (e.KeyCode == Keys.Escape)
                Close(); // close the form

        }

        /// <summary>
        /// Sets all relevant fields.
        /// </summary>
        /// <param name="mainForm">Reference for a callback to the main form.</param>
        /// <param name="editingMap">A reference to the map, if a map should be updated rather then created.</param>
        public void Set(MainForm mainForm, Map editingMap = null)
        {
            this.mainForm = mainForm;

            if (editingMap != null)
            {
                this.editingMap = editingMap;
                nameTextBox.Text = editingMap.name;
                tileWidthNumeric.Value = editingMap.tileWidth;
                tileHeightNumeric.Value = editingMap.tileHeight;
                widthNumeric.Value = editingMap.xSize;
                heightNumeric.Value = editingMap.ySize;

                createButton.Text = "Update";
            }
            else
            {
                tileWidthNumeric.Value = Config.MapTileSizeWidth;
                tileHeightNumeric.Value = Config.MapTileSizeHeight;
                widthNumeric.Value = Config.MapSizeWidth;
                heightNumeric.Value = Config.MapSizeHeight;
            }
        }

        /// <summary>
        /// Callback when the create button was clicked.
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // is the nameTextBox empty?
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                ShowBasicError("Please give the map a name!");
                return;
            }

            // try to create the map.
            if (mainForm.TryCreateMap(
                nameTextBox.Text,
                (int)widthNumeric.Value,
                (int)heightNumeric.Value,
                (int)tileWidthNumeric.Value,
                (int)tileHeightNumeric.Value,
                editingMap,
                out string error) == false)
            {
                if (string.IsNullOrEmpty(error) == false)
                    ShowBasicError(error);
                return;
            }

            // everything went fine. Close the form.
            Close();
        }

        /// <summary>
        /// Shows a basic error as a messagebox.
        /// </summary>
        /// <param name="error">The error to be displayed.</param>
        private void ShowBasicError(string error) => MessageBox.Show(this, error, "Error", MessageBoxButtons.OK);

        /// <summary>
        /// Callback when the cancel button was clicked.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e) => Close();
    }
}
