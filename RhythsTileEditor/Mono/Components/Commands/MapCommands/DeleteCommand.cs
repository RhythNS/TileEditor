using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Deletes tiles from the map.
    /// </summary>
    public class DeleteCommand : DrawCommand
    {
        /// <summary>
        /// Constructor for when the command is meant to be executing.
        /// </summary>
        public DeleteCommand()
        {
        }

        /// <summary>
        /// Constructor for when a command was issued and is sent to the Commandmanager.
        /// </summary>
        /// <param name="changes">Changes made to the map.</param>
        public DeleteCommand(Change[] changes) : base(changes)
        {
        }

        protected override bool TryGetChangeTilesetTile(out TilesetTile changeTo)
        {
            changeTo = null;
            return true;
        }
    }
}
