namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// A command that can be executed and undone.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Executes the event. Can be called when a redo occures.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Undoes a event. Can be called when a undo occures.
        /// </summary>
        public abstract void Undo();

        /// <summary>
        /// Wheter the command is still valid. It can become unvalid if the map
        /// that the command was for was unloaded or closed.
        /// </summary>
        /// <returns>Wheter the command is still valid.</returns>
        public abstract bool StillValid();
    }
}
