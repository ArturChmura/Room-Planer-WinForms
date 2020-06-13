namespace WinFormsLab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addFurnitureGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.coffee_table = new System.Windows.Forms.Button();
            this.double_bed = new System.Windows.Forms.Button();
            this.sofa = new System.Windows.Forms.Button();
            this.wall = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.Button();
            this.createdGroupBox = new System.Windows.Forms.GroupBox();
            this.createdListView = new System.Windows.Forms.ListView();
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBluprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konsolaDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.addFurnitureGroupBox.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.createdGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel);
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Name = "panel";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.addFurnitureGroupBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.createdGroupBox, 0, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // addFurnitureGroupBox
            // 
            resources.ApplyResources(this.addFurnitureGroupBox, "addFurnitureGroupBox");
            this.addFurnitureGroupBox.Controls.Add(this.flowLayoutPanel);
            this.addFurnitureGroupBox.Name = "addFurnitureGroupBox";
            this.addFurnitureGroupBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel.Controls.Add(this.coffee_table);
            this.flowLayoutPanel.Controls.Add(this.double_bed);
            this.flowLayoutPanel.Controls.Add(this.sofa);
            this.flowLayoutPanel.Controls.Add(this.wall);
            this.flowLayoutPanel.Controls.Add(this.table);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // coffee_table
            // 
            resources.ApplyResources(this.coffee_table, "coffee_table");
            this.coffee_table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.coffee_table.Name = "coffee_table";
            this.coffee_table.UseVisualStyleBackColor = true;
            this.coffee_table.Click += new System.EventHandler(this.button_Click);
            // 
            // double_bed
            // 
            resources.ApplyResources(this.double_bed, "double_bed");
            this.double_bed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.double_bed.Name = "double_bed";
            this.double_bed.UseVisualStyleBackColor = true;
            this.double_bed.Click += new System.EventHandler(this.button_Click);
            // 
            // sofa
            // 
            resources.ApplyResources(this.sofa, "sofa");
            this.sofa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sofa.Name = "sofa";
            this.sofa.UseVisualStyleBackColor = true;
            this.sofa.Click += new System.EventHandler(this.button_Click);
            // 
            // wall
            // 
            resources.ApplyResources(this.wall, "wall");
            this.wall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wall.Name = "wall";
            this.wall.UseVisualStyleBackColor = true;
            this.wall.Click += new System.EventHandler(this.button_Click);
            // 
            // table
            // 
            resources.ApplyResources(this.table, "table");
            this.table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.table.Name = "table";
            this.table.UseVisualStyleBackColor = true;
            this.table.Click += new System.EventHandler(this.button_Click);
            // 
            // createdGroupBox
            // 
            resources.ApplyResources(this.createdGroupBox, "createdGroupBox");
            this.createdGroupBox.Controls.Add(this.createdListView);
            this.createdGroupBox.Name = "createdGroupBox";
            this.createdGroupBox.TabStop = false;
            // 
            // createdListView
            // 
            resources.ApplyResources(this.createdListView, "createdListView");
            this.createdListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemName,
            this.location});
            this.createdListView.HideSelection = false;
            this.createdListView.Name = "createdListView";
            this.createdListView.UseCompatibleStateImageBehavior = false;
            this.createdListView.View = System.Windows.Forms.View.Details;
            this.createdListView.SelectedIndexChanged += new System.EventHandler(this.createdListView_SelectedIndexChanged);
            // 
            // itemName
            // 
            resources.ApplyResources(this.itemName, "itemName");
            // 
            // location
            // 
            resources.ApplyResources(this.location, "location");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBluprintToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.saveBlueprintToolStripMenuItem,
            this.openBlueprintToolStripMenuItem,
            this.opcjeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newBluprintToolStripMenuItem
            // 
            this.newBluprintToolStripMenuItem.Name = "newBluprintToolStripMenuItem";
            resources.ApplyResources(this.newBluprintToolStripMenuItem, "newBluprintToolStripMenuItem");
            this.newBluprintToolStripMenuItem.Click += new System.EventHandler(this.newBluprintToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.polishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            resources.ApplyResources(this.polishToolStripMenuItem, "polishToolStripMenuItem");
            this.polishToolStripMenuItem.Click += new System.EventHandler(this.polishToolStripMenuItem_Click);
            // 
            // saveBlueprintToolStripMenuItem
            // 
            this.saveBlueprintToolStripMenuItem.Name = "saveBlueprintToolStripMenuItem";
            resources.ApplyResources(this.saveBlueprintToolStripMenuItem, "saveBlueprintToolStripMenuItem");
            this.saveBlueprintToolStripMenuItem.Click += new System.EventHandler(this.saveBlueprintToolStripMenuItem_Click);
            // 
            // openBlueprintToolStripMenuItem
            // 
            this.openBlueprintToolStripMenuItem.Name = "openBlueprintToolStripMenuItem";
            resources.ApplyResources(this.openBlueprintToolStripMenuItem, "openBlueprintToolStripMenuItem");
            this.openBlueprintToolStripMenuItem.Click += new System.EventHandler(this.openBlueprintToolStripMenuItem_Click);
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konsolaDebugToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            resources.ApplyResources(this.opcjeToolStripMenuItem, "opcjeToolStripMenuItem");
            // 
            // konsolaDebugToolStripMenuItem
            // 
            this.konsolaDebugToolStripMenuItem.Name = "konsolaDebugToolStripMenuItem";
            resources.ApplyResources(this.konsolaDebugToolStripMenuItem, "konsolaDebugToolStripMenuItem");
            this.konsolaDebugToolStripMenuItem.Click += new System.EventHandler(this.konsolaDebugToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.addFurnitureGroupBox.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.createdGroupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBluprintToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox addFurnitureGroupBox;
        private System.Windows.Forms.GroupBox createdGroupBox;
        private System.Windows.Forms.ListView createdListView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button coffee_table;
        private System.Windows.Forms.Button double_bed;
        private System.Windows.Forms.Button sofa;
        private System.Windows.Forms.Button wall;
        private System.Windows.Forms.Button table;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader location;
        private System.Windows.Forms.ToolStripMenuItem saveBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konsolaDebugToolStripMenuItem;
    }
}

