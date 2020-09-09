using RhythsTileEditor.Main;
using RhyTiles.Forms;
using RhyTiles.Main;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Tries to create a tileset.
        /// </summary>
        /// <param name="name">The name of the tileset.</param>
        /// <param name="imagePath">The path to the image.</param>
        /// <param name="tileWidth">The width of a tile in the tileset.</param>
        /// <param name="tileHeight">The height of a tile in the tileset.</param>
        /// <param name="editTileset">A reference to a tileset if it should be edited rather then newly created.</param>
        /// <param name="error">Out parameter when an error occured.</param>
        /// <returns>Wheter it was successfull or not.</returns>
        public bool TryCreateTileset(string name, string imagePath, int tileWidth, int tileHeight, Tileset editTileset, out string error)
        {
            error = null;

            if (TryReadImage(imagePath, out Image image, out error) == false)
                return false;

            if (IsImageCorrect(image, tileWidth, tileHeight, out error) == false)
                return false;

            if (editTileset == null) // should create new tileset?
            {
                Globals.loadedTilesets.Add(editTileset = new Tileset(name, imagePath, tileWidth, tileHeight, image.Width / tileWidth, image.Height / tileHeight));
                UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
                tilesetTabControl.SelectedIndex = Globals.loadedTilesets.Count - 1;
            }
            else if (editTileset.IsSameSize(tileWidth, tileHeight, image.Width, image.Height) == false) // else editing a tileset
            {
                if (MessageBox.Show("Updating this tileset will remove all custom properties of single tiles on this tileset!\nContinue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
                editTileset.Update(name, imagePath, tileWidth, tileHeight, image.Width, image.Height);
            }

            mainMapControl.AddTileset(editTileset);

            return true;
        }

        /// <summary>
        /// Function for when the user should reselect an image for a tileset.
        /// </summary>
        /// <param name="tileset">The tileset where the image should be changed.</param>
        /// <param name="filePath">The path to the image</param>
        /// <returns>Wheter it successeded or not.</returns>
        private bool ReselectImage(Tileset tileset, out string filePath)
        {
            while (true) // while image is not set and user did not abort.
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = Constants.FileDialogImageFilter;
                    ofd.FilterIndex = 2;
                    ofd.RestoreDirectory = true;

                    if (ofd.ShowDialog() != DialogResult.OK)
                    {
                        filePath = "";
                        return false;
                    }

                    string imageLocation = ofd.FileName;

                    if (TryReadImage(imageLocation, out Image image, out string error) == false)
                    {
                        MessageBox.Show(this, "Image does not match the size of the tileset.\nPlease select a valid image!", "Error", MessageBoxButtons.OK);
                        continue;
                    }

                    if (IsImageCorrect(image, tileset, out error) == false)
                    {
                        MessageBox.Show(this, error, "Error", MessageBoxButtons.OK);
                        continue;
                    }

                    filePath = imageLocation;
                    return true;
                }
            }
        }

        /// <summary>
        /// Checks if an image is openable.
        /// </summary>
        /// <param name="imagePath">The path to the image.</param>
        /// <param name="image">The image as out paramter.</param>
        /// <param name="error">Error as out parameter.</param>
        /// <returns>Wheter it successded or not.</returns>
        private bool TryReadImage(string imagePath, out Image image, out string error)
        {
            try
            {
                image = Image.FromFile(imagePath);
                error = null;
                return true;
            }
            catch (Exception)
            {
                error = "Could not read the image file.\nThe file may be corrupt or not an image!\nPlease select another image!";
                image = null;
                return false;
            }
        }

        /// <summary>
        /// Checks if the new image has the same size as the previous one.
        /// </summary>
        /// <param name="image">The new image.</param>
        /// <param name="tileWidth">The old tile width of a tile.</param>
        /// <param name="tileHeight">The old tile height of a tile.</param>
        /// <param name="error">Error as out parameter.</param>
        /// <returns>Wheter it successded or not.</returns>
        private bool IsImageCorrect(Image image, int tileWidth, int tileHeight, out string error)
        {
            error = null;
            if (image.Width % tileWidth != 0 || image.Height % tileHeight != 0)
            {
                error = "Tile width or height is invalid!\nPlease check that tileset's single tile width and height again.\nPadding and offsets are not yet implemented, sorry!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if an image is suitable to be replaced on a tileset.
        /// </summary>
        /// <param name="image">The new image.</param>
        /// <param name="tileset">The tileset where the image should be updated.</param>
        /// <param name="error">Error as out parameter.</param>
        /// <returns>Wheter the image can be used as a replacement.</returns>
        private bool IsImageCorrect(Image image, Tileset tileset, out string error)
        {
            if (IsImageCorrect(image, tileset.tileWidth, tileset.tileHeight, out error) == false)
                return false;

            if (image.Width != tileset.xSize * tileset.tileWidth || image.Height != tileset.ySize * tileset.tileHeight)
            {
                error = "Image does not match the size of the tileset.\nPlease select a valid image!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Opens a file dialog to load a Tileset.
        /// </summary>
        /// <param name="tileset">The loaded tileset.</param>
        /// <returns>Wheter it successded or not.</returns>
        private bool TrySelectTileset(out Tileset tileset)
        {
            tileset = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Constants.FileDialogTilesetFilter;
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    TryLoadTileset(ofd.FileName, out tileset);
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Could not load the Tileset", "Error", MessageBoxButtons.OK);
                    return false;
                }
            }
        }

        /// <summary>
        /// Tries to load a tileset from a given path.
        /// </summary>
        /// <param name="fileName">The path to the tileset.</param>
        /// <param name="tileset">The loaded tileset.</param>
        /// <returns>Wheter it succsseded or not.</returns>
        private bool TryLoadTileset(string fileName, out Tileset tileset)
        {
            // is the tileset already loaded?
            tileset = Globals.loadedTilesets.FirstOrDefault(x => x.path == fileName);
            if (tileset != null)
            {
                RecentFiles.OpenedTileset(fileName);
                return true;
            }

            string readFile = File.ReadAllText(fileName);

            // try load the tileset.
            try
            {
                tileset = IOManager.DeSerialize(readFile);
            }
            catch (Exception)
            {
                return false;
            }

            // is the image still correct?
            if (TryReadImage(tileset.imagePath, out Image image, out string error) == false
                || IsImageCorrect(image, tileset, out error) == false)
            {
                if (MessageBox.Show(this, "The image seems to be missing or was saved wrong.\nDo you want to reselect the image?", "Error", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false;

                if (ReselectImage(tileset, out string imagePath) == false)
                    return false;

                tileset.imagePath = imagePath;
            }
            tileset.path = fileName;

            // Notify all relevant objects about the loaded tileset.
            RecentFiles.OpenedTileset(fileName);
            Globals.loadedTilesets.Add(tileset);
            UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
            tilesetTabControl.SelectedIndex = Globals.loadedTilesets.Count - 1;
            mainMapControl.AddTileset(tileset);
            return true;
        }

        /// <summary>
        /// Try to save a tileset to a path that is selected by the user in a SaveFileDialog.
        /// </summary>
        /// <param name="tileset">The tileset to be saved.</param>
        /// <returns>Wheter it successeded or not.</returns>
        private bool SaveTilesetAs(Tileset tileset)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (string.IsNullOrEmpty(tileset.path) == false)
                {
                    sfd.InitialDirectory = tileset.path;
                }
                sfd.Filter = Constants.FileDialogTilesetFilter;
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;

                // if the user cancels the save dialog
                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                string fileName = sfd.FileName;

                // check to see if the image needs to be reselected
                bool reselectImage = false;
                try
                {
                    Image image = Image.FromFile(tileset.imagePath);
                    if (IsImageCorrect(image, tileset, out _) == false)
                        reselectImage = true;
                }
                catch (Exception)
                {
                    reselectImage = true;
                }

                // image needs to be reselected?
                if (reselectImage == true)
                {
                    if (MessageBox.Show(this, "The image file seems to be missing or not correct for the Tileset!\nPlease reselect the image file!", "Error", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return false;

                    if (ReselectImage(tileset, out string filePath) == false)
                        return false;

                    tileset.imagePath = filePath;

                    mainMapControl.AddTileset(tileset);
                }

                // save the tileset to the specified file.
                string saveTileset = IOManager.GetSerializedTileset(tileset);
                try
                {
                    File.WriteAllText(fileName, saveTileset);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Could not save the file!", "Error", MessageBoxButtons.OK);
                    return false;
                }

                // Notify all objects that the tileset saved.
                RecentFiles.OpenedTileset(fileName);
                tileset.name = Path.GetFileNameWithoutExtension(fileName);
                tileset.path = fileName;
                UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
                return true;
            }
        }

        /// <summary>
        /// Tries to get the current selected tileset index.
        /// </summary>
        /// <param name="selectedIndex">The selected index.</param>
        /// <returns>Wheter the index is in bounds.</returns>
        private bool TryGetTilesetIndex(out int selectedIndex)
        {
            selectedIndex = tilesetTabControl.SelectedIndex;
            return TileSetInBounds(selectedIndex);
        }

        /// <summary>
        /// Check wheter the tileset index is in bounds.
        /// </summary>
        /// <param name="index">The index to be checked.</param>
        /// <returns>Wheter the tileset index is in bounds.</returns>
        private bool TileSetInBounds(int index) => index > -1 && index < Globals.loadedTilesets.Count;

        /// <summary>
        /// Callback when a tileset is loaded.
        /// </summary>
        private void OnTilesetLoad(object sender, EventArgs e)
        {
            string location = ((ToolStripMenuItem)sender).Text;
            if (TryLoadTileset(location, out _) == false)
                RecentFiles.RemoveMap(location);
        }

        /// <summary>
        /// Callback when the tileset Load button was clicked. Tries to load a Tileset.
        /// </summary>
        private void TilesetLoadButton_Click(object sender, EventArgs e)
        {
            TrySelectTileset(out _);
        }

        /// <summary>
        /// Callback when the tileset save button was clicked. Tries to save a Tileset.
        /// </summary>
        private void TilesetSaveButton_Click(object sender, EventArgs e)
        {
            if (TryGetTilesetIndex(out int index) == false)
                return;

            Tileset tileset = Globals.loadedTilesets[index];

            // Is the path empty treat this as a save as
            if (string.IsNullOrEmpty(tileset.path) == true)
            {
                TilesetSaveAsButton_Click(sender, e);
                return;
            }
            
            // Try to write the tileset to file.
            try
            {
                File.WriteAllText(tileset.path, IOManager.GetSerializedTileset(tileset));
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Could not save the file!", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        /// <summary>
        /// Callback when the tileset save ás button was clicked. Tries to save a Tileset to a newly specified location.
        /// </summary>
        private void TilesetSaveAsButton_Click(object sender, EventArgs e)
        {
            if (TryGetTilesetIndex(out int index) == false)
                return;

            Tileset tileset = Globals.loadedTilesets[index];

            SaveTilesetAs(tileset);
        }

        /// <summary>
        /// Callback for when the Tileset tab index was changed
        /// </summary>
        private void TilesetTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TryGetTilesetIndex(out int index) == false)
            {
                tilesetControl.TrySetTileset(null);
                return;
            }

            Tileset tileset = Globals.loadedTilesets[index];
            if (tilesetControl.TrySetTileset(tileset) == false) // if errors occured
            {
                if (MessageBox.Show(this, "Image for Tilsets seems to be missing. It was either moved or deleted!\nDo you want to reselect it now?", "Error", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                if (ReselectImage(tileset, out string filePath) == false)
                    return;

                tileset.imagePath = filePath;
                mainMapControl.AddTileset(tileset);
                TilesetTabControl_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// Callback for when the create new tileset button was pressed. Opens the dialog
        /// for creating a new tileset.
        /// </summary>
        private void TilesetCreateNewButton_Click(object sender, EventArgs e)
        {
            TileSetEditor tse = new TileSetEditor();
            tse.Set(this);
            tse.ShowDialog(this);
            tse.Dispose();
        }

        /// <summary>
        /// Callback for when the close tileset button was pressed. Closes the currently selected tileset.
        /// </summary>
        private void TilesetCloseButton_Click(object sender, EventArgs e)
        {
            if (TryGetTilesetIndex(out int index) == false)
                return;

            Tileset tileset = Globals.loadedTilesets[index];

            bool delete = false;

            // Look through each map and see if the tileset is in use.
            // If the tileset is in use, then the user can deciede wheter to delete all references or not close the map.
            foreach (Map map in Globals.loadedMaps)
            {
                foreach (Layer layer in map.layers)
                {
                    foreach (Tile tile in layer.tiles)
                    {
                        if (tile.referencedTile != null && tile.referencedTile.parentTileset == tileset)
                        {
                            if (delete == false) 
                            {
                                if (MessageBox.Show(this,
                                    "Tileset is in use in 1 or more maps and is, therefore, required!\nWould you like to delete the tiles on the maps that are referencing this Tileset?",
                                    "Warning",
                                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                                    return;
                                delete = true;
                            }
                            tile.referencedTile = null;
                        }
                    }
                }
            }

            mainMapControl.RemoveTileset(tileset);
            Globals.loadedTilesets.Remove(tileset);
            UpdateTabs(Globals.loadedTilesets, tilesetTabControl, TilesetTabControl_SelectedIndexChanged);
        }
    }
}
