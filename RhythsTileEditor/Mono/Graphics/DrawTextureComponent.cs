using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.ECS;
using Mono.ECS.Components;
using IDrawable = Mono.Interfaces.IDrawable;

namespace RhythsTileEditor.Mono.Graphics
{
    public class DrawTextureComponent : Component, IDrawable
    {
        public Texture2D tex;
        private Transform2 transform;

        protected override void OnInitialize()
        {
            Actor.TryGetComponent(out transform);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (tex != null)
                spriteBatch.Draw(tex, transform.WorldPosition, Color.White);
        }
    }
}
