using Microsoft.Xna.Framework;
using RhyTiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RhythsTileEditor.Main
{
    /// <summary>
    /// Manages the RecentFiles file.
    /// </summary>
    public static class RecentFiles
    {
        static RecentFiles()
        {
            Config.OnMaxNumberOfRecentFilesChanged += Config_OnMaxNumberOfRecentFilesChanged;
        }

        /// <summary>
        /// Path to recent maps.
        /// </summary>
        private static readonly string recentMaps = Path.GetDirectoryName(Application.ExecutablePath) + "\\recentMaps";
        /// <summary>
        /// Path to recent tilesets.
        /// </summary>
        private static readonly string recentTilesets = Path.GetDirectoryName(Application.ExecutablePath) + "\\recentTilesets";

        /// <summary>
        /// Callback when the max number of recent files changed.
        /// </summary>
        /// <param name="value">The new max number of recent files.</param>
        private static void Config_OnMaxNumberOfRecentFilesChanged(int value)
        {
            GetPaths(out List<string> maps, out List<string> tilesets);
            Write(maps, recentMaps);
            Write(tilesets, recentTilesets);
            MainForm.Instance.ChangedRecentFiles();
        }

        /// <summary>
        /// Gets the path to all recently opened maps and tilesets.
        /// </summary>
        /// <param name="maps">The list of paths to recently opened maps.</param>
        /// <param name="tilesets">The list of paths to recently opened tilesets.</param>
        public static void GetPaths(out List<string> maps, out List<string> tilesets)
        {
            if (File.Exists(recentMaps) == true)
            {
                maps = GetSavedPaths(recentMaps);
            }
            else
            {
                try
                {
                    File.Create(recentMaps);
                }
                catch (Exception) { }
                maps = new List<string>();
            }

            if (File.Exists(recentTilesets) == true)
            {
                tilesets = GetSavedPaths(recentTilesets);
            }
            else
            {
                try
                {
                    File.Create(recentTilesets);
                }
                catch (Exception) { }
                tilesets = new List<string>();
            }

        }

        /// <summary>
        /// Clears all recent files.
        /// </summary>
        public static void Clear()
        {
            File.WriteAllText(recentMaps, "");
            File.WriteAllText(recentTilesets, "");
        }

        /// <summary>
        /// Should be called when a map was just opened.
        /// </summary>
        /// <param name="map">The path to the map that was opened.</param>
        public static void OpenedMap(string map) => Opened(map, recentMaps);

        /// <summary>
        /// Should be called when a map failed to load and should be removed from the list.
        /// </summary>
        /// <param name="map">The path to the map that should be removed.</param>
        public static void RemoveMap(string map) => Remove(map, recentMaps);

        /// <summary>
        /// Should be called when a tileset was just opened.
        /// </summary>
        /// <param name="tileset">The path to the tileset that was opened.</param>
        public static void OpenedTileset(string tileset) => Opened(tileset, recentTilesets);

        /// <summary>
        /// Should be called when a tileset failed to load and should be removed from the list.
        /// </summary>
        /// <param name="tileset">The path to the tileset that should be removed.</param>
        public static void RemoveTileset(string tileset) => Remove(tileset, recentTilesets);

        /// <summary>
        /// Called when a path was opened.
        /// </summary>
        /// <param name="element">The path that was opened.</param>
        /// <param name="location">The path to the paths of recently opened files.</param>
        private static void Opened(string element, string location)
        {
            List<string> paths = GetSavedPaths(location, false);
            if (paths.Contains(element) == true)
                paths.Remove(element);
            paths.Insert(0, element);
            Write(paths, location);
            MainForm.Instance.ChangedRecentFiles();
        }

        /// <summary>
        /// Called when a path should be removed.
        /// </summary>
        /// <param name="element">The path that should be removed.</param>
        /// <param name="location">The path to the paths of recently opened files.</param>
        private static void Remove(string element, string location)
        {
            List<string> paths = GetSavedPaths(location, false);
            if (paths.Contains(element) == true)
                paths.Remove(element);
            Write(paths, location);
            MainForm.Instance.ChangedRecentFiles();
        }

        /// <summary>
        /// Gets all recently opend files.
        /// </summary>
        /// <param name="fromLocation">The location of the recently opened files file.</param>
        /// <param name="autoRewrite">Wheter invalid paths should be removed from the file.</param>
        /// <returns>The list of paths.</returns>
        private static List<string> GetSavedPaths(string fromLocation, bool autoRewrite = true)
        {
            List<string> paths = new List<string>();

            if (File.Exists(fromLocation) == false)
                return paths;

            bool needsRewrite = false;
            using (StringReader reader = new StringReader(File.ReadAllText(fromLocation)))
            {
                string line;
                // Read every line of the file
                while ((line = reader.ReadLine()) != null)
                {
                    // if the file exists add it to the path list
                    if (File.Exists(line) == true)
                        paths.Add(line);
                    else // otherwise the path needs to be deleted from the file.
                        needsRewrite = true;
                }
            }

            // if a path was invalid and we should correct the mistake, then write all loaded paths to the file.
            if (needsRewrite == true && autoRewrite == true)
                Write(paths, fromLocation);

            return paths;
        }

        /// <summary>
        /// Writes all recently opened paths to the recently opened file.
        /// </summary>
        /// <param name="paths">The recently opened paths.</param>
        /// <param name="saveTo">The path to the recently opened paths.</param>
        private static void Write(List<string> paths, string saveTo)
        {
            StringBuilder sb = new StringBuilder();
            int maxWrite = MathHelper.Min(paths.Count, Config.MaxNumberOfRecentFiles);
            for (int i = 0; i < maxWrite; i++)
            {
                sb.Append(paths[i]);
                if (i != paths.Count - 1)
                    sb.Append(Environment.NewLine);
            }
            File.WriteAllText(saveTo, sb.ToString());
        }
    }
}
