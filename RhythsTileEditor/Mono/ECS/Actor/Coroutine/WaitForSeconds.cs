using Mono.GameSystems;

namespace Mono.ECS
{
    /// <summary>
    /// Yields the coroutine for a specified amount of seconds.
    /// </summary>
    public class WaitForSeconds : YieldInstruction
    {
        private readonly float seconds;
        private float timer;

        /// <summary>
        /// Waits for given seconds.
        /// </summary>
        /// <param name="seconds">Time in seconds.</param>
        public WaitForSeconds(float seconds)
        {
            this.seconds = seconds;
        }

        public override bool IsDone(float delta)
        {
            timer += delta;
            return timer > seconds;
        }
    }
}
