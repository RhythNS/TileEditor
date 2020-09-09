using System.Collections.Generic;

namespace RhythsTileEditor.Mono.Components.Commands
{
    public delegate void CommandsAvailable(bool undoAvailable, bool redoAvailable);

    /// <summary>
    /// Holds and manages commands that were made application wide.
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// Wheter a command can be undone.
        /// </summary>
        public static bool UndoAvailable => pointerAt > -1;
        /// <summary>
        /// Wheter a command can be redone.
        /// </summary>
        public static bool RedoAvailable => pointerAt < commandList.Count - 1;

        /// <summary>
        /// Event notifies subscribers wheter an undo and redo is available. 
        /// </summary>
        public static event CommandsAvailable CommandsAvailable;

        /// <summary>
        /// A list of all current commands.
        /// </summary>
        public static List<Command> commandList = new List<Command>();

        /// <summary>
        /// A pointer to the current done command.
        /// </summary>
        private static int pointerAt = -1;

        /// <summary>
        /// Adds a command to the manager.
        /// </summary>
        /// <param name="command">The command to be added.</param>
        /// <param name="execute">Wheter the command should be excuted.</param>
        public static void Add(Command command, bool execute = false)
        {
            if (execute == true)
                command.Execute();

            // If the pointer is not at the last index, all past commands can be discarded.
            if (pointerAt != commandList.Count - 1)
            {
                int removeFrom = pointerAt + 1;
                int removeCount = commandList.Count - removeFrom;
                commandList.RemoveRange(removeFrom, removeCount);
            }
            // Add the command and increment the pointer
            commandList.Add(command);
            ++pointerAt;

            OnCommandsChanged();
        }

        /// <summary>
        /// Checks if each command is still valid for undo or redo.
        /// </summary>
        public static void Validate()
        {
            for (int i = commandList.Count - 1; i > -1; i--)
            {
                if (commandList[i].StillValid() == true)
                    continue;

                // if the command is not valid remove the command and decrement the pointer
                // only when the command was before or at the command where the pointer is pointing to.
                commandList.RemoveAt(i);
                if (pointerAt >= i)
                    --pointerAt;
            }

            OnCommandsChanged();
        }

        /// <summary>
        /// Undoes the last executed command.
        /// </summary>
        public static void Undo()
        {
            if (UndoAvailable == false)
                return;

            commandList[pointerAt--].Undo();

            OnCommandsChanged();
        }

        /// <summary>
        /// Redoes the last undid command.
        /// </summary>
        public static void Redo()
        {
            if (RedoAvailable == false)
                return;

            commandList[++pointerAt].Execute();

            OnCommandsChanged();
        }

        private static void OnCommandsChanged() => CommandsAvailable?.Invoke(UndoAvailable, RedoAvailable);
    }
}
