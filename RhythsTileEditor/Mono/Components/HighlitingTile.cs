using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.ECS;
using RhythsTileEditor.Main;
using System;
using IDrawable = Mono.Interfaces.IDrawable;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Manages when a user clicks inside of a viewer.
    /// </summary>
    /// <typeparam name="T">The type of Tile that is expected in this viewer.</typeparam>
    public abstract class HighlitingTile<T> : Component, IClickable, IDrawable, IDisposable where T : class
    {
        /// <summary>
        /// The width of the map.
        /// </summary>
        public int width;
        /// <summary>
        /// The height of the map.
        /// </summary>
        public int height;
        /// <summary>
        /// The width of a single tile.
        /// </summary>
        public int tileWidth;
        /// <summary>
        /// The height of a single tile.
        /// </summary>
        public int tileHeight;

        /// <summary>
        /// The highlighted tile. Can be null if nothing is selected.
        /// </summary>
        public T highlighted;

        /// <summary>
        /// The texture that is drawn ontop of a highlighted tile.
        /// </summary>
        public Texture2D highlightTexture;

        protected override void OnInitialize()
        {
            CreateHighlight(Config.HighlightColor);
            Config.OnHighlightColorChanged += CreateHighlight;
        }

        /// <summary>
        /// Creates the texturew for the highlighted tile.
        /// </summary>
        /// <param name="color">The color that the highlight should have.</param>
        private void CreateHighlight(Color color)
        {
            if (highlightTexture != null)
                highlightTexture.Dispose();

            // A one pixel texture that is just the color.
            highlightTexture = new Texture2D(Stage.GraphicsDevice, 1, 1);

            Color[] colorData = new Color[1];
            colorData[0] = color;

            highlightTexture.SetData(colorData);
        }

        /// <summary>
        /// Sets all required references of the HighlitingTile.
        /// </summary>
        /// <param name="width">The width of the map.</param>
        /// <param name="height">The height of the map.</param>
        /// <param name="tileWidth">The width of a single tile.</param>
        /// <param name="tileHeight">The height of a single tile.</param>
        protected void Set(int width, int height, int tileWidth, int tileHeight)
        {
            this.width = width;
            this.height = height;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            highlighted = null; // reset the hightlight to null again.
        }

        /// <summary>
        /// If the user can click on the map.
        /// </summary>
        protected abstract bool CanClick();

        public void Click()
        {
            highlighted = GetTileFromMousePosition();
        }

        /// <summary>
        /// Gets the tile that the mouse is currently over.
        /// </summary>
        /// <returns>The tile that the mouse is currently over. Can return null.</returns>
        public T GetTileFromMousePosition()
        {
            if (CanClick() == false)
                return null;

            // Get the current mouse position.
            MouseState state = Mouse.GetState();
            Vector2 pos = new Vector2(state.X, state.Y);

            pos = Stage.Camera.ScreenToWorld(pos);

            // if the mouse position is in bounds.
            if (pos.X >= 0 && pos.Y >= 0 && pos.X < width && pos.Y < height)
            {
                int tileX = (int)(pos.X / tileWidth);
                int tileY = (int)(pos.Y / tileHeight);

                // return the tile on the specific coordinates.
                return GetTile(tileX, tileY);
            }

            return null;
        }

        /// <summary>
        /// Gets a tile on specific coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The tile on given coordniates.</returns>
        protected abstract T GetTile(int x, int y);

        public void Draw(SpriteBatch spriteBatch)
        {
            if (highlighted != null)
                spriteBatch.Draw(
                    highlightTexture,
                    destinationRectangle: GetPosition(),
                    color: new Color(1, 1, 1, 0.2f)
                    );
        }

        /// <summary>
        /// Gets the position of the highlighted tile.
        /// </summary>
        /// <returns>The position of the highlighted tile.</returns>
        protected abstract Rectangle GetPosition();

        public void Dispose()
        {
            highlightTexture.Dispose();
            Config.OnHighlightColorChanged -= CreateHighlight;
        }

        public void SecondaryClick()
        {
            highlighted = null;
        }
    }
}
