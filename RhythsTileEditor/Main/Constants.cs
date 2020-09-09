using System.IO;
using System.Windows.Forms;

namespace RhythsTileEditor.Main
{
    /// <summary>
    /// Unchangable values that are needed throughout the program. 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The filter for tileset files.
        /// </summary>
        public static readonly string FileDialogTilesetFilter = "RhyTiles Tileset (*.rtt)|*.rtt";
        /// <summary>
        /// The filter for map files.
        /// </summary>
        public static readonly string FileDialogTileMapFilter = "RhyTiles Map (*.rtm)|*.rtm";
        /// <summary>
        /// The filter for image files.
        /// </summary>
        public static readonly string FileDialogImageFilter = "Portable Network Graphics (*.png)|*.png";
        /// <summary>
        /// The extension for tileset files.
        /// </summary>
        public static readonly string TilesetExtension = ".rtt";
        /// <summary>
        /// The extension for map files.
        /// </summary>
        public static readonly string MapExtension = ".rtm";
        /// <summary>
        /// The location of the help webpage.
        /// </summary>
        public static readonly string HelpLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\Help\\index.html";
    }
}
