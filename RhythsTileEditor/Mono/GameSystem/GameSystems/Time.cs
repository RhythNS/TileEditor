using Microsoft.Xna.Framework;
using System;

namespace Mono.GameSystems
{
    /// <summary>
    /// Class for getting information about the current time.
    /// </summary>
    public class Time : GameSystem
    {
        // Gametime of this frame
        private GameTime currentTime;

        /// <summary>
        /// Save the new GameTime to the currentTime
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            currentTime = gameTime;
            Delta = (float)currentTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Returns the time in seconds that elapsed since the previous frame.
        /// </summary>
        public float Delta { get; private set; }

        /// <summary>
        /// Returns the time elapsed since the application start.
        /// </summary>
        public TimeSpan TotalGameTime => currentTime.TotalGameTime;

        /// <summary>
        /// Returns the time since elapsed since the previous frame.
        /// </summary>
        public TimeSpan ElapsedTime => currentTime.ElapsedGameTime;
    }
}
