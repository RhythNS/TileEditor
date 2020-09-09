using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands.LayerCommands
{
    /// <summary>
    /// Toggles visiblity of a layer.
    /// </summary>
    public class LayerSetVisible : LayerCommand
    {
        /// <summary>
        /// The affected layer.
        /// </summary>
        private Layer layer;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        /// <param name="layer">The layer which the invisiblity should be toggled.</param>
        public LayerSetVisible(Map map, Layer layer) : base(map)
        {
            this.layer = layer;
        }

        public override void Execute()
        {
            layer.visible = !layer.visible;
            MainForm.Instance.UpdateLayers();
        }

        public override void Undo() => Execute(); // Same as the execute method.
    }
}
