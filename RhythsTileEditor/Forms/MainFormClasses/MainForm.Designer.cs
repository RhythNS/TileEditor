namespace RhyTiles
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyOpenedMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyOpenedTilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.rightSideTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.createLayerButton = new System.Windows.Forms.ToolStripButton();
            this.deleteLayerButton = new System.Windows.Forms.ToolStripButton();
            this.layerRenameButton = new System.Windows.Forms.ToolStripButton();
            this.layerSetVisibleButton = new System.Windows.Forms.ToolStripButton();
            this.moveLayerUp = new System.Windows.Forms.ToolStripButton();
            this.moveLayerDown = new System.Windows.Forms.ToolStripButton();
            this.tilesetControl = new RhyTiles.Controls.TilesetControls.TileSetControl();
            this.tilesetTabControl = new System.Windows.Forms.TabControl();
            this.tilesetTools = new System.Windows.Forms.ToolStrip();
            this.tilesetCreateNewButton = new System.Windows.Forms.ToolStripButton();
            this.tilesetLoadButton = new System.Windows.Forms.ToolStripButton();
            this.tilesetSaveButton = new System.Windows.Forms.ToolStripButton();
            this.tilesetSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.tilesetCloseButton = new System.Windows.Forms.ToolStripButton();
            this.layerListBox = new System.Windows.Forms.ListBox();
            this.mapTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mapToolStrip = new System.Windows.Forms.ToolStrip();
            this.mapCreateNewButton = new System.Windows.Forms.ToolStripButton();
            this.mapLoadButton = new System.Windows.Forms.ToolStripButton();
            this.mapSaveButton = new System.Windows.Forms.ToolStripButton();
            this.mapSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.mapCloseButton = new System.Windows.Forms.ToolStripButton();
            this.mapSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mapBrushButton = new System.Windows.Forms.ToolStripButton();
            this.mapDeleteTileButton = new System.Windows.Forms.ToolStripButton();
            this.mapFillButton = new System.Windows.Forms.ToolStripButton();
            this.mapToolsSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mapUndoButton = new System.Windows.Forms.ToolStripButton();
            this.mapRedoButton = new System.Windows.Forms.ToolStripButton();
            this.mainMapControl = new RhyTiles.MapControls.MapControl();
            this.mapTabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.mainTableLayout.SuspendLayout();
            this.rightSideTablePanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tilesetTools.SuspendLayout();
            this.mapTableLayoutPanel.SuspendLayout();
            this.mapToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.recentlyOpenedMapsToolStripMenuItem,
            this.recentlyOpenedTilesetsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // recentlyOpenedMapsToolStripMenuItem
            // 
            this.recentlyOpenedMapsToolStripMenuItem.Name = "recentlyOpenedMapsToolStripMenuItem";
            this.recentlyOpenedMapsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recentlyOpenedMapsToolStripMenuItem.Text = "Recent Maps";
            // 
            // recentlyOpenedTilesetsToolStripMenuItem
            // 
            this.recentlyOpenedTilesetsToolStripMenuItem.Name = "recentlyOpenedTilesetsToolStripMenuItem";
            this.recentlyOpenedTilesetsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recentlyOpenedTilesetsToolStripMenuItem.Text = "Recent Tilesets";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.OnUndo);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.OnRedo);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.ConfigToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayout.AutoSize = true;
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.72727F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.Controls.Add(this.rightSideTablePanel, 1, 0);
            this.mainTableLayout.Controls.Add(this.mapTableLayoutPanel, 0, 0);
            this.mainTableLayout.Location = new System.Drawing.Point(0, 27);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 1;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Size = new System.Drawing.Size(1246, 835);
            this.mainTableLayout.TabIndex = 2;
            // 
            // rightSideTablePanel
            // 
            this.rightSideTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightSideTablePanel.ColumnCount = 1;
            this.rightSideTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightSideTablePanel.Controls.Add(this.toolStrip1, 0, 1);
            this.rightSideTablePanel.Controls.Add(this.tilesetControl, 0, 3);
            this.rightSideTablePanel.Controls.Add(this.tilesetTabControl, 0, 2);
            this.rightSideTablePanel.Controls.Add(this.tilesetTools, 0, 4);
            this.rightSideTablePanel.Controls.Add(this.layerListBox, 0, 0);
            this.rightSideTablePanel.Location = new System.Drawing.Point(909, 3);
            this.rightSideTablePanel.Name = "rightSideTablePanel";
            this.rightSideTablePanel.RowCount = 5;
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightSideTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightSideTablePanel.Size = new System.Drawing.Size(334, 829);
            this.rightSideTablePanel.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLayerButton,
            this.deleteLayerButton,
            this.layerRenameButton,
            this.layerSetVisibleButton,
            this.moveLayerUp,
            this.moveLayerDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 381);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(334, 20);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createLayerButton
            // 
            this.createLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("createLayerButton.Image")));
            this.createLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createLayerButton.Name = "createLayerButton";
            this.createLayerButton.Size = new System.Drawing.Size(23, 17);
            this.createLayerButton.Text = "Add Layer";
            this.createLayerButton.Click += new System.EventHandler(this.CreateLayerButton_Click);
            // 
            // deleteLayerButton
            // 
            this.deleteLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteLayerButton.Image")));
            this.deleteLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteLayerButton.Name = "deleteLayerButton";
            this.deleteLayerButton.Size = new System.Drawing.Size(23, 17);
            this.deleteLayerButton.Text = "Remove Layer";
            this.deleteLayerButton.Click += new System.EventHandler(this.DeleteLayerButton_Click);
            // 
            // layerRenameButton
            // 
            this.layerRenameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerRenameButton.Image = ((System.Drawing.Image)(resources.GetObject("layerRenameButton.Image")));
            this.layerRenameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerRenameButton.Name = "layerRenameButton";
            this.layerRenameButton.Size = new System.Drawing.Size(23, 17);
            this.layerRenameButton.Text = "Rename Layer";
            this.layerRenameButton.Click += new System.EventHandler(this.LayerRenameButton_Click);
            // 
            // layerSetVisibleButton
            // 
            this.layerSetVisibleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerSetVisibleButton.Image = ((System.Drawing.Image)(resources.GetObject("layerSetVisibleButton.Image")));
            this.layerSetVisibleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerSetVisibleButton.Name = "layerSetVisibleButton";
            this.layerSetVisibleButton.Size = new System.Drawing.Size(23, 17);
            this.layerSetVisibleButton.Text = "Toggle Visiblity";
            this.layerSetVisibleButton.Click += new System.EventHandler(this.LayerSetVisibleButton_Click);
            // 
            // moveLayerUp
            // 
            this.moveLayerUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLayerUp.Image = ((System.Drawing.Image)(resources.GetObject("moveLayerUp.Image")));
            this.moveLayerUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveLayerUp.Name = "moveLayerUp";
            this.moveLayerUp.Size = new System.Drawing.Size(23, 17);
            this.moveLayerUp.Text = "Move Layer Up";
            this.moveLayerUp.Click += new System.EventHandler(this.MoveLayerUp_Click);
            // 
            // moveLayerDown
            // 
            this.moveLayerDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLayerDown.Image = ((System.Drawing.Image)(resources.GetObject("moveLayerDown.Image")));
            this.moveLayerDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveLayerDown.Name = "moveLayerDown";
            this.moveLayerDown.Size = new System.Drawing.Size(23, 17);
            this.moveLayerDown.Text = "Move Layer Down";
            this.moveLayerDown.Click += new System.EventHandler(this.MoveLayerDown_Click);
            // 
            // tilesetControl
            // 
            this.tilesetControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetControl.Location = new System.Drawing.Point(3, 430);
            this.tilesetControl.MouseHoverUpdatesOnly = false;
            this.tilesetControl.Name = "tilesetControl";
            this.tilesetControl.Size = new System.Drawing.Size(328, 375);
            this.tilesetControl.TabIndex = 2;
            this.tilesetControl.Text = "tilesetControl";
            // 
            // tilesetTabControl
            // 
            this.tilesetTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetTabControl.Location = new System.Drawing.Point(3, 404);
            this.tilesetTabControl.Name = "tilesetTabControl";
            this.tilesetTabControl.SelectedIndex = 0;
            this.tilesetTabControl.Size = new System.Drawing.Size(328, 20);
            this.tilesetTabControl.TabIndex = 0;
            this.tilesetTabControl.SelectedIndexChanged += new System.EventHandler(this.TilesetTabControl_SelectedIndexChanged);
            // 
            // tilesetTools
            // 
            this.tilesetTools.AllowMerge = false;
            this.tilesetTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetTools.Dock = System.Windows.Forms.DockStyle.None;
            this.tilesetTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tilesetTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetCreateNewButton,
            this.tilesetLoadButton,
            this.tilesetSaveButton,
            this.tilesetSaveAsButton,
            this.tilesetCloseButton});
            this.tilesetTools.Location = new System.Drawing.Point(0, 808);
            this.tilesetTools.Name = "tilesetTools";
            this.tilesetTools.Size = new System.Drawing.Size(334, 21);
            this.tilesetTools.TabIndex = 1;
            this.tilesetTools.Text = "tilesetTools";
            // 
            // tilesetCreateNewButton
            // 
            this.tilesetCreateNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tilesetCreateNewButton.Image = ((System.Drawing.Image)(resources.GetObject("tilesetCreateNewButton.Image")));
            this.tilesetCreateNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetCreateNewButton.Name = "tilesetCreateNewButton";
            this.tilesetCreateNewButton.Size = new System.Drawing.Size(23, 18);
            this.tilesetCreateNewButton.Text = "New Tileset";
            this.tilesetCreateNewButton.Click += new System.EventHandler(this.TilesetCreateNewButton_Click);
            // 
            // tilesetLoadButton
            // 
            this.tilesetLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tilesetLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("tilesetLoadButton.Image")));
            this.tilesetLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetLoadButton.Name = "tilesetLoadButton";
            this.tilesetLoadButton.Size = new System.Drawing.Size(23, 18);
            this.tilesetLoadButton.Text = "Load Tileset";
            this.tilesetLoadButton.Click += new System.EventHandler(this.TilesetLoadButton_Click);
            // 
            // tilesetSaveButton
            // 
            this.tilesetSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tilesetSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("tilesetSaveButton.Image")));
            this.tilesetSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetSaveButton.Name = "tilesetSaveButton";
            this.tilesetSaveButton.Size = new System.Drawing.Size(23, 18);
            this.tilesetSaveButton.Text = "Save Tileset";
            this.tilesetSaveButton.Click += new System.EventHandler(this.TilesetSaveButton_Click);
            // 
            // tilesetSaveAsButton
            // 
            this.tilesetSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tilesetSaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("tilesetSaveAsButton.Image")));
            this.tilesetSaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetSaveAsButton.Name = "tilesetSaveAsButton";
            this.tilesetSaveAsButton.Size = new System.Drawing.Size(23, 18);
            this.tilesetSaveAsButton.Text = "Save Tileset As";
            this.tilesetSaveAsButton.Click += new System.EventHandler(this.TilesetSaveAsButton_Click);
            // 
            // tilesetCloseButton
            // 
            this.tilesetCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tilesetCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("tilesetCloseButton.Image")));
            this.tilesetCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetCloseButton.Name = "tilesetCloseButton";
            this.tilesetCloseButton.Size = new System.Drawing.Size(23, 18);
            this.tilesetCloseButton.Text = "Close Tileset";
            this.tilesetCloseButton.Click += new System.EventHandler(this.TilesetCloseButton_Click);
            // 
            // layerListBox
            // 
            this.layerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layerListBox.FormattingEnabled = true;
            this.layerListBox.Location = new System.Drawing.Point(3, 3);
            this.layerListBox.Name = "layerListBox";
            this.layerListBox.Size = new System.Drawing.Size(328, 368);
            this.layerListBox.TabIndex = 3;
            this.layerListBox.SelectedIndexChanged += new System.EventHandler(this.LayerListBox_SelectedIndexChanged);
            this.layerListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LayerListBox_MouseDoubleClick);
            this.layerListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayerListBox_MouseDown);
            // 
            // mapTableLayoutPanel
            // 
            this.mapTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapTableLayoutPanel.ColumnCount = 1;
            this.mapTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mapTableLayoutPanel.Controls.Add(this.mapToolStrip, 0, 0);
            this.mapTableLayoutPanel.Controls.Add(this.mainMapControl, 0, 2);
            this.mapTableLayoutPanel.Controls.Add(this.mapTabControl, 0, 1);
            this.mapTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mapTableLayoutPanel.Name = "mapTableLayoutPanel";
            this.mapTableLayoutPanel.RowCount = 3;
            this.mapTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mapTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mapTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mapTableLayoutPanel.Size = new System.Drawing.Size(900, 829);
            this.mapTableLayoutPanel.TabIndex = 7;
            // 
            // mapToolStrip
            // 
            this.mapToolStrip.AllowMerge = false;
            this.mapToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mapToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mapToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapCreateNewButton,
            this.mapLoadButton,
            this.mapSaveButton,
            this.mapSaveAsButton,
            this.mapCloseButton,
            this.mapSeperator1,
            this.mapBrushButton,
            this.mapDeleteTileButton,
            this.mapFillButton,
            this.mapToolsSeperator2,
            this.mapUndoButton,
            this.mapRedoButton});
            this.mapToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mapToolStrip.Name = "mapToolStrip";
            this.mapToolStrip.Size = new System.Drawing.Size(900, 20);
            this.mapToolStrip.TabIndex = 6;
            this.mapToolStrip.Text = "toolStrip1";
            // 
            // mapCreateNewButton
            // 
            this.mapCreateNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapCreateNewButton.Image = ((System.Drawing.Image)(resources.GetObject("mapCreateNewButton.Image")));
            this.mapCreateNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapCreateNewButton.Name = "mapCreateNewButton";
            this.mapCreateNewButton.Size = new System.Drawing.Size(23, 17);
            this.mapCreateNewButton.Text = "New Map";
            this.mapCreateNewButton.Click += new System.EventHandler(this.MapCreateNewButton_Click);
            // 
            // mapLoadButton
            // 
            this.mapLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("mapLoadButton.Image")));
            this.mapLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapLoadButton.Name = "mapLoadButton";
            this.mapLoadButton.Size = new System.Drawing.Size(23, 17);
            this.mapLoadButton.Text = "Load Map";
            this.mapLoadButton.Click += new System.EventHandler(this.MapLoadButton_Click);
            // 
            // mapSaveButton
            // 
            this.mapSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("mapSaveButton.Image")));
            this.mapSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapSaveButton.Name = "mapSaveButton";
            this.mapSaveButton.Size = new System.Drawing.Size(23, 17);
            this.mapSaveButton.Text = "Save Map";
            this.mapSaveButton.Click += new System.EventHandler(this.MapSaveButton_Click);
            // 
            // mapSaveAsButton
            // 
            this.mapSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapSaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("mapSaveAsButton.Image")));
            this.mapSaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapSaveAsButton.Name = "mapSaveAsButton";
            this.mapSaveAsButton.Size = new System.Drawing.Size(23, 17);
            this.mapSaveAsButton.Text = "Save Map As";
            this.mapSaveAsButton.Click += new System.EventHandler(this.MapSaveAsButton_Click);
            // 
            // mapCloseButton
            // 
            this.mapCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapCloseButton.Image = ((System.Drawing.Image)(resources.GetObject("mapCloseButton.Image")));
            this.mapCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapCloseButton.Name = "mapCloseButton";
            this.mapCloseButton.Size = new System.Drawing.Size(23, 17);
            this.mapCloseButton.Text = "Close Map";
            this.mapCloseButton.Click += new System.EventHandler(this.MapCloseButton_Click);
            // 
            // mapSeperator1
            // 
            this.mapSeperator1.Name = "mapSeperator1";
            this.mapSeperator1.Size = new System.Drawing.Size(6, 20);
            // 
            // mapBrushButton
            // 
            this.mapBrushButton.Checked = true;
            this.mapBrushButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapBrushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapBrushButton.Image = ((System.Drawing.Image)(resources.GetObject("mapBrushButton.Image")));
            this.mapBrushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapBrushButton.Name = "mapBrushButton";
            this.mapBrushButton.Size = new System.Drawing.Size(23, 17);
            this.mapBrushButton.Text = "Brush Tool";
            this.mapBrushButton.Click += new System.EventHandler(this.MapBrushButton_Click);
            // 
            // mapDeleteTileButton
            // 
            this.mapDeleteTileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapDeleteTileButton.Image = ((System.Drawing.Image)(resources.GetObject("mapDeleteTileButton.Image")));
            this.mapDeleteTileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapDeleteTileButton.Name = "mapDeleteTileButton";
            this.mapDeleteTileButton.Size = new System.Drawing.Size(23, 17);
            this.mapDeleteTileButton.Text = "Eraser Tool";
            this.mapDeleteTileButton.Click += new System.EventHandler(this.mapDeleteTileButton_Click);
            // 
            // mapFillButton
            // 
            this.mapFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapFillButton.Image = ((System.Drawing.Image)(resources.GetObject("mapFillButton.Image")));
            this.mapFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapFillButton.Name = "mapFillButton";
            this.mapFillButton.Size = new System.Drawing.Size(23, 17);
            this.mapFillButton.Text = "Flood Fill Tool";
            this.mapFillButton.Click += new System.EventHandler(this.mapFillButton_Click);
            // 
            // mapToolsSeperator2
            // 
            this.mapToolsSeperator2.Name = "mapToolsSeperator2";
            this.mapToolsSeperator2.Size = new System.Drawing.Size(6, 20);
            // 
            // mapUndoButton
            // 
            this.mapUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapUndoButton.Enabled = false;
            this.mapUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("mapUndoButton.Image")));
            this.mapUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapUndoButton.Name = "mapUndoButton";
            this.mapUndoButton.Size = new System.Drawing.Size(23, 17);
            this.mapUndoButton.Text = "Undo";
            this.mapUndoButton.Click += new System.EventHandler(this.OnUndo);
            // 
            // mapRedoButton
            // 
            this.mapRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapRedoButton.Enabled = false;
            this.mapRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("mapRedoButton.Image")));
            this.mapRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapRedoButton.Name = "mapRedoButton";
            this.mapRedoButton.Size = new System.Drawing.Size(23, 17);
            this.mapRedoButton.Text = "Redo";
            this.mapRedoButton.Click += new System.EventHandler(this.OnRedo);
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(3, 49);
            this.mainMapControl.MouseHoverUpdatesOnly = false;
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.Size = new System.Drawing.Size(894, 777);
            this.mainMapControl.TabIndex = 4;
            this.mainMapControl.Text = "   ";
            // 
            // mapTabControl
            // 
            this.mapTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapTabControl.Location = new System.Drawing.Point(3, 23);
            this.mapTabControl.Multiline = true;
            this.mapTabControl.Name = "mapTabControl";
            this.mapTabControl.SelectedIndex = 0;
            this.mapTabControl.Size = new System.Drawing.Size(894, 20);
            this.mapTabControl.TabIndex = 5;
            this.mapTabControl.SelectedIndexChanged += new System.EventHandler(this.MapTabControl_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 862);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Rhyth\'s TileEditor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTableLayout.ResumeLayout(false);
            this.rightSideTablePanel.ResumeLayout(false);
            this.rightSideTablePanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tilesetTools.ResumeLayout(false);
            this.tilesetTools.PerformLayout();
            this.mapTableLayoutPanel.ResumeLayout(false);
            this.mapTableLayoutPanel.PerformLayout();
            this.mapToolStrip.ResumeLayout(false);
            this.mapToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private MapControls.MapControl mainMapControl;
        private System.Windows.Forms.TableLayoutPanel rightSideTablePanel;
        private Controls.TilesetControls.TileSetControl tilesetControl;
        private System.Windows.Forms.TabControl tilesetTabControl;
        private System.Windows.Forms.ToolStrip tilesetTools;
        private System.Windows.Forms.ToolStripButton tilesetCreateNewButton;
        private System.Windows.Forms.ToolStripButton tilesetLoadButton;
        private System.Windows.Forms.ToolStripButton tilesetSaveButton;
        private System.Windows.Forms.ToolStripButton tilesetSaveAsButton;
        private System.Windows.Forms.ToolStripButton tilesetCloseButton;
        private System.Windows.Forms.TableLayoutPanel mapTableLayoutPanel;
        private System.Windows.Forms.TabControl mapTabControl;
        private System.Windows.Forms.ToolStrip mapToolStrip;
        private System.Windows.Forms.ToolStripButton mapCreateNewButton;
        private System.Windows.Forms.ToolStripButton mapLoadButton;
        private System.Windows.Forms.ToolStripButton mapSaveButton;
        private System.Windows.Forms.ToolStripButton mapSaveAsButton;
        private System.Windows.Forms.ToolStripButton mapCloseButton;
        private System.Windows.Forms.ToolStripSeparator mapSeperator1;
        private System.Windows.Forms.ToolStripButton mapBrushButton;
        private System.Windows.Forms.ToolStripButton mapDeleteTileButton;
        private System.Windows.Forms.ToolStripButton mapFillButton;
        private System.Windows.Forms.ToolStripSeparator mapToolsSeperator2;
        private System.Windows.Forms.ToolStripButton mapUndoButton;
        private System.Windows.Forms.ToolStripButton mapRedoButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListBox layerListBox;
        private System.Windows.Forms.ToolStripButton createLayerButton;
        private System.Windows.Forms.ToolStripButton deleteLayerButton;
        private System.Windows.Forms.ToolStripButton layerSetVisibleButton;
        private System.Windows.Forms.ToolStripButton moveLayerUp;
        private System.Windows.Forms.ToolStripButton moveLayerDown;
        private System.Windows.Forms.ToolStripButton layerRenameButton;
        private System.Windows.Forms.ToolStripMenuItem recentlyOpenedMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentlyOpenedTilesetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
    }
}

