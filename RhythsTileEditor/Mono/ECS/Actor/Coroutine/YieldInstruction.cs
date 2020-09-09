namespace Mono.ECS
{
    /// <summary>
    /// Yield instructions for Coroutines.
    /// </summary>
    public abstract class YieldInstruction
    {
        /// <summary>
        /// Returns true when the yield instruction is finished, false when it is still running.
        /// </summary>
        /// <param name="delta">The delta time in seconds.</param>
        public abstract bool IsDone(float delta);
    }
}
