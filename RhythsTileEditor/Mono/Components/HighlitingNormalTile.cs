using Microsoft.Xna.Framework;
using RhyTiles;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Implementation of HighlightingTile when a Tile from a map needs to be clicked.
    /// </summary>
    public class HighlitingNormalTile : HighlitingTile<Tile>
    {
        /// <summary>
        /// The current selected layer.
        /// </summary>
        public Layer layer;

        /// <summary>
        /// Sets all required references.
        /// </summary>
        /// <param name="layer">The current selected layer.</param>
        public void Set(Layer layer)
        {
            this.layer = layer;
            if (layer != null)
                Set(layer.parentMap.tileWidth * layer.parentMap.xSize,
                    layer.parentMap.tileHeight * layer.parentMap.ySize,
                    layer.parentMap.tileWidth,
                    layer.parentMap.tileHeight);
        }

        protected override bool CanClick() => layer != null;

        protected override Rectangle GetPosition()
            => new Rectangle(
                highlighted.x * layer.parentMap.tileWidth, 
                highlighted.y * layer.parentMap.tileHeight, 
                layer.parentMap.tileWidth, 
                layer.parentMap.tileHeight
                );

        protected override Tile GetTile(int x, int y) => layer.tiles.Get(x, y);
    }
}
