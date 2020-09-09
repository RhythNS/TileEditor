using RhythsTileEditor.Mono.Components.Commands;
using System;
using System.Windows.Forms;

namespace RhyTiles
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Unchecks all tool buttons.
        /// </summary>
        private void UnCheckAllButtons()
        {
            mapBrushButton.Checked = false;
            mapDeleteTileButton.Checked = false;
            mapFillButton.Checked = false;
        }

        /// <summary>
        /// Selects the brush tool.
        /// </summary>
        private void MapBrushButton_Click(object sender, EventArgs e)
        {
            mainMapControl.SetCommand(new DrawCommand());
            UnCheckAllButtons();
            mapBrushButton.Checked = true;
        }

        /// <summary>
        /// Selects the eraser tool.
        /// </summary>
        private void mapDeleteTileButton_Click(object sender, EventArgs e)
        {
            mainMapControl.SetCommand(new DeleteCommand());
            UnCheckAllButtons();
            mapDeleteTileButton.Checked = true;
        }

        /// <summary>
        /// Selects the flood fill tool.
        /// </summary>
        private void mapFillButton_Click(object sender, EventArgs e)
        {
            mainMapControl.SetCommand(new FloodFillCommand());
            UnCheckAllButtons();
            mapFillButton.Checked = true;
        }

    }
}
