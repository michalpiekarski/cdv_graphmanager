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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.graphListControls.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.editTab.SuspendLayout();
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
            this.drawTab.Location = new System.Drawing.Point(4, 22);
            this.drawTab.Name = "drawTab";
            this.drawTab.Padding = new System.Windows.Forms.Padding(3);
            this.drawTab.Size = new System.Drawing.Size(525, 535);
            this.drawTab.TabIndex = 1;
            this.drawTab.Text = "Rysuj";
            this.drawTab.UseVisualStyleBackColor = true;
            // 
            // analyzeTab
            // 
            this.analyzeTab.Location = new System.Drawing.Point(4, 22);
            this.analyzeTab.Name = "analyzeTab";
            this.analyzeTab.Size = new System.Drawing.Size(525, 535);
            this.analyzeTab.TabIndex = 2;
            this.analyzeTab.Text = "Analizuj";
            this.analyzeTab.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
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
    }
}