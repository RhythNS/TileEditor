namespace RhyTiles
{
    /// <summary>
    /// Takes an image, cuts it up and makes tiles from it.
    /// </summary>
    public class Tileset
    {
        /// <summary>
        /// The width of a tile in the tileset.
        /// </summary>
        public int tileWidth;
        /// <summary>
        /// The height of a tile in the tileset.
        /// </summary>
        public int tileHeight;

        /// <summary>
        /// The amount of tiles in a row.
        /// </summary>
        public int xSize;
        /// <summary>
        /// The amount of tiles in a column.
        /// </summary>
        public int ySize;

        /// <summary>
        /// The name of the tileset.
        /// </summary>
        public string name;
        /// <summary>
        /// The path to the tileset file.
        /// </summary>
        public string path;
        /// <summary>
        /// The path to the image.
        /// </summary>
        public string imagePath;

        /// <summary>
        /// All tiles from the tileset.
        /// </summary>
        public Fast2DArray<TilesetTile> tiles;

        /// <summary>
        /// The total amount of tiles in this tileset.
        /// </summary>
        public int TileAmount => tiles.TotalSize;

        public TilesetTile TilesetTile
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Constructor for creating a new tileset.
        /// </summary>
        /// <param name="name">The name of the tileset.</param>
        /// <param name="imagePath">The path to the image used for this tileset.</param>
        /// <param name="tileWidth">The width of a tile in the tileset.</param>
        /// <param name="tileHeight">The height of a tile in the tileset.</param>
        /// <param name="xSize">The amount of tiles in a row.</param>
        /// <param name="ySize">The amount of tiles in a column.</param>
        public Tileset(string name, string imagePath, int tileWidth, int tileHeight, int xSize, int ySize)
        {
            Update(name, imagePath, tileWidth, tileHeight, xSize, ySize);
        }

        /// <summary>
        /// Constructor for a half constructed tileset. Only use this when you updated the missing
        /// data on this tileset.
        /// </summary>
        /// <param name="path">The path to the tileset.</param>
        /// <param name="name">The name of the tileset.</param>
        public Tileset(string path, string name)
        {
            this.path = path;
            this.name = name;
        }

        /// <summary>
        /// Updates all relevant information about this tileset.
        /// </summary>
        /// <param name="name">The name of the tileset.</param>
        /// <param name="imagePath">The path to the image used for this tileset.</param>
        /// <param name="tileWidth">The width of a tile in the tileset.</param>
        /// <param name="tileHeight">The height of a tile in the tileset.</param>
        /// <param name="xSize">The amount of tiles in a row.</param>
        /// <param name="ySize">The amount of tiles in a column.</param>
        public void Update(string name, string imagePath, int tileWidth, int tileHeight, int xSize, int ySize)
        {
            this.name = name;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.imagePath = imagePath;
            this.xSize = xSize;
            this.ySize = ySize;

            tiles = new Fast2DArray<TilesetTile>(xSize, ySize);

            // iterate ofer the array and initialize each tile.
            int counter = -1;
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    tiles.Set(new TilesetTile(this, ++counter, x, y), x, y);
                }
            }
        }

        /// <summary>
        /// Helper method for determing of each size is the same.
        /// </summary>
        /// <param name="tileWidth">The width of a tile in the tileset.</param>
        /// <param name="tileHeight">The height of a tile in the tileset.</param>
        /// <param name="xSize">The amount of tiles in a row.</param>
        /// <param name="ySize">The amount of tiles in a column.</param>
        /// <returns>Wheter the size is the same.</returns>
        public bool IsSameSize(int tileWidth, int tileHeight, int xSize, int ySize)
            => this.tileWidth == tileWidth && this.tileHeight == tileHeight && this.xSize == xSize && this.ySize == ySize;


        /// <summary>
        /// Converts the tileset into a string by using its name.
        /// </summary>
        /// <returns>The name of the tilset.</returns>
        public override string ToString() => name;
    }
}
