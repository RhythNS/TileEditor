using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands.LayerCommands
{
    /// <summary>
    /// Removes a layer from the map.
    /// </summary>
    public class LayerRemoveCommand : LayerCommand
    {
        /// <summary>
        /// The index of the layer to be removed.
        /// </summary>
        private int removeAt;
        /// <summary>
        /// A reference to the deleted layer, so it can be readded when this command is undone.
        /// </summary>
        private Layer layer;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        /// <param name="removeAt">The index of the layer to be removed.</param>
        public LayerRemoveCommand(Map map, int removeAt) : base(map)
        {
            this.removeAt = removeAt;
            layer = map.layers[removeAt];
        }

        public override void Execute()
        {
            map.layers.RemoveAt(removeAt);
            MainForm.Instance.UpdateLayers();
        }

        public override void Undo()
        {
            map.layers.Insert(removeAt, layer);
            MainForm.Instance.UpdateLayers();
        }
    }
}
