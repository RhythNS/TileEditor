using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhyTiles
{
    /// <summary>
    /// A map holds reference to to layers which have tiles which have references to tileset tiles.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The name of the map.
        /// </summary>
        public string name;
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string path;

        /// <summary>
        /// The amount of tiles in a row.
        /// </summary>
        public int xSize;
        /// <summary>
        /// The amount of tiles in a column.
        /// </summary>
        public int ySize;

        /// <summary>
        /// The width of a tile in the map.
        /// </summary>
        public int tileWidth;
        /// <summary>
        /// The height of a tile in the map.
        /// </summary>
        public int tileHeight;

        /// <summary>
        /// A list of all layer of this map.
        /// </summary>
        public List<Layer> layers;
        /// <summary>
        /// A list of tilesets that are used for this map.
        /// </summary>
        public List<Tileset> tilesets;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="name">The name of the map.</param>
        /// <param name="xSize">The amount of tiles in a row.</param>
        /// <param name="ySize">The amount of tiles in a column.</param>
        /// <param name="tileWidth">The width of a tile in the map.</param>
        /// <param name="tileHeight">The height of a tile in the map.</param>
        public Map(string name, int xSize, int ySize, int tileWidth, int tileHeight)
        {
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;

            // Create a single layer on the map.
            layers = new List<Layer>
            {
                new Layer("layer 1", this)
            };
            tilesets = new List<Tileset>();
        }

        public Layer Layer
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Adds a tileset to the map.
        /// </summary>
        /// <param name="tileset">The added tileset.</param>
        public void AddTileset(Tileset tileset)
        {
            tilesets.Add(tileset);
        }

        /// <summary>
        /// Converts the map into a string by using its name.
        /// </summary>
        /// <returns>The name of the map.</returns>
        public override string ToString() => name;
    }
}
