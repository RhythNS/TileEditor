using RhythsTileEditor.Forms;
using RhythsTileEditor.Main;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Sets the recently opened map and tilesets in the menu strip.
        /// </summary>
        public void ChangedRecentFiles()
        {
            RecentFiles.GetPaths(out List<string> maps, out List<string> tilesets);

            AddRecentPaths(recentlyOpenedMapsToolStripMenuItem, maps, OnMapLoad);
            AddRecentPaths(recentlyOpenedTilesetsToolStripMenuItem, tilesets, OnTilesetLoad);
        }

        /// <summary>
        /// Adds all recently opened files to a ToolMenuStripItem.
        /// </summary>
        /// <param name="toolStrip">The ToolStripItem to where the extra ToolStripItems are meant to be placed on.</param>
        /// <param name="paths">The paths of all recently opened files.</param>
        /// <param name="onClick">Callback function when the ToolStripItem was clicked.</param>
        private void AddRecentPaths(ToolStripMenuItem toolStrip, List<string> paths, Action<object, EventArgs> onClick)
        {
            // Remove all items from the toolStrip
            while (toolStrip.DropDownItems.Count != 0) toolStrip.DropDownItems.RemoveAt(0);

            // If there are no paths then simply disable the strip.
            if (paths.Count == 0)
            {
                toolStrip.Enabled = false;
                return;
            }

            // add all paths
            for (int i = 0; i < paths.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(paths[i]);
                item.Click += new EventHandler(onClick);
                toolStrip.DropDownItems.Add(item);
            }

            toolStrip.Enabled = true;
        }

        /// <summary>
        /// Creates a config dialog when the config ToolStripMenuItem was clicked.
        /// </summary>
        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm cf = new ConfigForm();
            cf.ShowDialog(this);
            cf.Dispose();
        }

        /// <summary>
        /// Creats a new map when the new map ToolStripMenuItem was clicked.
        /// </summary>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e) => MapCreateNewButton_Click(sender, e);

        /// <summary>
        /// Saves the currently selected map when the save ToolStripMenuItem was clicked.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => MapSaveButton_Click(sender, e);

        /// <summary>
        /// Opens a dialog to save the currently selected map to a new location when the save as ToolStripMenuItem was clicked.
        /// </summary>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => MapSaveAsButton_Click(sender, e);

        /// <summary>
        /// Opens a dialog to load a map when the load map ToolStripMenuItem was clicked.
        /// </summary>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e) => MapLoadButton_Click(sender, e);

        /// <summary>
        /// Opens the help page when the help ToolStripMenuItem was clicked.
        /// </summary>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(Constants.HelpLocation);
    }
}
