using RhythsTileEditor.Forms;
using RhythsTileEditor.Mono.Components.Commands;
using RhythsTileEditor.Mono.Components.Commands.LayerCommands;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Updates all layers in the layerListBox.
        /// </summary>
        /// <param name="increaseLayerByOne"></param>
        public void UpdateLayers(bool? increaseLayerByOne = null)
        {
            // clear all items
            layerListBox.Items.Clear();

            Map map = mainMapControl.Map;
            if (map == null)
                return;

            // get the previous index
            int previousIndex = layerListBox.SelectedIndex;
            // modify the index if requested
            if (increaseLayerByOne != null)
                previousIndex = increaseLayerByOne.Value ? previousIndex + 1 : previousIndex - 1;

            // add all layers
            for (int i = 0; i < map.layers.Count; i++)
                layerListBox.Items.Add(map.layers[i].name + (map.layers[i].visible ? "" : " (invisible)"));

            // restore the previous index
            layerListBox.SetSelected(LayerInBounds(map, previousIndex) == true ? previousIndex : 0, true);
        }

        /// <summary>
        /// Try to get the layer index. Returns false if index is not in bounds.
        /// </summary>
        /// <param name="map">The map from where the layers should be gotten from.</param>
        /// <param name="layerIndex">The returning layer index.</param>
        /// <returns>Wheter it successeded or not.</returns>
        private bool TryGetLayerIndex(Map map, out int layerIndex)
        {
            layerIndex = layerListBox.SelectedIndex;
            return LayerInBounds(map, layerIndex);
        }

        /// <summary>
        /// Checks if the layerIndex is in bounds of the layers on the map.
        /// </summary>
        /// <param name="map">The map where the layers are on.</param>
        /// <param name="layerIndex">The layerIndex to check.</param>
        /// <returns>Wheter it is in bounds.</returns>
        private bool LayerInBounds(Map map, int layerIndex) => layerIndex > -1 && layerIndex < map.layers.Count;

        /// <summary>
        /// Creates a new layer.
        /// </summary>
        private void CreateLayerButton_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null)
                return;

            CommandManager.Add(new LayerAddCommand(map, "New Layer"), true);
            layerListBox.SelectedIndex = map.layers.Count - 1;
        }

        /// <summary>
        /// Deletes the currently selected layer.
        /// </summary>
        private void DeleteLayerButton_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null || TryGetLayerIndex(map, out int layerIndex) == false)
                return;

            if (map.layers.Count == 1)
            {
                MessageBox.Show(this, "Tile must always have one layer.\nPlease add another before deleting this one!", "Info", MessageBoxButtons.OK);
                return;
            }

            // if the layer has tiles on it, display a warning that they are going to be also deleted.
            if (map.layers[layerIndex].tiles.Any(x => x.referencedTile != null) == true)
            {
                if (MessageBox.Show(this, "This layer has tiles on it. These would also be deleted!\nContinue?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            CommandManager.Add(new LayerRemoveCommand(map, layerIndex), true);
        }

        /// <summary>
        /// Toggles visibility on the currently selected layer.
        /// </summary>
        private void LayerSetVisibleButton_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null || TryGetLayerIndex(map, out int layerIndex) == false)
                return;

            CommandManager.Add(new LayerSetVisible(map, map.layers[layerIndex]), true);
        }

        /// <summary>
        /// Callback when the index of the currently selected layer changed.
        /// </summary>
        private void LayerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null)
                return;

            mainMapControl.ChangeLayer(layerListBox.SelectedIndex);
        }

        /// <summary>
        /// Moves the currently selected layer up by one.
        /// </summary>
        private void MoveLayerUp_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null || TryGetLayerIndex(map, out int layerIndex) == false)
                return;

            if (layerIndex == map.layers.Count - 1)
                return;

            CommandManager.Add(new MoveLayerCommand(map, true, layerIndex), true);
            layerListBox.SelectedIndex = layerIndex + 1;
        }

        /// <summary>
        /// Moves the currently selected layer down by one.
        /// </summary>
        private void MoveLayerDown_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null || TryGetLayerIndex(map, out int layerIndex) == false)
                return;

            if (layerIndex == 0)
                return;

            MoveLayerCommand mlc = new MoveLayerCommand(map, false, layerIndex);
            CommandManager.Add(mlc, true);
            layerListBox.SelectedIndex = layerIndex - 1;
        }

        /// <summary>
        /// Callback when a item in the layerListBox was double clicked. Opens a dialog to rename that layer.
        /// </summary>
        private void LayerListBox_MouseDoubleClick(object sender, MouseEventArgs e) => LayerRenameButton_Click(sender, null);

        /// <summary>
        /// Opens a dialog to rename the currently selected layer.
        /// </summary>
        private void LayerRenameButton_Click(object sender, EventArgs e)
        {
            Map map = mainMapControl.Map;
            if (map == null || TryGetLayerIndex(map, out int layerIndex) == false)
                return;

            // open the dialog.
            RenameForm rename = new RenameForm(map.layers[layerIndex].name);
            rename.ShowDialog(this);
            // should the name change?
            if (rename.ShouldChange == true)
            {
                string toChangeTo = rename.ChangeTo;
                CommandManager.Add(new RenameLayerCommand(map, toChangeTo, map.layers[layerIndex]), true);
            }
            rename.Dispose();
        }

        /// <summary>
        /// Callback when an item in the layerlistbox was right clicked. This brings up a ContextMenu with all buttons
        /// as a shortcut.
        private void LayerListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            int index = layerListBox.IndexFromPoint(e.X, e.Y);
            if (index == ListBox.NoMatches)
                return;

            layerListBox.SelectedIndex = index;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Rename", layerRenameButton.Image, LayerRenameButton_Click);
            contextMenu.Items.Add("Toggle visibility", layerSetVisibleButton.Image, LayerSetVisibleButton_Click);
            contextMenu.Items.Add("Move up", moveLayerUp.Image, MoveLayerUp_Click);
            contextMenu.Items.Add("Move down", moveLayerDown.Image, MoveLayerDown_Click);
            contextMenu.Show(layerListBox.PointToScreen(e.Location));
        }
    }
}
