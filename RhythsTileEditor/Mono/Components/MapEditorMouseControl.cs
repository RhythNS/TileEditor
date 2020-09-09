using RhythsTileEditor.Mono.Components.Commands;
using RhyTiles;
using System.Windows.Forms;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Implementation of the MouseControl for the map editor.
    /// </summary>
    public class MapEditorMouseControl : MouseControlComponent<Tile>
    {
        /// <summary>
        /// Returns wheter the user is currently drawing with any tool.
        /// </summary>
        public bool Drawing { get; private set; } = false;

        /// <summary>
        /// The current selected tool in form of a command.
        /// </summary>
        public MapCommand selectedCommand = new DrawCommand();

        public override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                StartScrolling(e);
            if (e.Button == MouseButtons.Left)
            {
                Drawing = true;
                RecordMouseClick(e);
            }
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // When the command is not a single click, continue to add data to it.
            if (Drawing == true && selectedCommand.SingleClick == false)
            {
                selectedCommand.Add();
            }
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                camMouseDown = false;
            else if (e.Button == MouseButtons.Left)
            {
                // Apply the command.
                Drawing = false;
                if (selectedCommand.SingleClick == false ||
                    (selectedCommand.SingleClick == true && MouseMovedTooFar(e) == false))
                {
                    selectedCommand.Apply();
                }
            }
        }
    }
}
