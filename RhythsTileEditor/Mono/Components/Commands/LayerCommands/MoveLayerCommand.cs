using RhythsTileEditor.Mono.Components.Commands.LayerCommands;
using RhyTiles;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Moves a layer up or down.
    /// </summary>
    public class MoveLayerCommand : LayerCommand
    {
        /// <summary>
        /// Wheter the layer should move up or down.
        /// </summary>
        private bool up;
        /// <summary>
        /// The index of the layer to be moved.
        /// </summary>
        private int layer;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        /// <param name="up">Wheter the layer should move up or down.</param>
        /// <param name="layer">The index of the layer to be moved.</param>
        public MoveLayerCommand(Map map, bool up, int layer) : base(map)
        {
            this.up = up;
            this.layer = layer;
        }

        public override void Execute()
        {
            if (up == true)
                Swap(layer, layer + 1);
            else
                Swap(layer, layer - 1);
            MainForm.Instance.UpdateLayers(up);
        }

        public override void Undo() => Execute();

        /// <summary>
        /// Swaps two layers of a map.
        /// </summary>
        /// <param name="from">The index of the first element.</param>
        /// <param name="to">The index of the second element.</param>
        private void Swap(int from, int to)
        {
            Layer tmp = map.layers[from];
            map.layers[from] = map.layers[to];
            map.layers[to] = tmp;
        }
    }
}
