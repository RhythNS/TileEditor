using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.ECS;
using RhythsTileEditor.Main;
using RhyTiles;
using RhyTiles.Mono.Util;
using System;
using System.Collections.Generic;
using IDrawable = Mono.Interfaces.IDrawable;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Draws a map.
    /// </summary>
    public class RhyTileMapDrawComponent : Component, IDrawable, IDisposable
    {
        /// <summary>
        /// The map to be drawn.
        /// </summary>
        public Map map;

        /// <summary>
        /// A dictionary of all images that are currently loaded.
        /// </summary>
        public Dictionary<Tileset, Texture2D> loadedTextures = new Dictionary<Tileset, Texture2D>();
        /// <summary>
        /// Texture that is drawn on base layer if no reference to a tileset tile was made.
        /// </summary>
        private Texture2D emptyTile;

        protected override void OnInitialize()
        {
            Config.OnBaselayerHighlighterColorChanged += CreateHighlight;
            CreateHighlight(Config.BaselayerHighlighter);
        }

        /// <summary>
        /// Creates the the texture that is drawn on base layer if no reference to a tileset tile was made.
        /// </summary>
        /// <param name="color">The color of the texture</param>
        private void CreateHighlight(Color color)
        {
            if (emptyTile != null)
                emptyTile.Dispose();

            // Create a 64x64 tile and put color data on each corner.
            emptyTile = new Texture2D(Stage.GraphicsDevice, 64, 64);
            Fast2DArray<Color> data = new Fast2DArray<Color>(64, 64);
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    if ((x > 4 && x < 61) || (y > 4 && y < 61))
                        continue;

                    data.Set(color, x, y);
                }
            }
            emptyTile.SetData(data.BackingArray);
        }

        /// <summary>
        /// Tries to add a tileset to the map drawer. Can fail if the texture is missing.
        /// </summary>
        /// <param name="tileset">The tileset that should be added.</param>
        /// <param name="error">An error if any occured.</param>
        /// <returns>Wheter the tileset was added or not.</returns>
        public bool TryAddTileset(Tileset tileset, out string error)
        {
            // If the tileset already exists, remove it first. This is done because the tileset might have updated
            // its texture.
            if (loadedTextures.ContainsKey(tileset) == true)
                RemoveTileset(tileset);

            if (MonoUtils.TryLoadTextureFromAbsolutePath(Stage.GraphicsDevice, tileset.imagePath, out Texture2D tex) == false)
            {
                error = "Could not find the image for the tileset " + tileset.name;
                return false;
            }

            loadedTextures.Add(tileset, tex);
            error = null;
            return true;
        }

        /// <summary>
        /// Removes a tileset.
        /// </summary>
        /// <param name="tileset">The tileset to be removed.</param>
        public void RemoveTileset(Tileset tileset)
        {
            if (loadedTextures.ContainsKey(tileset) == false)
            {
                Console.WriteLine("Tileset could not be unloaded since it was not found!");
                return;
            }

            Texture2D tex = loadedTextures[tileset];
            tex.Dispose();
            loadedTextures.Remove(tileset);
        }

        public void Draw(SpriteBatch batch)
        {
            if (map == null)
                return;

            Rectangle source = new Rectangle(0, 0, map.tileWidth, map.tileHeight);
            Rectangle destin = new Rectangle(0, 0, map.tileWidth, map.tileHeight);

            // Iterate over each layer
            for (int l = 0; l < map.layers.Count; l++)
            {
                // skip if layer is invisible
                if (map.layers[l].visible == false)
                    continue;

                // iterate over each tile
                for (int x = 0; x < map.xSize; x++)
                {
                    for (int y = 0; y < map.ySize; y++)
                    {
                        // Get the tile and reference TilesetTile
                        Tile tile = map.layers[l].tiles.Get(x, y);
                        TilesetTile tilesetTile = tile.referencedTile;

                        // If the tilesetTile is null or no texture was found for the tileset.
                        if (tilesetTile == null ||
                            loadedTextures.TryGetValue(tilesetTile.parentTileset, out Texture2D texture) == false)
                        {
                            // draw the emptyTile texture to the position of the tile if we are at the base layer, i.e. layer 0.
                            if (l != 0)
                                continue;
                            else
                            {
                                texture = emptyTile;
                                source.X = 0;
                                source.Y = 0;
                                source.Width = emptyTile.Width;
                                source.Height = emptyTile.Height;
                            }
                        }
                        else // tilesetTile texture was found.
                        {
                            source.Width = tilesetTile.parentTileset.tileWidth;
                            source.Height = tilesetTile.parentTileset.tileHeight;
                            source.X = tilesetTile.x * source.Width;
                            source.Y = tilesetTile.y * source.Height;
                        }

                        destin.X = x * map.tileWidth;
                        destin.Y = y * map.tileHeight;

                        // draw the tile onto screen.
                        batch.Draw(texture, destin, source, Color.White, 0, new Vector2(), SpriteEffects.None, 0);
                    }
                }
            }
        }

        public void Dispose()
        {
            foreach (Texture2D texture in loadedTextures.Values)
                texture.Dispose();
            emptyTile.Dispose();
            Config.OnBaselayerHighlighterColorChanged -= CreateHighlight;
        }
    }
}
