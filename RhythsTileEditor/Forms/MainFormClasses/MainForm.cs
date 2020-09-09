using RhythsTileEditor.Main;
using RhythsTileEditor.Mono.Components.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            CommandManager.CommandsAvailable += CommandManager_CommandsAvailable;
            ChangedRecentFiles();

            if (Config.IniFileCorrupt == true)
            {
                DialogResult res = MessageBox.Show(this,
                                    "Your config file was corrupted.\nYou may want to exit the program to fix it or reset it.\nDo you want to reset the config file now?",
                                    "Error",
                                    MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                    MessageBox.Show(this, "If you change anything in the config menu, then the file will automatically be overwritten!", "Warning", MessageBoxButtons.OK);
                else if (res == DialogResult.Yes)
                    Config.Save();
            }
        }

        /// <summary>
        /// Callback funtion to check if undo and redo command is avilable.
        /// </summary>
        /// <param name="undoAvailable">Wheter undo is avilable.</param>
        /// <param name="redoAvailable">Wheter redo is avilable.</param>
        private void CommandManager_CommandsAvailable(bool undoAvailable, bool redoAvailable)
        {
            undoToolStripMenuItem.Enabled = undoAvailable;
            mapUndoButton.Enabled = undoAvailable;
            redoToolStripMenuItem.Enabled = redoAvailable;
            mapRedoButton.Enabled = redoAvailable;
        }

        /// <summary>
        /// Callback when a key was pressed.
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z) // undo
                OnUndo(null, null);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Y) // redo
                OnRedo(null, null);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) // save
                MapSaveButton_Click(null, null);
            else if (e.Modifiers == Keys.Control && e.Modifiers == Keys.Shift && e.KeyCode == Keys.S) // save as
                MapSaveAsButton_Click(null, null);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.W) // close map
                MapCloseButton_Click(null, null);
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O) // load map
                MapLoadButton_Click(null, null);
            else if (e.KeyCode == Keys.B) // select brush tool
                MapBrushButton_Click(null, null);
            else if (e.KeyCode == Keys.D) // select eraser tool
                mapDeleteTileButton_Click(null, null);
            else if (e.KeyCode == Keys.F) // select flood fill tool
                mapFillButton_Click(null, null);
        }

        /// <summary>
        /// Updates a TabControl to reflect all loaded items.
        /// </summary>
        /// <typeparam name="T">The type of element that is loaded.</typeparam>
        /// <param name="loaded">A list of all loaded elements.</param>
        /// <param name="tabControl">The TabControl to be updated.</param>
        /// <param name="onChange">Callback function when the Tabs where updates.</param>
        private void UpdateTabs<T>(List<T> loaded, TabControl tabControl, Action<object, EventArgs> onChange)
        {
            // save the current selected index
            int prevIndex = tabControl.SelectedIndex;

            TabControl.TabPageCollection pageCollection = tabControl.TabPages;

            // remove all pages
            while (pageCollection.Count != 0) pageCollection.RemoveAt(0);

            // readd all pages
            for (int i = 0; i < loaded.Count; i++)
                pageCollection.Add(loaded[i].ToString());

            // is the index still valid?
            if (prevIndex >= pageCollection.Count)
                prevIndex = pageCollection.Count - 1;
            if (prevIndex < 0)
                prevIndex = 0;

            // restore the index
            tabControl.SelectedIndex = prevIndex;

            onChange.Invoke(null, null);
        }


        /// <summary>
        /// Called when the CommandManager should undo.
        /// </summary>
        public void OnUndo(object sender, EventArgs e)
        {
            if (mainMapControl.CanUndo == false)
                return;

            CommandManager.Undo();
        }

        /// <summary>
        /// Called when the CommandManager should redo.
        /// </summary>
        public void OnRedo(object sender, EventArgs e)
        {
            if (mainMapControl.CanUndo == false)
                return;

            CommandManager.Redo();
        }

        /// <summary>
        /// Callback when a file was dropped into the editor. Loads them if they are valid.
        /// </summary>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);
                // depending on extension, load the file.
                if (extension == Constants.MapExtension)
                    TryLoadMap(file);
                else if (extension == Constants.TilesetExtension)
                    TryLoadTileset(file, out _);
            }
        }

        /// <summary>
        /// Callback when a file is hovering over the editor.
        /// </summary>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
