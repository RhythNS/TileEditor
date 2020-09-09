using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.ECS;
using RhythsTileEditor.Controls;
using System;
using System.Windows.Forms;
using Camera = Mono.Graphics.Camera;
using IUpdateable = Mono.Interfaces.IUpdateable;

namespace RhythsTileEditor.Mono.Components
{
    /// <summary>
    /// Handles mouse control.
    /// </summary>
    /// <typeparam name="T">The class that is selected when a mouse press occured.</typeparam>
    public class MouseControlComponent<T> : Component, IUpdateable, IDisposable where T : class
    {
        /// <summary>
        /// Reference to the Control this Component is on.
        /// </summary>
        public BaseControl<T> baseControl;
        /// <summary>
        /// The width of the displayed map.
        /// </summary>
        public int mapWidth;
        /// <summary>
        /// The height of the displayed map.
        /// </summary>
        public int mapHeight;
        /// <summary>
        /// A reference to the clickable that manages the clicks.
        /// </summary>
        public IClickable clickable;

        /// <summary>
        /// When the mouse moves more than this number during MouseDown and MouseUp, then it does
        /// not qualify as a click.
        /// </summary>
        public static readonly int pixelsNeededForMove = 3;

        /// <summary>
        /// Location of where the mouse was one frame ago. Only updated when the primary button is pressed.
        /// </summary>
        protected System.Drawing.Point prevMouseDown;
        /// <summary>
        /// Location of the mouse when the primary button was clicked.
        /// </summary>
        protected System.Drawing.Point startMouseDown;
        /// <summary>
        /// Should the camera move?
        /// </summary>
        protected bool camMouseDown = false;

        protected Camera camera;
        protected GraphicsDevice graphicsDevice;

        protected override void OnInitialize()
        {
            camera = Stage.Camera;
            graphicsDevice = Stage.GraphicsDevice;
        }

        /// <summary>
        /// Sets all relevant fields.
        /// </summary>
        /// <param name="tsc">Reference to the Control this Component is on.</param>
        /// <param name="mapWidth">The width of the displayed map.</param>
        /// <param name="mapHeight">The height of the displayed map.</param>
        public virtual void Set(BaseControl<T> tsc, int mapWidth, int mapHeight)
        {
            this.baseControl = tsc;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

        /// <summary>
        /// Called when the mouse wheel scrolled upwards.
        /// </summary>
        public virtual void OnMouseWheelUpwards(MouseEventArgs e)
        {
            Stage.Camera.AdjustZoom(0.25f);
        }

        /// <summary>
        /// Called when the mouse wheel scrolled downwards.
        /// </summary>
        public virtual void OnMouseWheelDownwards(MouseEventArgs e)
        {
            Stage.Camera.AdjustZoom(-0.25f);
        }

        /// <summary>
        /// Called when the mouse button was clicked.
        /// </summary>
        public virtual void OnMouseClick(MouseEventArgs e)
        {
        }

        /// <summary>
        /// Called when a mouse button was released.
        /// </summary>
        public virtual void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                camMouseDown = false;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (clickable != null && MouseMovedTooFar(e) == false)
                    clickable.Click();
            }
            else if (e.Button == MouseButtons.Right)
                clickable.SecondaryClick();
        }

        /// <summary>
        /// Called when a mouse button was pressed.
        /// </summary>
        public virtual void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                StartScrolling(e);
            else if (e.Button == MouseButtons.Left)
                RecordMouseClick(e);
        }

        /// <summary>
        /// Checks to see if the mouse moved to far, for a press to be recognized.
        /// </summary>
        /// <returns>If the mouse moved too far.</returns>
        protected bool MouseMovedTooFar(MouseEventArgs e)
        {
            System.Drawing.Point point = new System.Drawing.Point(e.X - startMouseDown.X, e.Y - startMouseDown.Y);

            return Math.Sqrt(point.X * point.X + point.Y * point.Y) >= pixelsNeededForMove;
        }

        /// <summary>
        /// Called when a the primary button was pressed. Used to store the location
        /// of that click.
        /// </summary>
        protected virtual void RecordMouseClick(MouseEventArgs e)
        {
            startMouseDown = e.Location;
        }

        /// <summary>
        /// Called when the map should start to pan.
        /// </summary>
        protected virtual void StartScrolling(MouseEventArgs e)
        {
            camMouseDown = true;
            prevMouseDown = e.Location;
        }

        /// <summary>
        /// Called when the mouse was moved.
        /// </summary>
        public virtual void OnMouseMove(MouseEventArgs e)
        {
            if (camMouseDown) // Should the view pan?
            {
                // Get the delta coordinates from previous and current frame and move the camera by that amount.
                int xDiff = prevMouseDown.X - e.Location.X;
                int yDiff = prevMouseDown.Y - e.Location.Y;

                camera.MoveCamera(new Vector2(xDiff / Stage.Camera.Zoom, yDiff / Stage.Camera.Zoom));

                prevMouseDown.X = e.Location.X;
                prevMouseDown.Y = e.Location.Y;
            }
        }

        /// <summary>
        /// Makes sure the map is in view of the screen.
        /// </summary>
        public void Clamp() => camera.MoveCamera(new Vector2(0, 0));

        public void Update()
        {
            Viewport view = graphicsDevice.Viewport;
            if (view.Width != 0 && view.Height != 0)
            {
                camera.Set(view.Width, view.Height, mapWidth, mapHeight);
                //Console.WriteLine(view + "\n" + camera.Position);
            }
        }

        public void Dispose()
        {
            baseControl.OnMouseWheelUpwards -= OnMouseWheelUpwards;
            baseControl.OnMouseWheelDownwards -= OnMouseWheelDownwards;

        }
    }
}
