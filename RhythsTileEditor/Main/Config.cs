using IniParser;
using IniParser.Model;
using Microsoft.Xna.Framework;
using RhythsTileEditor.Mono.Util;
using System;
using System.IO;
using System.Windows.Forms;

namespace RhythsTileEditor.Main
{
    public delegate void OnColorChanged(Color color);
    public delegate void OnIntChanged(int value);

    public class Config
    {
        /// <summary>
        /// Invoked when the HighlightColor changed.
        /// </summary>
        public static event OnColorChanged OnHighlightColorChanged;
        /// <summary>
        /// Invoked when the BaselayerHighlighterColor changed.
        /// </summary>
        public static event OnColorChanged OnBaselayerHighlighterColorChanged;
        /// <summary>
        /// Invoked when the MaxNumberOfRecentFiles changed.
        /// </summary>
        public static event OnIntChanged OnMaxNumberOfRecentFilesChanged;

        /// <summary>
        /// The path to the config file.
        /// </summary>
        private static readonly string configPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";

        /// <summary>
        /// Wheter the ini file that holds the configuration got corrupted.
        /// </summary>
        public static bool IniFileCorrupt { get; set; }

        /// <summary>
        /// The color that is used when a viewer clears the screen.
        /// </summary>
        public static Color ClearColor { get; set; } = Color.LightBlue;

