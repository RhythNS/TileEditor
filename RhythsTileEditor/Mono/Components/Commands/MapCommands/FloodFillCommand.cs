using Microsoft.Xna.Framework;
using RhyTiles;
using RhyTiles.MapControls;
using System.Collections.Generic;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Replaces all same adjacent tiles.
    /// </summary>
    class FloodFillCommand : MapCommand
    {
        /// <summary>
        /// Constructor for when the command is meant to be executing.
        /// </summary>
        public FloodFillCommand()
        {
        }

        /// <summary>
        /// Constructor for when a command was issued and is sent to the Commandmanager.
        /// </summary>
        /// <param name="changes">Changes made to the map.</param>
        public FloodFillCommand(Change[] changes) : base(changes)
        {
        }

        public override bool SingleClick => true;

        protected override bool TryGetChangeTilesetTile(out TilesetTile changeTo)
        {
            base.TryGetChangeTilesetTile(out changeTo);
            return true;
        }

        public override void Apply()
        {
            if (TryGetTiles(out Map map, out TilesetTile changeTo, out Tile tile) == false)
                return;

            Layer layer = map.layers[MapControl.Instance.SelectedLayer];
            TilesetTile replaceFrom = tile.referencedTile;

            List<Tile> openList = new List<Tile>(); // Tiles that are still need to be processed.
            List<Tile> closedList = new List<Tile>(); // Tiles that are going to change.

            // If the pressed tile is the same as the toChange to then simply return.
            if (tile.referencedTile == changeTo)
                return;

            openList.Add(tile);
            while (openList.Count > 0)
            {
                Tile current = openList[0];

                closedList.Add(current);
                openList.RemoveAt(0);

                // Look above, right, left and beneath the currentTile.
                Point[] toExamine = new Point[4];
                toExamine[0] = new Point(current.x - 1, current.y);
                toExamine[1] = new Point(current.x + 1, current.y);
                toExamine[2] = new Point(current.x, current.y - 1);
                toExamine[3] = new Point(current.x, current.y + 1);

                for (int i = 0; i < toExamine.Length; i++)
                {
                    // out of bounds?
                    if (toExamine[i].X < 0 || toExamine[i].Y < 0 || toExamine[i].X >= map.xSize || toExamine[i].Y >= map.ySize)
                        continue;

                    // not the same tilesettile?
                    Tile newTile = layer.tiles.Get(toExamine[i].X, toExamine[i].Y);
                    if (newTile.referencedTile != replaceFrom)
                        continue;
                    
                    // already in the closed or open list?
                    if (closedList.Contains(newTile) == true || openList.Contains(newTile) == true)
                        continue;

                    openList.Add(newTile);
                }
            }

            // For each tile in the closed list, change the tile to the new tileset tile and save the command.
            for (int i = 0; i < closedList.Count; i++)
            {
                changes.Add(new Change(closedList[i], closedList[i].referencedTile, changeTo));
                closedList[i].referencedTile = changeTo;
            }

            base.Apply();
        }

    }
}
