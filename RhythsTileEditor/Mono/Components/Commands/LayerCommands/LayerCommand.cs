using RhyTiles;
using RhyTiles.Main;

namespace RhythsTileEditor.Mono.Components.Commands.LayerCommands
{
    /// <summary>
    /// Commands that affect a layer.
    /// </summary>
    public abstract class LayerCommand : Command
    {
        /// <summary>
        /// The affected map.
        /// </summary>
        protected Map map;

        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="map">The affected map.</param>
        public LayerCommand(Map map)
        {
            this.map = map;
        }

        public override bool StillValid() => Globals.loadedMaps.Contains(map);
    }
}
