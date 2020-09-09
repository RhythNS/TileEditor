using RhyTiles;
using RhyTiles.MapControls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Draws tiles onto the map.
    /// </summary>
    public class DrawCommand : MapCommand
    {
        /// <summary>
        /// Constructor for when the command is meant to be executing.
        /// </summary>
        public DrawCommand()
        {
        }

        /// <summary>
        /// Constructor for when a command was issued and is sent to the Commandmanager.
        /// </summary>
        /// <param name="changes">Changes made to the map.</param>
        public DrawCommand(Change[] changes) : base(changes)
        {
        }

        public override bool SingleClick => false;


        public override void Add()
        {
            if (TryGetTiles(out _, out TilesetTile changeTo, out Tile tile) == false)
                return;

            TilesetTile prevTile = tile.referencedTile;

            if (prevTile == changeTo)
                return;

            tile.referencedTile = changeTo;
            changes.Add(new Change(tile, prevTile, changeTo));
        }
    }
}
