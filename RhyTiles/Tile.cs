namespace RhyTiles
{
    /// <summary>
    /// Represents a tile on a map.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The content of the tile.
        /// </summary>
        public TilesetTile referencedTile;

        /// <summary>
        /// The x coordinate of the tile.
        /// </summary>
        public int x;
        /// <summary>
        /// The y coordinate of the tile.
        /// </summary>
        public int y;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="x">The x coordinate of the tile.</param>
        /// <param name="y">The y coordinate of the tile.</param>
        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