        /// <summary>
        /// The color that is used when a tile is highlighted in a viewer.
        /// </summary>
        private static Color highlightColor = Color.Blue;
        /// <summary>
        /// The color that is used when a tile is highlighted in a viewer.
        /// </summary>
        public static Color HighlightColor
        {
            get => highlightColor;
            set
            {
                highlightColor = value;
                OnHighlightColorChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// The color that is used in the highlighter texture when no TilesetTile was referenced on a tile.
        /// </summary>
        private static Color baselayerHighlighter = Color.AliceBlue;
        /// <summary>
        /// The color that is used in the highlighter texture when no TilesetTile was referenced on a tile.
        /// </summary>
        public static Color BaselayerHighlighter
        {
            get => baselayerHighlighter;
            set
            {
                baselayerHighlighter = value;
                OnBaselayerHighlighterColorChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// The number of recent files to be kept in the recent files file.
        /// </summary>
        private static int maxNumberOfRecentFiles = 10;
        /// <summary>
        /// The number of recent files to be kept in the recent files file.
        /// </summary>
        public static int MaxNumberOfRecentFiles
        {
            get => maxNumberOfRecentFiles;
            set
            {
                maxNumberOfRecentFiles = value;
                OnMaxNumberOfRecentFilesChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// The default map width size.
        /// </summary>
        public static int MapSizeWidth { get; set; } = 80;
        /// <summary>
        /// The default map height size.
        /// </summary>
        public static int MapSizeHeight { get; set; } = 80;
        /// <summary>
        /// The default tile width on a map.
        /// </summary>
        public static int MapTileSizeWidth { get; set; } = 32;
        /// <summary>
        /// The default tile height on a map.
        /// </summary>
        public static int MapTileSizeHeight { get; set; } = 32;

        /// <summary>
        /// The default width of a tile in a tileset.
        /// </summary>
        public static int TilesetSizeWidth { get; set; } = 32;
        /// <summary>
        /// The default height of a tile in a tileset.
        /// </summary>
        public static int TilesetSizeHeight { get; set; } = 32;

        /// <summary>
        /// Resets config to the default values.
        /// </summary>
        public static void Reset()
        {
            ClearColor = Color.LightBlue;
            HighlightColor = Color.Blue;
            BaselayerHighlighter = Color.AliceBlue;
            MaxNumberOfRecentFiles = 10;
            MapSizeWidth = 80;
            MapSizeHeight = 80;
            MapTileSizeWidth = 32;
            MapTileSizeHeight = 32;
            TilesetSizeWidth = 32;
            TilesetSizeHeight = 32;
        }

        /// <summary>
        /// Saves the config into a ini file.
        /// </summary>
        public static void Save()
        {
            FileIniDataParser iniParser = new FileIniDataParser();
            IniData data = new IniData();

            SectionData files = new SectionData("Files");
            files.Keys.AddKey("MaxNumberOfRecentFiles", MaxNumberOfRecentFiles.ToString());
            files.Keys.AddKey("MapSizeWidth", MapSizeWidth.ToString());
            files.Keys.AddKey("MapSizeHeight", MapSizeHeight.ToString());
            files.Keys.AddKey("MapTileSizeWidth", MapTileSizeWidth.ToString());
            files.Keys.AddKey("MapTileSizeHeight", MapTileSizeHeight.ToString());
            files.Keys.AddKey("TilesetSizeWidth", TilesetSizeWidth.ToString());
            files.Keys.AddKey("TilesetSizeHeight", TilesetSizeHeight.ToString());
            data.Sections.Add(files);

            SectionData display = new SectionData("Display");
            display.Keys.AddKey("ClearColor", ColorToString(ClearColor));
            display.Keys.AddKey("HighlightColor", ColorToString(HighlightColor));
            display.Keys.AddKey("BaselayerHighlighter", ColorToString(BaselayerHighlighter));
            data.Sections.Add(display);


            iniParser.WriteFile(configPath, data);
        }

        /// <summary>
        /// Loads config from the ini file and applies command line arguments.
        /// </summary>
        public static void Load()
        {
            // First load the ini configs.
            LoadIni();

            // Apply the command line overrides.
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                string[] conv = arg.Split(':');

                if (conv.Length != 2)
                    continue;

                Set(conv[0], conv[1]);
            }
        }

        /// <summary>
        /// Loads config from the ini file.
        /// </summary>
        private static void LoadIni()
        {
            // if it does not exist, create it and return.
            if (File.Exists(configPath) == false)
            {
                try
                {
                   // File.Create(configPath);
                    Reset();
                    Save();
                }
                catch (Exception) { }
                return;
            }

            FileIniDataParser iniParser = new FileIniDataParser();
            IniData data;
            try
            {
                data = iniParser.ReadFile(configPath); // try to read the file
            }
            catch (Exception) // file could not be read or parsed
            {
                IniFileCorrupt = true;
                return;
            }

            if (data == null) // file was empty or could not be read or parsed.
            {
                IniFileCorrupt = true;
                return;
            }

            char sep = data.SectionKeySeparator;

            // Get all values from the config file
            if (data.TryGetKey("Files" + sep + "MaxNumberOfRecentFiles", out string value) == true)
                Set("MaxNumberOfRecentFiles", value);

            if (data.TryGetKey("Files" + sep + "MapSizeWidth", out value) == true)
                Set("MapSizeWidth", value);

            if (data.TryGetKey("Files" + sep + "MapSizeHeight", out value) == true)
                Set("MapSizeHeight", value);

            if (data.TryGetKey("Files" + sep + "MapTileSizeWidth", out value) == true)
                Set("MapTileSizeWidth", value);

            if (data.TryGetKey("Files" + sep + "MapTileSizeHeight", out value) == true)
                Set("MapTileSizeHeight", value);

            if (data.TryGetKey("Files" + sep + "TilesetSizeWidth", out value) == true)
                Set("TilesetSizeWidth", value);

            if (data.TryGetKey("Files" + sep + "TilesetSizeHeight", out value) == true)
                Set("TilesetSizeHeight", value);

            if (data.TryGetKey("Display" + sep + "ClearColor", out value) == true)
                Set("ClearColor", value);

            if (data.TryGetKey("Display" + sep + "HighlightColor", out value) == true)
                Set("HighlightColor", value);

            if (data.TryGetKey("Display" + sep + "BaselayerHighlighter", out value) == true)
                Set("BaselayerHighlighter", value); ;
        }

        /// <summary>
        /// Sets a config based on the given name of the config and the value that is going to
        /// be parsed into the config field.
        /// </summary>
        /// <param name="name">The name of the config field.</param>
        /// <param name="value">The string that value should change to.</param>
        private static void Set(string name, string value)
        {
            switch (name)
            {
                case "MaxNumberOfRecentFiles":
                    if (int.TryParse(value, out int maxNumberOfRecentFiles) == true
                        && MathUtil.InRangeInclusive(maxNumberOfRecentFiles, 0, 20))
                        MaxNumberOfRecentFiles = maxNumberOfRecentFiles;
                    break;
                case "MapSizeWidth":
                    if (int.TryParse(value, out int mapSizeWidth) == true
                        && MathUtil.InRangeInclusive(mapSizeWidth, 1, 1000))
                        MapSizeWidth = mapSizeWidth;
                    break;
                case "MapSizeHeight":
                    if (int.TryParse(value, out int mapSizeHeight) == true
                        && MathUtil.InRangeInclusive(mapSizeHeight, 1, 1000))
                        MapSizeHeight = mapSizeHeight;
                    break;
                case "MapTileSizeWidth":
                    if (int.TryParse(value, out int mapTileSizeWidth) == true
                        && MathUtil.InRangeInclusive(mapTileSizeWidth, 1, 2000))
                        MapTileSizeWidth = mapTileSizeWidth;
                    break;
                case "MapTileSizeHeight":
                    if (int.TryParse(value, out int mapTileSizeHeight) == true
                        && MathUtil.InRangeInclusive(mapTileSizeHeight, 1, 2000))
                        MapTileSizeHeight = mapTileSizeHeight;
                    break;
                case "TilesetSizeWidth":
                    if (int.TryParse(value, out int tilesetSizeWidth) == true
                        && MathUtil.InRangeInclusive(tilesetSizeWidth, 1, 2000))
                        TilesetSizeWidth = tilesetSizeWidth;
                    break;
                case "TilesetSizeHeight":
                    if (int.TryParse(value, out int tilesetSizeHeight) == true
                        && MathUtil.InRangeInclusive(tilesetSizeHeight, 1, 2000))
                        TilesetSizeHeight = tilesetSizeHeight;
                    break;
                case "ClearColor":
                    if (TryParseColor(value, out Color clearColor) == true)
                        ClearColor = clearColor;
                    break;
                case "HighlightColor":
                    if (TryParseColor(value, out Color highlightColor) == true)
                        HighlightColor = highlightColor;
                    break;
                case "BaselayerHighlighter":
                    if (TryParseColor(value, out Color baselayerHighlighter) == true)
                        BaselayerHighlighter = baselayerHighlighter;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Create a string from a color.
        /// </summary>
        /// <param name="color">The color to be converted.</param>
        /// <returns>The color in form of a string.</returns>
        public static string ColorToString(Color color) => color.R + "," + color.G + "," + color.B + "," + color.A;

        /// <summary>
        /// Try to parse a string into a color.
        /// </summary>
        /// <param name="s">The string to be parsed.</param>
        /// <param name="color">The color value.</param>
        /// <returns>If it successeded.</returns>
        public static bool TryParseColor(string s, out Color color)
        {
            color = default;

            string[] vals = s.Split(',');

            if (vals.Length != 4)
                return false;
            if (int.TryParse(vals[0], out int r) == false)
                return false;
            if (int.TryParse(vals[1], out int g) == false)
                return false;
            if (int.TryParse(vals[2], out int b) == false)
                return false;
            if (int.TryParse(vals[3], out int a) == false)
                return false;

            color = new Color(r, g, b, a);
            return true;
        }
    }
}
