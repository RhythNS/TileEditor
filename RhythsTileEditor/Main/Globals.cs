using System.Collections.Generic;

namespace RhyTiles.Main
{
    /// <summary>
    /// References to global fields.
    /// </summary>
    public class Globals
    {
        /// <summary>
        /// All current loaded maps.
        /// </summary>
        public static List<Map> loadedMaps = new List<Map>();

        /// <summary>
        /// All current loaded tilesets.
        /// </summary>
        public static List<Tileset> loadedTilesets = new List<Tileset>();
    }
}
