using RhyTiles;
using RhyTiles.Main;
using RhyTiles.MapControls;
using System.Collections.Generic;

namespace RhythsTileEditor.Mono.Components.Commands
{
    /// <summary>
    /// Base class for commands that are changing the map.
    /// </summary>
    public abstract class MapCommand : Command
    {
        /// <summary>
        /// Wheter the command must be hold or only issused when the user clicks without moving.
        /// </summary>
        public abstract bool SingleClick { get; }

        /// <summary>
        /// The map that this command affects.
        /// </summary>
        protected Map affectedMap;
        /// <summary>
        /// A list of changes that is used when the command is still executing.
        /// </summary>
        protected List<Change> changes;
        /// <summary>
        /// A list of changes that is used when the command should be undone.
        /// </summary>
        protected readonly Change[] appliedChanges;
        
        /// <summary>
        /// Helper struct for changes. A change contains the affected tile, its previous and
        /// current state.
        /// </summary>
        public struct Change
        {
            /// <summary>
            /// The affected tile.
            /// </summary>
            public Tile changedTile;
            /// <summary>
            /// The previous tilesetTile Before the change.
            /// </summary>
            public TilesetTile prev;
            /// <summary>
            /// The current TilesetTile after the change.
            /// </summary>
            public TilesetTile now;

            /// <summary>
            /// Standard constructor.
            /// </summary>
            /// <param name="changedTile">The affected tile.</param>
            /// <param name="prev">The previous tilesetTile Before the change.</param>
            /// <param name="now">The current TilesetTile after the change.</param>
            public Change(Tile changedTile, TilesetTile prev, TilesetTile now)
            {
                this.changedTile = changedTile;
                this.prev = prev;
                this.now = now;
            }
        }

        /// <summary>
        /// Constructor for when the command is meant to be executing.
        /// </summary>
        public MapCommand()
        {
            changes = new List<Change>();
        }

        /// <summary>
        /// Constructor for when a command was issued and is sent to the Commandmanager.
        /// </summary>
        /// <param name="changes">Changes made to the map.</param>
        public MapCommand(Change[] changes)
        {
            appliedChanges = changes;
            affectedMap = MapControl.Instance.Map;
        }

        /// <summary>
        /// The tileset tile that the command is changing affected tiles to.
        /// </summary>
        /// <param name="changeTo">The TilesetTile that a tile is changing to.</param>
        /// <returns>Wheter a valid replacement was found.</returns>
        protected virtual bool TryGetChangeTilesetTile(out TilesetTile changeTo)
        {
            changeTo = HighlitingTilesetTile.Instance.highlighted;

            return changeTo != null;
        }

        /// <summary>
        /// Tries to get all relevant references that the commands needs to execute.
        /// </summary>
        /// <param name="map">The map that the changes are done to.</param>
        /// <param name="changeTo">The TilesetTile that the change will change the tile to.</param>
        /// <param name="tile">The affected tile.</param>
        /// <returns>Wheter all references were set.</returns>
        protected bool TryGetTiles(out Map map, out TilesetTile changeTo, out Tile tile)
        {
            map = null;
            tile = null;

            if (TryGetChangeTilesetTile(out changeTo) == false)
                return false;

            MapControl mc = MapControl.Instance;
            if ((map = mc.Map) == null)
                return false;

            tile = mc.GetTileFromMousePosition();
            if (tile == null)
                return false;

            return true;
        }

        /// <summary>
        /// Called when a command is not single click and new information is put onto the command.
        /// </summary>
        public virtual void Add() { }

        /// <summary>
        /// Applies all changes that were made.
        /// </summary>
        public virtual void Apply()
        {
            if (changes.Count == 0)
                return;

            CommandManager.Add(new DrawCommand(changes.ToArray()));
            changes.Clear();
        }

        public override void Execute()
        {
            foreach (Change change in appliedChanges)
                change.changedTile.referencedTile = change.now;
        }

        public override void Undo()
        {
            foreach (Change change in appliedChanges)
                change.changedTile.referencedTile = change.prev;
        }

        public override bool StillValid() => Globals.loadedMaps.Contains(affectedMap);
    }
}
