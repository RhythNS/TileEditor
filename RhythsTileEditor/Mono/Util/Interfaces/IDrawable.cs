using Microsoft.Xna.Framework.Graphics;

namespace Mono.Interfaces
{
    /// <summary>
    /// Interface for drawing something onto the screen via a spritebatch.
    /// </summary>
    public interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
