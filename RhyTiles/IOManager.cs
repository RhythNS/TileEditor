using System;
using System.Collections.Generic;
using System.Text;

namespace RhyTiles
{
    /// <summary>
    /// Manages the writing and reading of maps and tilesets.
    /// </summary>
    public static class IOManager
    {
        // quick access to the value 0-3 un utf.
        private static readonly char sep = (char)0;
        private static readonly char secondSep = (char)1;
        private static readonly char thirdSep = (char)2;
        private static readonly char fourthSep = (char)3;

        /// <summary>
        /// Serilizes the tileset into a string.
        /// </summary>
        /// <param name="tileset">The tileset that should be serilized</param>
        /// <returns>The serialized tileset</returns>
        public static string GetSerializedTileset(Tileset tileset)
        {
            // Get every important value and append them to the StringBuilder.
            StringBuilder sb = new StringBuilder();
            sb.Append(tileset.name); // index 0
            sb.Append(sep);
            sb.Append(tileset.xSize); // index 1
            sb.Append(sep);
            sb.Append(tileset.ySize); // index 2
            sb.Append(sep);
            sb.Append(tileset.tileWidth); // index 3
            sb.Append(sep);
            sb.Append(tileset.tileHeight); // index 4
            sb.Append(sep);
            sb.Append(tileset.imagePath); // index 5
            // Encode the string to UTF8 and then convert it to Base64
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        /// <summary>
        /// Creates a tileset from a serialized tileset.
        /// </summary>
        /// <param name="data">The data as a string.</param>
        /// <returns>The deserialized tileset.</returns>
        public static Tileset DeSerialize(string data)
        {
            // First decode and convert the string back from Base64
            data = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            string[] split = data.Split(sep);

            // The split should have a length of 6.
            if (split.Length != 6)
                throw new FormatException("Data string did not have a length of 6 but " + split.Length);
            
            // Go over each index of the split array and try to parse it.
            // If any fail then throw an error.
            string name = split[0];

            if (int.TryParse(split[1], out int xSize) == false)
                throw new FormatException("XSize could not be parsed! (" + split[1] + ")");

            if (int.TryParse(split[2], out int ySize) == false)
                throw new FormatException("YSize could not be parsed! (" + split[2] + ")");

            if (int.TryParse(split[3], out int tileWidth) == false)
                throw new FormatException("TileWidth could not be parsed! (" + split[3] + ")");

            if (int.TryParse(split[4], out int tileHeight) == false)
                throw new FormatException("TileHeight could not be parsed! (" + split[4] + ")");

            string imagePath = split[5];

            // Everything should be fine. Now construct the tileset and return it.
            return new Tileset(name, imagePath, tileWidth, tileHeight, xSize, ySize);
        }

        /// <summary>
        /// Serilizes the map into a string.
        /// </summary>
        /// <param name="map">The map that should be serilized</param>
        /// <returns>The serialized map</returns>
        public static string GetSerializedMap(Map map)
        {
            // Append every top level field with a sep.
            // When a field is more complex and requires its own data structure then sep2 is used.
            // When the data structure has complex fields then sep3 is used.
            StringBuilder sb = new StringBuilder();
            sb.Append(map.name);
            sb.Append(sep);
            sb.Append(map.xSize);
            sb.Append(sep);
            sb.Append(map.ySize);
            sb.Append(sep);
            sb.Append(map.tileWidth);
            sb.Append(sep);
            sb.Append(map.tileHeight);
            sb.Append(sep);

            // Iterate through each tileset and append them to the stringbuilder.
            // The if of a tile is the id of the tile in the tileset added to the number of tiles in each previous
            // tileset. Therefore we create a dictionary to store where the id of a specific tileset starts.
            Dictionary<Tileset, int> tilesetForIDStart = new Dictionary<Tileset, int>();

            int currentId = 1; // we start at 1 because 0 means that a tile does not have a refernce to a tileset.
            for (int i = 0; i < map.tilesets.Count; i++)
            {
                // append each field from the tileset.
                sb.Append(map.tilesets[i].path);
                sb.Append(thirdSep);
                sb.Append(map.tilesets[i].name);
                if (i != map.tilesets.Count - 1)
                    sb.Append(secondSep);

                // Now we add the starting id to the dictionary
                tilesetForIDStart.Add(map.tilesets[i], currentId);
                currentId += map.tilesets[i].tiles.TotalSize;
            }
            sb.Append(sep);

            // Iterate through each layer and append it to the stringbuilder.
            AppendLayer(sb, map.layers[0], tilesetForIDStart);
            for (int i = 1; i < map.layers.Count; i++)
            {
                sb.Append(secondSep);
                AppendLayer(sb, map.layers[i], tilesetForIDStart);
            }

            // Lastly encode the string to utf8 and convert it to Base64.
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        /// <summary>
        /// Append a single layer to the stringbuilder.
        /// </summary>
        /// <param name="sb">The stringbuilder to where the layer is appended to.</param>
        /// <param name="layer">The layer to be appended.</param>
        /// <param name="tilesetForIDStart">Dictionary containing the starting id of a specific tileset.</param>
        private static void AppendLayer(StringBuilder sb, Layer layer, Dictionary<Tileset, int> tilesetForIDStart)
        {
            // Append all fields to the stringbuilder.
            sb.Append(layer.name);
            sb.Append(thirdSep);
            sb.Append((layer.visible ? 1 : 0).ToString()); // A bool is appended by either 1 (true) and 0 (false).
            sb.Append(thirdSep);
            // Append all tiles.
            sb.Append(GetTileID(layer.tiles.Get(0), tilesetForIDStart));
            for (int i = 1; i < layer.tiles.TotalSize; i++)
            {
                sb.Append(fourthSep);
                sb.Append(GetTileID(layer.tiles.Get(i), tilesetForIDStart));
            }
        }

        /// <summary>
        /// Gets the id of a tile.
        /// </summary>
        /// <param name="tile">The tile to get the id from.</param>
        /// <param name="tilesetForIDStart">The starting id of a specific tileset.</param>
        /// <returns>The id of the tile.</returns>
        private static int GetTileID(Tile tile, Dictionary<Tileset, int> tilesetForIDStart) => tile.referencedTile == null ? 0 : tilesetForIDStart[tile.referencedTile.parentTileset] + tile.referencedTile.id;

        /// <summary>
        /// First step to deserialize a map. Gets the map without layer data. Load the tilesets first and then call the
        /// AddLayerData method to fully load the map.
        /// </summary>
        /// <param name="data">The data of a map as a string.</param>
        /// <param name="layerData">The layerData that can be appended when each tileset is loaded.</param>
        /// <returns>A map without layer data.</returns>
        public static Map DeSerializeWithoutLayers(string data, out string layerData)
        {
            // decode the string from utf8 and convert is back from Base64
            data = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            string[] split = data.Split(sep);

            if (split.Length != 7)
                throw new FormatException("Data string did not have a length of 7 but " + split.Length);

            // Get each field.
            string name = split[0];

            if (int.TryParse(split[1], out int xSize) == false)
                throw new FormatException("XSize could not be parsed! (" + split[1] + ")");

            if (int.TryParse(split[2], out int ySize) == false)
                throw new FormatException("YSize could not be parsed! (" + split[2] + ")");

            if (int.TryParse(split[3], out int tileWidth) == false)
                throw new FormatException("TileWidth could not be parsed! (" + split[3] + ")");

            if (int.TryParse(split[4], out int tileHeight) == false)
                throw new FormatException("TileHeight could not be parsed! (" + split[4] + ")");

            // Get all tilesets. Tilesets are not fully loaded. Only the name and the location are loaded.
            string[] splitTilesets = split[5].Split(secondSep);
            List<Tileset> tilesets = new List<Tileset>();
            for (int i = 0; i < splitTilesets.Length; i++)
            {
                string[] splitTileset = splitTilesets[i].Split(thirdSep);
                if (splitTileset.Length != 2)
                    throw new FormatException("Tileset could not be split correctly! (" + splitTilesets[i] + ")");

                string tilesetLocation = splitTileset[0];
                string tilesetName = splitTileset[1];

                Tileset tileset = new Tileset(tilesetLocation, tilesetName);
                tilesets.Add(tileset);
            }

            // put the layer data on the outgoing layerData string
            layerData = split[6];
            // construct the half loaded map and return it.
            Map map = new Map(name, xSize, ySize, tileWidth, tileHeight);
            map.tilesets = tilesets;
            return map;
        }

        /// <summary>
        /// Loads layerdata to a half loaded map.
        /// </summary>
        /// <param name="map">The map where the tiles should be loaded onto.</param>
        /// <param name="data">The layer data as a string.</param>
        public static void AddLayerData(Map map, string data)
        {
            // First split the layer data by the second sep and iterate over the split array.
            List<Layer> layers = new List<Layer>();
            string[] layersData = data.Split(secondSep);

            for (int i = 0; i < layersData.Length; i++)
            {
                // Get all basic fileds of the layer.
                string[] layerData = layersData[i].Split(thirdSep);

                if (layerData.Length != 3)
                    throw new FormatException("Layer string did not have a length of 7 but " + layerData.Length);

                string name = layerData[0];
                bool visible = layerData[1] == 1.ToString();

                // Read all tiles of the layer. The tiles are seperated by the fourth sep.
                string[] tileData = layerData[2].Split(fourthSep);
                if (tileData.Length != map.xSize * map.ySize)
                    throw new FormatException("Layer data had an invalid size of Tiles! (" + tileData.Length + "/" + map.xSize * map.ySize + ")");

                Fast2DArray<Tile> tiles = new Fast2DArray<Tile>(map.xSize, map.ySize);
                for (int j = 0; j < tileData.Length; j++)
                {
                    // Get the id of the tile.
                    if (int.TryParse(tileData[j], out int id) == false)
                        throw new FormatException("Could not parse id of tile! (" + tileData[j] + ")");

                    if (id < 0)
                        throw new FormatException("Id was negative! (" + id + ")");

                    // Convert the tile id to a TilesetTile.
                    TilesetTile reference = null;
                    if (id == 0)
                        reference = null;
                    else
                    {
                        // Go over each tileset and subtract the count of the tileset with the id.
                        // When the id becomes negative, we know that the id must be from this tileset.
                        --id; // first decrement the id by one because 0 is the id for an empty tile.
                        for (int k = 0; k < map.tilesets.Count; k++)
                        {
                            id -= map.tilesets[k].TileAmount;
                            if (id < 0) // Tileset found.
                            {
                                // Get the id by readding the tileAmount.
                                reference = map.tilesets[k].tiles.Get(id + map.tilesets[k].TileAmount);
                                break;
                            }
                        }

                        // When no reference was found throw an error.
                        if (reference == null)
                            throw new FormatException("Id was not found! (" + tileData[j] + ")");
                    }

                    // Construct the tile with the id.
                    tiles.Convert(j, out int x, out int y);
                    Tile tile = new Tile(x, y);
                    tile.referencedTile = reference;
                    tiles.Set(tile, j);
                }
                
                // Add the layer to the layer list.
                layers.Add(new Layer(name, visible, map, tiles));
            } // end for each layer in the split array.

            map.layers = layers;
        }

    }
}
