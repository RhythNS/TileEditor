using RhythsTileEditor.Main;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RhythsTileEditor.Forms
{
    /// <summary>
    /// Dialog for changing configs.
    /// </summary>
    public partial class ConfigForm : Form
    {
        /// <summary>
        /// Standard constructor.
        /// </summary>
        public ConfigForm()
        {
            InitializeComponent();
            SetValues();
        }

        /// <summary>
        /// Sets all controls to represent each value in the config file.
        /// </summary>
        private void SetValues()
        {
            backgroundColorButton.BackColor = XNAToSystemColor(Config.ClearColor);
            highlightColorButton.BackColor = XNAToSystemColor(Config.HighlightColor);
            numberOfRecentFilesNumeric.Value = Config.MaxNumberOfRecentFiles;
            numberOfRecentFilesNumeric.Value = Config.MaxNumberOfRecentFiles;
            mapWidthNumeric.Value = Config.MapSizeWidth;
            mapHeightNumeric.Value = Config.MapSizeHeight;
            mapTileWidthNumeric.Value = Config.MapTileSizeWidth;
            mapTileHeightNumeric.Value = Config.MapTileSizeHeight;
            tilesetWidthNumeric.Value = Config.TilesetSizeWidth;
            tilesetHeightNumeric.Value = Config.TilesetSizeHeight;
        }

        /// <summary>
        /// Converts a xna color to a System.Drawing color.
        /// </summary>
        /// <param name="color">The color to be converted.</param>
        /// <returns>The converted color.</returns>
        private Color XNAToSystemColor(Microsoft.Xna.Framework.Color color) => Color.FromArgb(color.A, color.R, color.G, color.B);

        /// <summary>
        /// Converts a System.Drawing color to a xna color.
        /// </summary>
        /// <param name="color">The color to be converted.</param>
        /// <returns>The converted color.</returns>
        private Microsoft.Xna.Framework.Color SystemToXNAColor(Color color) => new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);

        /// <summary>
        /// Callback when a key was pressed.
        /// </summary>
        private void ConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                CloseButton_Click(null, null);
        }

        /// <summary>
        /// Callback when the change background color button was clicked.
        /// </summary>
        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (ChangeColor(backgroundColorButton, Config.ClearColor, out var color) == true)
                Config.ClearColor = color;
        }

        /// <summary>
        /// Callback when the change highlight color button was clicked.
        /// </summary>
        private void HighlightColorButton_Click(object sender, EventArgs e)
        {
            if (ChangeColor(highlightColorButton, Config.HighlightColor, out var newColor) == true)
                Config.HighlightColor = newColor;
        }

        /// <summary>
        /// Callback when the change baseLayer color button was clicked.
        /// </summary>
        private void BaseLayerColorButton_Click(object sender, EventArgs e)
        {
            if (ChangeColor(baseLayerColorButton, Config.BaselayerHighlighter, out var newColor) == true)
                Config.BaselayerHighlighter = newColor;
        }

        /// <summary>
        /// Changes the color of a field in the config file.
        /// </summary>
        /// <param name="clickedButton">The button that was pressed.</param>
        /// <param name="previousColor">The color that was previously selected.</param>
        /// <param name="newColor">The new color.</param>
        /// <returns>Wheter the color changed.</returns>
        private bool ChangeColor(Button clickedButton, Microsoft.Xna.Framework.Color previousColor, out Microsoft.Xna.Framework.Color newColor)
        {
            ColorDialog cd = new ColorDialog
            {
                AllowFullOpen = true
            };

            cd.Color = XNAToSystemColor(previousColor);

            if (cd.ShowDialog() == DialogResult.OK)
            {
                clickedButton.BackColor = cd.Color;
                newColor = SystemToXNAColor(cd.Color);
                return true;
            }

            newColor = default;
            return false;
        }


        /// <summary>
        /// Callback when the reset button was clicked. This resets all settings to the default settings.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to reset all settings?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Config.Reset();
                SetValues();
            }
        }

        /// <summary>
        /// Callback to clear all recent files.
        /// </summary>
        private void ClearRecentFilesButton_Click(object sender, EventArgs e) => RecentFiles.Clear();

        /// <summary>
        /// Callback to change the number of recent files that should be kept.
        /// </summary>
        private void NumberOfRecentFilesNumeric_ValueChanged(object sender, EventArgs e) => Config.MaxNumberOfRecentFiles = (int)numberOfRecentFilesNumeric.Value;

        /// <summary>
        /// Callback to change the default map width.
        /// </summary>
        private void MapWidthNumeric_ValueChanged(object sender, EventArgs e) => Config.MapSizeWidth = (int)mapWidthNumeric.Value;

        /// <summary>
        /// Callback to change the default map height.
        /// </summary>
        private void MapHeightNumeric_ValueChanged(object sender, EventArgs e) => Config.MapSizeHeight = (int)mapHeightNumeric.Value;

        /// <summary>
        /// Callback to change the default width of a tile on a map.
        /// </summary>
        private void MapTileWidthNumeric_ValueChanged(object sender, EventArgs e) => Config.MapTileSizeWidth = (int)mapTileWidthNumeric.Value;

        /// <summary>
        /// Callback to change the default height of a tile on a map.
        /// </summary>
        private void MapTileHeightNumeric_ValueChanged(object sender, EventArgs e) => Config.MapTileSizeHeight = (int)mapTileHeightNumeric.Value;

        /// <summary>
        /// Callback to change the default width of a tile on a tileset.
        /// </summary>
        private void TilesetWidthNumeric_ValueChanged(object sender, EventArgs e) => Config.TilesetSizeWidth = (int)tilesetWidthNumeric.Value;

        /// <summary>
        /// Callback to change the default height of a tile on a tileset.
        /// </summary>
        private void TilesetHeightNumeric_ValueChanged(object sender, EventArgs e) => Config.TilesetSizeHeight = (int)tilesetHeightNumeric.Value;

        /// <summary>
        /// Callback to close the form.
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// When the form is closing, automaticly save into the config file.
        /// </summary>
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e) => Config.Save();
    }
}
