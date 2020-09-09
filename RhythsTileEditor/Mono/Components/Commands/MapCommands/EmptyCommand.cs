using System.Windows.Forms;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Empty command when no tool is selected.
    /// </summary>
    public class EmptyCommand : MapCommand
    {
        public EmptyCommand()
        {
        }

        public EmptyCommand(Change[] changes) : base(changes)
        {
        }

        public override bool SingleClick => true;

        public override void Apply()
        {
        }

        public override void Add()
        {

        }

        public override void Execute()
        {
        }

        public override void Undo()
        {
        }

        public override bool StillValid() => false;
    }
}
