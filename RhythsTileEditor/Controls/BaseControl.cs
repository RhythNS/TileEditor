using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.ECS;
using Mono.ECS.Components;
using Mono.Util.Pools;
using MonoGame.Forms.Controls;
using RhythsTileEditor.Main;
using RhythsTileEditor.Mono.Components;
using System.Windows.Forms;

namespace RhythsTileEditor.Controls
{
    /// <summary>
    /// Base class for viewers.
    /// </summary>
    /// <typeparam name="T">The type of tile that can be selected in the viewer.</typeparam>
    public abstract class BaseControl<T> : MonoGameControl where T : class
    {
        protected MouseControlComponent<T> mcc;
        protected HighlitingTile<T> htt;

        public Stage Stage { get; private set; }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            mcc.OnMouseClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mcc.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mcc.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mcc.OnMouseMove(e);
        }

        /// <summary>
        /// Adds a HighlitingTile to an actor.
        /// </summary>
        /// <param name="toPlaceOn">The actor to where the HighlightingTile should be added to.</param>
        /// <returns>The Highliting Tile.</returns>
        protected abstract HighlitingTile<T> AddHighlitingTile(Actor toPlaceOn);

        /// <summary>
        /// Adds a MouseControlComponent to an actor.
        /// </summary>
        /// <param name="toPlaceOn">The actor to where the MouseControlComponent should be added to.</param>
        /// <returns>The MouseControlComponent</returns>
        protected virtual MouseControlComponent<T> AddMouseControl(Actor toPlaceOn) 
            => toPlaceOn.AddComponent<MouseControlComponent<T>>();

        protected override void Initialize()
        {
            base.Initialize();
            Stage = new Stage(2, new Pool<Actor>(150, 40), GraphicsDevice);

            Actor utilityActor = Stage.CreateActor(0);
            mcc = AddMouseControl(utilityActor);
            mcc.baseControl = this;
            htt = AddHighlitingTile(utilityActor);

            mcc.clickable = htt;

            Actor drawActor = Stage.CreateActor(0);
            drawActor.AddComponent<Transform2>();

            OnMouseWheelUpwards += mcc.OnMouseWheelUpwards;
            OnMouseWheelDownwards += mcc.OnMouseWheelDownwards;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Stage.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            GraphicsDevice.Clear(Config.ClearColor);

            Stage.Draw();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Stage.Dispose();
        }
    }
}
