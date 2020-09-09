using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands.LayerCommands
{
    /// <summary>
    /// Adds a layer to a map.
    /// </summary>
    public class LayerAddCommand : LayerCommand
    {
        /// <summary>
        /// A reference to the added layer.
        /// </summary>
        private Layer layer;
        /// <summary>
        /// The name of the layer that should be added.
        /// </summary>
        string name;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        /// <param name="name">The name of the new layer.</param>
        public LayerAddCommand(Map map, string name) : base(map)
        {
            this.name = name;
        }

        public override void Execute()
        {
            // layer might have been undone and redone.
            if (layer == null)
                layer = new Layer(name, map);
            map.layers.Add(layer);
            MainForm.Instance.UpdateLayers();
        }

        public override void Undo()
        {
            map.layers.Remove(layer);
            MainForm.Instance.UpdateLayers();
        }
    }
}
