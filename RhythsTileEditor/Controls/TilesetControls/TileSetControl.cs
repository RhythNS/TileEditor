using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.ECS;
using Mono.ECS.Components;
using RhythsTileEditor.Controls;
using RhythsTileEditor.Mono.Components;
using RhythsTileEditor.Mono.Graphics;
using RhyTiles.Mono.Util;

namespace RhyTiles.Controls.TilesetControls
{
    /// <summary>
    /// Viewer Control for tilesets.
    /// </summary>
    public class TileSetControl : BaseControl<TilesetTile>
    {
        /// <summary>
        /// The currently loaded Tileset as texture.
        /// </summary>
        private Texture2D loadedTexture;

        /// <summary>
        /// Component that draws the tileset.
        /// </summary>
        private DrawTextureComponent dtc;

        /// <summary>
        /// Try to set the tileset. Might return false if an error ocurred.
        /// </summary>
        /// <param name="newTileset">The tileset to be set.</param>
        /// <returns>Wheter the tileset was set or an error ocurred.</returns>
        public bool TrySetTileset(Tileset newTileset)
        {
            if (this.loadedTexture != null)
                this.loadedTexture.Dispose();

            if (newTileset == null)
            {
                dtc.tex = null;
                htt.highlighted = null;
                return true;
            }

            // try and load the texture.
            if (MonoUtils.TryLoadTextureFromAbsolutePath(GraphicsDevice, newTileset.imagePath, out Texture2D loadedTexture) == false)
            {
                dtc.tex = null;
                return false;
            }

            this.loadedTexture = loadedTexture;

            dtc.tex = loadedTexture;
            mcc.Set(this, loadedTexture.Width, loadedTexture.Height);
            ((HighlitingTilesetTile)htt).Set(newTileset, loadedTexture.Width, loadedTexture.Height);

            mcc.Clamp();

            // Reset the camera
            Stage.Camera.Zoom = 1;
            Stage.Camera.CenterOn(new Vector2(loadedTexture.Width, loadedTexture.Height));

            return true;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();

            Actor drawActor = Stage.CreateActor(0);
            drawActor.AddComponent<Transform2>();
            dtc = drawActor.AddComponent<DrawTextureComponent>();
        }

        protected override HighlitingTile<TilesetTile> AddHighlitingTile(Actor toPlaceOn)
            => toPlaceOn.AddComponent<HighlitingTilesetTile>();

        protected override void Dispose(bool disposing)
        {
            if (loadedTexture != null)
                loadedTexture.Dispose();
        }

    }
}
