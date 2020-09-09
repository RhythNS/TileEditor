using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands.LayerCommands
{
    /// <summary>
    /// Renames a layer.
    /// </summary>
    class RenameLayerCommand : LayerCommand
    {
        /// <summary>
        /// The previous name.
        /// </summary>
        private string from;
        /// <summary>
        /// The changed name.
        /// </summary>
        private string to;
        /// <summary>
        /// The layer to be changed.
        /// </summary>
        private Layer toRename;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        /// <param name="to">The name that the layer should be renamed to.</param>
        /// <param name="toRename">The layer to be changed.</param>
        public RenameLayerCommand(Map map, string to, Layer toRename) : base(map)
        {
            from = toRename.name;
            this.to = to;
            this.toRename = toRename;
        }

        public override void Execute()
        {
            toRename.name = to;
            MainForm.Instance.UpdateLayers();
        }

        public override void Undo()
        {
            toRename.name = from;
            MainForm.Instance.UpdateLayers();
        }
    }
}
