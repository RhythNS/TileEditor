namespace RhyTiles
{
    /// <summary>
    /// Represents a tile in a tileset.
    /// </summary>
    public class TilesetTile
    {
        /// <summary>
        /// Reference to parent tileset.
        /// </summary>
        public Tileset parentTileset;

        public int id;

        public int x;
        public int y;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="parentTileset">The tileset that the tile is from.</param>
        /// <param name="id">The id of the tile in the tileset.</param>
        /// <param name="x">The x coordinate of the tile in the tileset.</param>
        /// <param name="y">The y coordinate of the tile in the tileset.</param>
        public TilesetTile(Tileset parentTileset, int id, int x, int y)
        {
            this.parentTileset = parentTileset;
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
