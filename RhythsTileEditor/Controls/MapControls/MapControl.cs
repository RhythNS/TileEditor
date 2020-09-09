using Mono.ECS;
using Mono.ECS.Components;
using RhythsTileEditor.Controls;
using RhythsTileEditor.Mono.Components;
using RhythsTileEditor.Mono.Components.Commands;

namespace RhyTiles.MapControls
{
    /// <summary>
    /// Viewer Control for maps.
    /// </summary>
    public class MapControl : BaseControl<Tile>
    {
        public static MapControl Instance { get; private set; }

        /// <summary>
        /// Wheter an undo is currently allowed.
        /// </summary>
        public bool CanUndo => ((MapEditorMouseControl)mcc).Drawing == false;
        /// <summary>
        /// Which layer currently is selected.
        /// </summary>
        public int SelectedLayer { get; private set; } = 0;
        /// <summary>
        /// Which map is currently being edited.
        /// </summary>
        public Map Map { get; private set; }
        /// <summary>
        /// Component to draw the map.
        /// </summary>
        private RhyTileMapDrawComponent rtm;

        /// <summary>
        /// Try and set the map. Can return false if an error occurred.
        /// </summary>
        /// <param name="map">The new map.</param>
        /// <returns>Wheter it successeded or not.</returns>
        public bool TrySetMap(Map map)
        {
            this.Map = map;
            rtm.map = map;

            if (map == null)
                return true;

            mcc.Set(this, map.tileWidth * map.xSize, map.tileHeight * map.ySize);
            ((HighlitingNormalTile)htt).Set(map.layers[0]);

            mcc.Clamp();

            return true;
        }

        /// <summary>
        /// Gets the tile that the mouse is currently on top of.
        /// </summary>
        /// <returns></returns>
        public Tile GetTileFromMousePosition() => htt.GetTileFromMousePosition();

        protected override void Initialize()
        {
            base.Initialize();
            Instance = this;

            Actor drawActor = Stage.CreateActor(0);
            drawActor.AddComponent<Transform2>();
            rtm = drawActor.AddComponent<RhyTileMapDrawComponent>();
        }

        /// <summary>
        /// Changes the current selected layer.
        /// </summary>
        /// <param name="index">The index of the newly selected layer.</param>
        public void ChangeLayer(int index)
        {
            SelectedLayer = index;
            if (Map != null && index > -1 && index < Map.layers.Count)
                ((HighlitingNormalTile)htt).Set(Map.layers[index]);
        }

        /// <summary>
        /// Sets a tool as a command.
        /// </summary>
        /// <param name="command">The new tool that is currently selected.</param>
        public void SetCommand(MapCommand command)
            => ((MapEditorMouseControl)mcc).selectedCommand = command;

        /// <summary>
        /// Adds a tileset to the viewer.
        /// </summary>
        /// <param name="tileset">The tileset to be added</param>
        public void AddTileset(Tileset tileset)
            => rtm.TryAddTileset(tileset, out _);

        /// <summary>
        /// Removes a tileset from the viewer.
        /// </summary>
        /// <param name="tileset">The tileset to be removed.</param>
        public void RemoveTileset(Tileset tileset)
            => rtm.RemoveTileset(tileset);

        protected override HighlitingTile<Tile> AddHighlitingTile(Actor toPlaceOn)
            => toPlaceOn.AddComponent<HighlitingNormalTile>();

        protected override MouseControlComponent<Tile> AddMouseControl(Actor toPlaceOn)
            => toPlaceOn.AddComponent<MapEditorMouseControl>();
    }
}
