namespace RhyTiles
{
    /// <summary>
    /// A Layer holds references to its own tiles.
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// The name of the layer.
        /// </summary>
        public string name;
        /// <summary>
        /// Wheter the layer should render or not.
        /// </summary>
        public bool visible;

        /// <summary>
        /// A reference to the map where this layer is on.
        /// </summary>
        public Map parentMap;

        /// <summary>
        /// All tiles of this layer.
        /// </summary>
        public Fast2DArray<Tile> tiles;

        /// <summary>
        /// Standard constructor for creating a new layer.
        /// </summary>
        /// <param name="name">The name of the layer.</param>
        /// <param name="parentMap">A reference to the parent map where this layer is constructed onto.</param>
        public Layer(string name, Map parentMap)
        {
            this.name = name;
            this.parentMap = parentMap;

            visible = true;

            // Create the tile array and initialize each tile.
            tiles = new Fast2DArray<Tile>(parentMap.xSize, parentMap.ySize);
            for (int y = 0; y < parentMap.ySize; y++)
            {
                for (int x = 0; x < parentMap.xSize; x++)
                {
                    tiles.Set(new Tile(x, y), x, y);
                }
            }
        }

        /// <summary>
        /// Constructor for loading a layer.
        /// </summary>
        /// <param name="name">The name of the layer.</param>
        /// <param name="visible">If the layer is visible.</param>
        /// <param name="parentMap">A reference to the parent map where this layer is constructed onto.</param>
        /// <param name="tiles">All tiles of this layer.</param>
        public Layer(string name, bool visible, Map parentMap, Fast2DArray<Tile> tiles)
        {
            this.name = name;
            this.visible = visible;
            this.parentMap = parentMap;
            this.tiles = tiles;
        }

        public Tile Tile
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Converts the layer into a string by using its name.
        /// </summary>
        /// <returns>The name of the layer.</returns>
        public override string ToString() => name;
    }
}
