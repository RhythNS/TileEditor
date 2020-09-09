using RhythsTileEditor.Forms;
using RhythsTileEditor.Main;
using RhythsTileEditor.Mono.Components.Commands;
using RhyTiles.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Tries to create a new name map. Returns false if the map could not be created.
        /// </summary>
        /// <param name="name">The name of the map.</param>
        /// <param name="xSize">The amount of tiles in a row.</param>
        /// <param name="ySize">The amount of tiles in a column.</param>
        /// <param name="tileWidth">The width of a tile in the map.</param>
        /// <param name="tileHeight">The height of a tile in the map.</param>
        /// <param name="editingMap">Reference to a map when it was editited and not newly created.</param>
        /// <param name="error">Error as out parameter when it failed to create the map.</param>
        /// <returns>Wheter the map got created or not.</returns>
        public bool TryCreateMap(string name, int xSize, int ySize, int tileWidth, int tileHeight, Map editingMap, out string error)
        {
            if (editingMap != null)
            {
                error = "Not yet implented to change a map!";
                return false;
            }

            Map map = new Map(name, xSize, ySize, tileWidth, tileHeight);
            Globals.loadedMaps.Add(map);
            error = null;

            UpdateTabs(Globals.loadedMaps, mapTabControl, MapTabControl_SelectedIndexChanged);
            mapTabControl.SelectedIndex = Globals.loadedMaps.Count - 1;

            return true;
        }

        /// <summary>
        /// Tries to get the index of the currently selected map.
        /// </summary>
        /// <param name="selectedIndex">The index of the currently selected map.</param>
        /// <returns>Wheter the index was out of bounds or not.</returns>
        private bool TryGetMapIndex(out int selectedIndex)
        {
            selectedIndex = mapTabControl.SelectedIndex;
            return MapInBounds(selectedIndex);
        }

        /// <summary>
        /// Checks if the index is in bounds of the loaded maps.
        /// </summary>
        /// <param name="index">The index to be checked.</param>
        /// <returns>Wheter the index is in bounds.</returns>
        private bool MapInBounds(int index) => index > -1 && index < Globals.loadedMaps.Count;

        /// <summary>
        /// Tries to load a map.
        /// </summary>
        /// <param name="fileName">The path to the map file.</param>
        /// <returns>Wheter it successded in loading the map.</returns>
        private bool TryLoadMap(string fileName)
        {
            // if the map is already loaded.
            if (Globals.loadedMaps.Exists(x => x.path == fileName) == true)
                return true;

            try
            {
                // read the map and deserialize it
                string readFile = File.ReadAllText(fileName);
                Map map = IOManager.DeSerializeWithoutLayers(readFile, out string layerData);

                // Get the tilesets that the map needs
                List<Tileset> toLoad = map.tilesets;
                for (int i = 0; i < toLoad.Count; i++)
                {
                    Tileset tileset = Globals.loadedTilesets.FirstOrDefault(x => x.path == toLoad[i].path);
                    // is the tileset not loaded?
                    if (tileset == null)
                    {
                        try
                        {
                            // try to load the map.
                            if (TryLoadTileset(toLoad[i].path, out tileset) == false)
                                tileset = null;
                        }
                        catch (Exception) { }

                        if (tileset == null) // could not load the tileset. Tilesets should now be reselected.
                        {
                            if (MessageBox.Show(this, "Tileset not found! Please reselect the exact tileset!\n" +
                                "If an incorrect one is selected, then the map might not load or load incorrectly!\n" +
                                "The needed tileset is called " + toLoad[i].name +
                                "\nAnd was previously at this location:\n" + toLoad[i].path,
                                "Error", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                return false;

                            if (TrySelectTileset(out tileset) == false)
                                return false;
                        }
                    }

                    toLoad[i] = tileset;

                } // end for load all tilesets

                // attach missing fileds to the map.
                map.tilesets = toLoad;
                map.path = fileName;
                IOManager.AddLayerData(map, layerData);

                Globals.loadedMaps.Add(map);
            }
            catch (Exception) // if anything went wrong show an error that the map could not be loaded.
            {
                MessageBox.Show(this, "Could not load the map.", "Error", MessageBoxButtons.OK);
                return false;
            }

            // Notify all relevant objects that a map was loaded.
            RecentFiles.OpenedMap(fileName);
            UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
            UpdateTabs(Globals.loadedMaps, mapTabControl, MapTabControl_SelectedIndexChanged);
            mapTabControl.SelectedIndex = Globals.loadedMaps.Count - 1;
            return true;
        }

        /// <summary>
        /// Saves a map.
        /// </summary>
        /// <param name="map">The map to be saved.</param>
        /// <param name="fileName">The path that should be written to.</param>
        private void SaveMap(Map map, string fileName = null)
        {
            // Get all tilesets that need to be saved for the map.
            List<Tileset> neededTilesets = new List<Tileset>();
            foreach (Layer layer in map.layers)
            {
                foreach (Tile tile in layer.tiles)
                {
                    if (tile.referencedTile != null && neededTilesets.Contains(tile.referencedTile.parentTileset) == false)
                        neededTilesets.Add(tile.referencedTile.parentTileset);
                }
            }

            // if there are any unsaved unsed tilesets, display a messagebox to save them now.
            bool displayedWarning = false;
            for (int i = 0; i < neededTilesets.Count; i++)
            {
                if (string.IsNullOrEmpty(neededTilesets[i].path) == true)
                {
                    if (displayedWarning == false)
                    {
                        if (MessageBox.Show(this, "You need to save the tilesets first!\nSave them now?", "Info", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        displayedWarning = true;
                    }

                    MessageBox.Show(this, "Now saving " + neededTilesets[i].name, "Info", MessageBoxButtons.OK);
                    if (SaveTilesetAs(neededTilesets[i]) == false)
                        return;
                }
            }

            // If the map has no tilesets, it can not be saved.
            if (neededTilesets.Count == 0)
            {
                MessageBox.Show(this, "You can not save empty maps!", "error", MessageBoxButtons.OK);
                return;
            }

            map.tilesets = neededTilesets;

            if (displayedWarning == true)
                MessageBox.Show(this, "All tilesets saved!", "Info", MessageBoxButtons.OK);

            // if the filename is null or empty, let the user select a new path.
            if (string.IsNullOrEmpty(fileName))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = Constants.FileDialogTileMapFilter;
                    sfd.FilterIndex = 2;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    //Get the path of specified file
                    fileName = sfd.FileName;
                }
            }

            try // try and save the map
            {
                File.WriteAllText(fileName, IOManager.GetSerializedMap(map));
            }
            catch (Exception) // display errors, if the saving failed.
            {
                MessageBox.Show(this, "Could not save the file!", "Error", MessageBoxButtons.OK);
                return;
            }

            // Notify all relevant objects that a map was saved.
            RecentFiles.OpenedMap(fileName);
            map.name = Path.GetFileNameWithoutExtension(fileName);
            map.path = fileName;
            UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
            UpdateTabs(Globals.loadedMaps, mapTabControl, MapTabControl_SelectedIndexChanged);
        }

        /// <summary>
        /// Callback for when the map tab control changed index.
        /// </summary>
        private void MapTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TryGetMapIndex(out int index) == false)
            {
                mainMapControl.TrySetMap(null);
            }
            else if (mainMapControl.TrySetMap(Globals.loadedMaps[index]) == false)
            {
                Console.WriteLine("Map could not be loaded!");
                return;
            }
            UpdateLayers();
        }

        /// <summary>
        /// Called when a map was loaded.
        /// </summary>
        private void OnMapLoad(object sender, EventArgs e)
        {
            string location = ((ToolStripMenuItem)sender).Text;
            if (TryLoadMap(location) == false)
                RecentFiles.RemoveMap(location);
        }

        /// <summary>
        /// Called when the the map save button was clicked. Saves the map.
        /// </summary>
        private void MapSaveButton_Click(object sender, EventArgs e)
        {
            if (TryGetMapIndex(out int index) == false)
                return;

            Map map = Globals.loadedMaps[index];

            SaveMap(map, map.path);
        }

        /// <summary>
        /// Called when the the map save as button was clicked. Opens a dialog to specify a new location to where
        /// the map is saved to.
        /// </summary>
        private void MapSaveAsButton_Click(object sender, EventArgs e)
        {
            if (TryGetMapIndex(out int index) == false)
                return;

            Map map = Globals.loadedMaps[index];

            SaveMap(map);
        }

        /// <summary>
        /// Called when the the map load button was clicked. Loads a map.
        /// </summary>
        private void MapLoadButton_Click(object sender, EventArgs e)
        {
            string fileName;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Constants.FileDialogTileMapFilter;
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                fileName = ofd.FileName;
            }

            TryLoadMap(fileName);
        }

        /// <summary>
        /// Called when the the new map button was clicked. Opens a dialog to create a new map.
        /// </summary>
        private void MapCreateNewButton_Click(object sender, EventArgs e)
        {
            CreateMapEditor cme = new CreateMapEditor();
            cme.Set(this);
            cme.ShowDialog(this);
            cme.Dispose();
        }

        /// <summary>
        /// Called when the currently selected map should close.
        /// </summary>
        private void MapCloseButton_Click(object sender, EventArgs e)
        {
            if (TryGetMapIndex(out int index) == false)
                return;

            Map map = Globals.loadedMaps[index];

            if (map.layers.Count != 1 || HasAtleastOneTile(map) == true)
            {
                DialogResult res = MessageBox.Show(this, "Do you want to save the map first?", "Info", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                    SaveMap(map, map.path);
                else if (res != DialogResult.No)
                    return;
            }

            Globals.loadedMaps.Remove(map);
            UpdateTabs(Globals.loadedMaps, mapTabControl, MapTabControl_SelectedIndexChanged);
            CommandManager.Validate();
        }

        /// <summary>
        /// Helper method to dermine if a map has atleast one reference to a tileset tile.
        /// </summary>
        /// <param name="map">The map to check.</param>
        /// <returns>Wheter a map has atleast one reference to a tileset tile.</returns>
        private bool HasAtleastOneTile(Map map)
        {
            foreach (Layer layer in map.layers)
            {
                foreach (Tile tile in layer.tiles)
                {
                    if (tile.referencedTile != null)
                        return true;
                }
            }
            return false;
        }
    }
}
