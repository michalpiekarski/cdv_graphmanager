namespace MPGraphsGUI
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graphListControls = new System.Windows.Forms.GroupBox();
            this.deleteGraphButton = new System.Windows.Forms.Button();
            this.addGraphButton = new System.Windows.Forms.Button();
            this.graphList = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.editTab = new System.Windows.Forms.TabPage();
            this.generateCompleteRandomButton = new System.Windows.Forms.Button();
            this.generateRandomButton = new System.Windows.Forms.Button();
            this.showNeighboursButton = new System.Windows.Forms.Button();
            this.matrixOutput = new System.Windows.Forms.TextBox();
            this.graphTypeLabel = new System.Windows.Forms.Label();
            this.graphNameLabel = new System.Windows.Forms.Label();
            this.removeEdgeButton = new System.Windows.Forms.Button();
            this.removeVertexButton = new System.Windows.Forms.Button();
            this.addEdgeButton = new System.Windows.Forms.Button();
            this.addVertexButton = new System.Windows.Forms.Button();
            this.edgeCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edgeList = new System.Windows.Forms.ListView();
            this.vertexCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drawTab = new System.Windows.Forms.TabPage();
            this.analyzeTab = new System.Windows.Forms.TabPage();
            this.checkPathsButton = new System.Windows.Forms.Button();
            this.BFSButton = new System.Windows.Forms.Button();
            this.DFSButton = new System.Windows.Forms.Button();
            this.EulerButton = new System.Windows.Forms.Button();
            this.searchMSTButton = new System.Windows.Forms.Button();
            this.checkConnectedButton = new System.Windows.Forms.Button();
            this.showLabels = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.graphListControls.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.editTab.SuspendLayout();
            this.drawTab.SuspendLayout();
            this.analyzeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.graphListControls);
            this.splitContainer1.Panel1.Controls.Add(this.graphList);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2MinSize = 500;
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // graphListControls
            // 
            this.graphListControls.AutoSize = true;
            this.graphListControls.Controls.Add(this.deleteGraphButton);
            this.graphListControls.Controls.Add(this.addGraphButton);
            this.graphListControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.graphListControls.Location = new System.Drawing.Point(0, 511);
            this.graphListControls.MinimumSize = new System.Drawing.Size(0, 50);
            this.graphListControls.Name = "graphListControls";
            this.graphListControls.Size = new System.Drawing.Size(250, 50);
            this.graphListControls.TabIndex = 1;
            this.graphListControls.TabStop = false;
            this.graphListControls.Text = "Opcje";
            // 
            // deleteGraphButton
            // 
            this.deleteGraphButton.AutoSize = true;
            this.deleteGraphButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteGraphButton.Location = new System.Drawing.Point(103, 16);
            this.deleteGraphButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.deleteGraphButton.Name = "deleteGraphButton";
            this.deleteGraphButton.Size = new System.Drawing.Size(100, 31);
            this.deleteGraphButton.TabIndex = 1;
            this.deleteGraphButton.Text = "Usuń graf";
            this.deleteGraphButton.UseVisualStyleBackColor = true;
            this.deleteGraphButton.Click += new System.EventHandler(this.deleteGraphButton_Click);
            // 
            // addGraphButton
            // 
            this.addGraphButton.AutoSize = true;
            this.addGraphButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addGraphButton.Location = new System.Drawing.Point(3, 16);
            this.addGraphButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.addGraphButton.Name = "addGraphButton";
            this.addGraphButton.Size = new System.Drawing.Size(100, 31);
            this.addGraphButton.TabIndex = 0;
            this.addGraphButton.Text = "Dodaj graf";
            this.addGraphButton.UseVisualStyleBackColor = true;
            this.addGraphButton.Click += new System.EventHandler(this.addGraphButton_Click);
            // 
            // graphList
            // 
            this.graphList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphList.Location = new System.Drawing.Point(0, 0);
            this.graphList.MultiSelect = false;
            this.graphList.Name = "graphList";
            this.graphList.Size = new System.Drawing.Size(250, 561);
            this.graphList.TabIndex = 0;
            this.graphList.UseCompatibleStateImageBehavior = false;
            this.graphList.View = System.Windows.Forms.View.List;
            this.graphList.DoubleClick += new System.EventHandler(this.graphList_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.editTab);
            this.tabControl1.Controls.Add(this.drawTab);
            this.tabControl1.Controls.Add(this.analyzeTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // editTab
            // 
            this.editTab.Controls.Add(this.generateCompleteRandomButton);
            this.editTab.Controls.Add(this.generateRandomButton);
            this.editTab.Controls.Add(this.showNeighboursButton);
            this.editTab.Controls.Add(this.matrixOutput);
            this.editTab.Controls.Add(this.graphTypeLabel);
            this.editTab.Controls.Add(this.graphNameLabel);
            this.editTab.Controls.Add(this.removeEdgeButton);
            this.editTab.Controls.Add(this.removeVertexButton);
            this.editTab.Controls.Add(this.addEdgeButton);
            this.editTab.Controls.Add(this.addVertexButton);
            this.editTab.Controls.Add(this.edgeCountLabel);
            this.editTab.Controls.Add(this.label4);
            this.editTab.Controls.Add(this.label3);
            this.editTab.Controls.Add(this.edgeList);
            this.editTab.Controls.Add(this.vertexCountLabel);
            this.editTab.Controls.Add(this.label1);
            this.editTab.Location = new System.Drawing.Point(4, 22);
            this.editTab.Name = "editTab";
            this.editTab.Padding = new System.Windows.Forms.Padding(3);
            this.editTab.Size = new System.Drawing.Size(525, 535);
            this.editTab.TabIndex = 0;
            this.editTab.Text = "Edytuj";
            this.editTab.UseVisualStyleBackColor = true;
            // 
            // generateCompleteRandomButton
            // 
            this.generateCompleteRandomButton.Location = new System.Drawing.Point(10, 418);
            this.generateCompleteRandomButton.Name = "generateCompleteRandomButton";
            this.generateCompleteRandomButton.Size = new System.Drawing.Size(121, 65);
            this.generateCompleteRandomButton.TabIndex = 15;
            this.generateCompleteRandomButton.Text = "Generuj pełny o losowym rozmiarze";
            this.generateCompleteRandomButton.UseVisualStyleBackColor = true;
            this.generateCompleteRandomButton.Click += new System.EventHandler(this.generateCompleteRandomButton_Click);
            // 
            // generateRandomButton
            // 
            this.generateRandomButton.Location = new System.Drawing.Point(10, 489);
            this.generateRandomButton.Name = "generateRandomButton";
            this.generateRandomButton.Size = new System.Drawing.Size(121, 38);
            this.generateRandomButton.TabIndex = 14;
            this.generateRandomButton.Text = "Generuj losowo";
            this.generateRandomButton.UseVisualStyleBackColor = true;
            this.generateRandomButton.Click += new System.EventHandler(this.generateRandomButton_Click);
            // 
            // showNeighboursButton
            // 
            this.showNeighboursButton.Location = new System.Drawing.Point(283, 73);
            this.showNeighboursButton.Name = "showNeighboursButton";
            this.showNeighboursButton.Size = new System.Drawing.Size(234, 23);
            this.showNeighboursButton.TabIndex = 13;
            this.showNeighboursButton.Text = "Pokaż listę sąsiadów wierzchołka";
            this.showNeighboursButton.UseVisualStyleBackColor = true;
            this.showNeighboursButton.Click += new System.EventHandler(this.showNeighboursButton_Click);
            // 
            // matrixOutput
            // 
            this.matrixOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.matrixOutput.Location = new System.Drawing.Point(137, 103);
            this.matrixOutput.MaxLength = 1000000;
            this.matrixOutput.Multiline = true;
            this.matrixOutput.Name = "matrixOutput";
            this.matrixOutput.ReadOnly = true;
            this.matrixOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.matrixOutput.Size = new System.Drawing.Size(380, 424);
            this.matrixOutput.TabIndex = 12;
            this.matrixOutput.WordWrap = false;
            // 
            // graphTypeLabel
            // 
            this.graphTypeLabel.AutoSize = true;
            this.graphTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.graphTypeLabel.Location = new System.Drawing.Point(7, 25);
            this.graphTypeLabel.Name = "graphTypeLabel";
            this.graphTypeLabel.Size = new System.Drawing.Size(60, 13);
            this.graphTypeLabel.TabIndex = 11;
            this.graphTypeLabel.Text = "GraphType";
            // 
            // graphNameLabel
            // 
            this.graphNameLabel.AutoSize = true;
            this.graphNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.graphNameLabel.Location = new System.Drawing.Point(6, 3);
            this.graphNameLabel.Name = "graphNameLabel";
            this.graphNameLabel.Size = new System.Drawing.Size(116, 22);
            this.graphNameLabel.TabIndex = 10;
            this.graphNameLabel.Text = "GraphName";
            // 
            // removeEdgeButton
            // 
            this.removeEdgeButton.Location = new System.Drawing.Point(403, 44);
            this.removeEdgeButton.Name = "removeEdgeButton";
            this.removeEdgeButton.Size = new System.Drawing.Size(114, 23);
            this.removeEdgeButton.TabIndex = 9;
            this.removeEdgeButton.Text = "Usuń krawędź";
            this.removeEdgeButton.UseVisualStyleBackColor = true;
            this.removeEdgeButton.Click += new System.EventHandler(this.removeEdgeButton_Click);
            // 
            // removeVertexButton
            // 
            this.removeVertexButton.Location = new System.Drawing.Point(283, 44);
            this.removeVertexButton.Name = "removeVertexButton";
            this.removeVertexButton.Size = new System.Drawing.Size(114, 23);
            this.removeVertexButton.TabIndex = 8;
            this.removeVertexButton.Text = "Usuń wierzchołek";
            this.removeVertexButton.UseVisualStyleBackColor = true;
            this.removeVertexButton.Click += new System.EventHandler(this.removeVertexButton_Click);
            // 
            // addEdgeButton
            // 
            this.addEdgeButton.Location = new System.Drawing.Point(403, 6);
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(114, 32);
            this.addEdgeButton.TabIndex = 7;
            this.addEdgeButton.Text = "Dodaj krawędź";
            this.addEdgeButton.UseVisualStyleBackColor = true;
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // addVertexButton
            // 
            this.addVertexButton.Location = new System.Drawing.Point(283, 6);
            this.addVertexButton.Name = "addVertexButton";
            this.addVertexButton.Size = new System.Drawing.Size(114, 32);
            this.addVertexButton.TabIndex = 6;
            this.addVertexButton.Text = "Dodaj wierzchołek";
            this.addVertexButton.UseVisualStyleBackColor = true;
            this.addVertexButton.Click += new System.EventHandler(this.addVertexButton_Click);
            // 
            // edgeCountLabel
            // 
            this.edgeCountLabel.AutoSize = true;
            this.edgeCountLabel.Location = new System.Drawing.Point(99, 356);
            this.edgeCountLabel.Name = "edgeCountLabel";
            this.edgeCountLabel.Size = new System.Drawing.Size(25, 13);
            this.edgeCountLabel.TabIndex = 5;
            this.edgeCountLabel.Text = "000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Liczba krawędzi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Krawędzie:";
            // 
            // edgeList
            // 
            this.edgeList.Location = new System.Drawing.Point(10, 103);
            this.edgeList.Name = "edgeList";
            this.edgeList.Size = new System.Drawing.Size(121, 250);
            this.edgeList.TabIndex = 2;
            this.edgeList.UseCompatibleStateImageBehavior = false;
            this.edgeList.View = System.Windows.Forms.View.List;
            // 
            // vertexCountLabel
            // 
            this.vertexCountLabel.AutoSize = true;
            this.vertexCountLabel.Location = new System.Drawing.Point(123, 64);
            this.vertexCountLabel.Name = "vertexCountLabel";
            this.vertexCountLabel.Size = new System.Drawing.Size(25, 13);
            this.vertexCountLabel.TabIndex = 1;
            this.vertexCountLabel.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liczba wierzchołków:";
            // 
            // drawTab
            // 
            this.drawTab.BackColor = System.Drawing.Color.Transparent;
            this.drawTab.Controls.Add(this.showLabels);
            this.drawTab.Location = new System.Drawing.Point(4, 22);
            this.drawTab.Name = "drawTab";
            this.drawTab.Padding = new System.Windows.Forms.Padding(3);
            this.drawTab.Size = new System.Drawing.Size(525, 535);
            this.drawTab.TabIndex = 1;
            this.drawTab.Text = "Rysuj";
            this.drawTab.Paint += new System.Windows.Forms.PaintEventHandler(this.drawTab_Paint);
            this.drawTab.Resize += new System.EventHandler(this.drawTab_Resize);
            // 
            // analyzeTab
            // 
            this.analyzeTab.Controls.Add(this.checkPathsButton);
            this.analyzeTab.Controls.Add(this.BFSButton);
            this.analyzeTab.Controls.Add(this.DFSButton);
            this.analyzeTab.Controls.Add(this.EulerButton);
            this.analyzeTab.Controls.Add(this.searchMSTButton);
            this.analyzeTab.Controls.Add(this.checkConnectedButton);
            this.analyzeTab.Location = new System.Drawing.Point(4, 22);
            this.analyzeTab.Name = "analyzeTab";
            this.analyzeTab.Size = new System.Drawing.Size(525, 535);
            this.analyzeTab.TabIndex = 2;
            this.analyzeTab.Text = "Analizuj";
            this.analyzeTab.UseVisualStyleBackColor = true;
            // 
            // checkPathsButton
            // 
            this.checkPathsButton.Location = new System.Drawing.Point(355, 83);
            this.checkPathsButton.Name = "checkPathsButton";
            this.checkPathsButton.Size = new System.Drawing.Size(162, 74);
            this.checkPathsButton.TabIndex = 7;
            this.checkPathsButton.Text = "Sprawdź średnicę, promień i centrum grafu";
            this.checkPathsButton.UseVisualStyleBackColor = true;
            this.checkPathsButton.Click += new System.EventHandler(this.checkPathsButton_Click);
            // 
            // BFSButton
            // 
            this.BFSButton.Location = new System.Drawing.Point(179, 83);
            this.BFSButton.Name = "BFSButton";
            this.BFSButton.Size = new System.Drawing.Size(170, 74);
            this.BFSButton.TabIndex = 6;
            this.BFSButton.Text = "BFS";
            this.BFSButton.UseVisualStyleBackColor = true;
            this.BFSButton.Click += new System.EventHandler(this.BFSButton_Click);
            // 
            // DFSButton
            // 
            this.DFSButton.Location = new System.Drawing.Point(179, 3);
            this.DFSButton.Name = "DFSButton";
            this.DFSButton.Size = new System.Drawing.Size(170, 74);
            this.DFSButton.TabIndex = 5;
            this.DFSButton.Text = "DFS";
            this.DFSButton.UseVisualStyleBackColor = true;
            this.DFSButton.Click += new System.EventHandler(this.DFSButton_Click);
            // 
            // EulerButton
            // 
            this.EulerButton.Location = new System.Drawing.Point(355, 3);
            this.EulerButton.Name = "EulerButton";
            this.EulerButton.Size = new System.Drawing.Size(162, 74);
            this.EulerButton.TabIndex = 4;
            this.EulerButton.Text = "Szukaj cylku Eulera";
            this.EulerButton.UseVisualStyleBackColor = true;
            this.EulerButton.Click += new System.EventHandler(this.EulerButton_Click);
            // 
            // searchMSTButton
            // 
            this.searchMSTButton.Location = new System.Drawing.Point(3, 83);
            this.searchMSTButton.Name = "searchMSTButton";
            this.searchMSTButton.Size = new System.Drawing.Size(170, 74);
            this.searchMSTButton.TabIndex = 3;
            this.searchMSTButton.Text = "Szukaj MST";
            this.searchMSTButton.UseVisualStyleBackColor = true;
            this.searchMSTButton.Click += new System.EventHandler(this.searchMSTButton_Click);
            // 
            // checkConnectedButton
            // 
            this.checkConnectedButton.Location = new System.Drawing.Point(3, 3);
            this.checkConnectedButton.Name = "checkConnectedButton";
            this.checkConnectedButton.Size = new System.Drawing.Size(170, 74);
            this.checkConnectedButton.TabIndex = 2;
            this.checkConnectedButton.Text = "Sprawdź spójność";
            this.checkConnectedButton.UseVisualStyleBackColor = true;
            this.checkConnectedButton.Click += new System.EventHandler(this.checkConnectedButton_Click);
            // 
            // showLabels
            // 
            this.showLabels.AutoSize = true;
            this.showLabels.Checked = true;
            this.showLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLabels.Location = new System.Drawing.Point(7, 7);
            this.showLabels.Name = "showLabels";
            this.showLabels.Size = new System.Drawing.Size(63, 17);
            this.showLabels.TabIndex = 0;
            this.showLabels.Text = "Etykiety";
            this.showLabels.UseVisualStyleBackColor = true;
            this.showLabels.CheckedChanged += new System.EventHandler(this.showLabels_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPGraphs GUI";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.graphListControls.ResumeLayout(false);
            this.graphListControls.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.editTab.ResumeLayout(false);
            this.editTab.PerformLayout();
            this.drawTab.ResumeLayout(false);
            this.drawTab.PerformLayout();
            this.analyzeTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView graphList;
        private System.Windows.Forms.GroupBox graphListControls;
        private System.Windows.Forms.Button deleteGraphButton;
        private System.Windows.Forms.Button addGraphButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage editTab;
        private System.Windows.Forms.TabPage drawTab;
        private System.Windows.Forms.TabPage analyzeTab;
        private System.Windows.Forms.Button removeEdgeButton;
        private System.Windows.Forms.Button removeVertexButton;
        private System.Windows.Forms.Button addEdgeButton;
        private System.Windows.Forms.Button addVertexButton;
        private System.Windows.Forms.Label edgeCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView edgeList;
        private System.Windows.Forms.Label vertexCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label graphNameLabel;
        private System.Windows.Forms.Label graphTypeLabel;
        private System.Windows.Forms.TextBox matrixOutput;
        private System.Windows.Forms.Button showNeighboursButton;
        private System.Windows.Forms.Button checkConnectedButton;
        private System.Windows.Forms.Button BFSButton;
        private System.Windows.Forms.Button DFSButton;
        private System.Windows.Forms.Button EulerButton;
        private System.Windows.Forms.Button searchMSTButton;
        private System.Windows.Forms.Button generateCompleteRandomButton;
        private System.Windows.Forms.Button generateRandomButton;
        private System.Windows.Forms.Button checkPathsButton;
        private System.Windows.Forms.CheckBox showLabels;
    }
}