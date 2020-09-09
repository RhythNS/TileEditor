using Microsoft.Xna.Framework;
using RhyTiles;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Implementation of the HighlitingTile for a Tilesettile.
    /// </summary>
    public class HighlitingTilesetTile : HighlitingTile<TilesetTile>
    {
        public static HighlitingTilesetTile Instance { get; private set; }
        
        public Tileset tileset;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Instance = this;
        }

        /// <summary>
        /// Sets all relevant references.
        /// </summary>
        /// <param name="tileset">The tileset that is currently in the Tileset viewer.</param>
        /// <param name="width">The amount rows of the tileset.</param>
        /// <param name="height">The amount of columns in the tileset.</param>
        public void Set(Tileset tileset, int width, int height)
        {
            this.tileset = tileset;
            if (tileset != null)
                Set(width, height, tileset.tileWidth, tileset.tileHeight);
        }

        protected override bool CanClick() => tileset != null;

        protected override TilesetTile GetTile(int x, int y) => tileset.tiles.Get(x, y);

        protected override Rectangle GetPosition()
            => new Rectangle(highlighted.x * tileset.tileWidth, highlighted.y * tileset.tileHeight, tileset.tileWidth, tileset.tileHeight);

    }
}
