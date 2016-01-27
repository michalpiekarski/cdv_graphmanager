﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPGraphs.GraphStructures;

namespace MPGraphsGUI
{
    public partial class MainWindow : Form
    {
        public Dictionary<String, AdjacencyMatrix> GraphsAdjacenecy;
        public Dictionary<String, AdjacencyMatrixWeighted> GraphsAdjacencyWeighted;
        public Dictionary<String, IncidenceMatrix> GraphsIncidence;
        public Dictionary<String, IncidenceMatrixWeighted> GraphsIncidenceWeighted;
        public Dictionary<String, String> Graphs;
        public MainWindow()
        {
            InitializeComponent();
            GraphsAdjacenecy = new Dictionary<string, AdjacencyMatrix>();
            GraphsIncidence = new Dictionary<string, IncidenceMatrix>();
            GraphsAdjacencyWeighted = new Dictionary<string, AdjacencyMatrixWeighted>();
            GraphsIncidenceWeighted = new Dictionary<string, IncidenceMatrixWeighted>();
            Graphs = new Dictionary<string, string>();
        }

        private void addGraphButton_Click(object sender, EventArgs e)
        {
            using(NewGraphDialog dialog = new NewGraphDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    switch (dialog.GraphType)
                    {
                        case "Macierz incydencji":
                            if(dialog.GraphDirected == true)
                            {
                                GraphsIncidence.Add(dialog.GraphName, new IncidenceMatrix(true));
                            } else
                            {
                                GraphsIncidence.Add(dialog.GraphName, new IncidenceMatrix());
                            }
                            Graphs.Add(dialog.GraphName, "incidence");
                            break;
                        case "Macierz sąsiedztwa":
                            if (dialog.GraphDirected == true)
                            {
                                GraphsAdjacenecy.Add(dialog.GraphName, new AdjacencyMatrix(true));
                            }
                            else
                            {
                                GraphsAdjacenecy.Add(dialog.GraphName, new AdjacencyMatrix());
                            }
                            Graphs.Add(dialog.GraphName, "adjacency");
                            break;
                        case "Macierz incydencji z wagami":
                            if (dialog.GraphDirected == true)
                            {
                                GraphsIncidenceWeighted.Add(dialog.GraphName, new IncidenceMatrixWeighted(true));
                            }
                            else
                            {
                                GraphsIncidenceWeighted.Add(dialog.GraphName, new IncidenceMatrixWeighted());
                            }
                            Graphs.Add(dialog.GraphName, "incidenceWeighted");
                            break;
                        case "Macierz sąsiedztwa z wagami":
                            if (dialog.GraphDirected == true)
                            {
                                GraphsAdjacencyWeighted.Add(dialog.GraphName, new AdjacencyMatrixWeighted(true));
                            }
                            else
                            {
                                GraphsAdjacencyWeighted.Add(dialog.GraphName, new AdjacencyMatrixWeighted());
                            }
                            Graphs.Add(dialog.GraphName, "adjacencyWeighted");
                            break;
                        default:
                            break;
                    }
                    graphList.Items.Add(dialog.GraphName);
                    CurrentGraphKey = dialog.GraphName;
                    LoadGraph();
                }
            }
        }

        private void deleteGraphButton_Click(object sender, EventArgs e)
        {
            using (DeleteGraphConfirmDialog dialog = new DeleteGraphConfirmDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    ListView.SelectedListViewItemCollection selectedGraph = graphList.SelectedItems;
                    if (selectedGraph.Count > 0)
                    {
                        String key = selectedGraph[0].Text;
                        switch (Graphs[key])
                        {
                            case "incidence":
                                GraphsIncidence.Remove(key);
                                break;
                            case "adjacency":
                                GraphsAdjacenecy.Remove(key);
                                break;
                            case "incidenceWeighted":
                                GraphsIncidenceWeighted.Remove(key);
                                break;
                            case "adjacencyWeighted":
                                GraphsAdjacencyWeighted.Remove(key);
                                break;
                            default:
                                break;
                        }
                        graphList.Items.RemoveAt(graphList.SelectedIndices[0]);
                    }
                }
            }
        }
        public String CurrentGraphKey;
        private void graphList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedGraph = graphList.SelectedItems;
            if (selectedGraph.Count > 0)
            {
                CurrentGraphKey = selectedGraph[0].Text;
                LoadGraph();
            }
        }

        private void LoadGraph()
        {
            graphNameLabel.Text = CurrentGraphKey;
            edgeList.Clear();
            matrixOutput.Clear();
            switch (Graphs[CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                    graphTypeLabel.Text = String.Format("Macierz incydencji - {0}", CurrentMatrixI.IsDirected ? "skierowana" : "nieskierowana");
                    vertexCountLabel.Text = CurrentMatrixI.VertexCount.ToString();
                    edgeCountLabel.Text = CurrentMatrixI.EdgeCount.ToString();
                    for (int i = 0; i < CurrentMatrixI.VertexCount; i++)
                    {
                        for (int j = 0; j < CurrentMatrixI.VertexCount; j++)
                        {
                            if(CurrentMatrixI.FindEdge(i, j) == true)
                            {
                                edgeList.Items.Add(String.Format("{0}--{1}", i, j));
                            }
                        }
                    }
                    if(CurrentMatrixI.VertexCount > 0)
                    {
                        generateCompleteRandomButton.Enabled = false;
                        generateRandomButton.Enabled = false;
                    }
                    else
                    {
                        generateCompleteRandomButton.Enabled = true;
                        generateRandomButton.Enabled = true;
                    }
                    matrixOutput.Text = GenerateIncidenceString(CurrentMatrixI);
                    break;
                case "adjacency":
                    AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                    graphTypeLabel.Text = String.Format("Macierz sąsiedztwa - {0}", CurrentMatrixA.IsDirected ? "skierowana" : "nieskierowana");
                    vertexCountLabel.Text = CurrentMatrixA.VertexCount.ToString();
                    edgeCountLabel.Text = CurrentMatrixA.EdgeCount.ToString();
                    for (int i = 0; i < CurrentMatrixA.VertexCount; i++)
                    {
                        for (int j = 0; j < CurrentMatrixA.VertexCount; j++)
                        {
                            if (CurrentMatrixA.FindEdge(i, j) == true)
                            {
                                edgeList.Items.Add(String.Format("{0}--{1}", i, j));
                            }
                        }
                    }
                    if (CurrentMatrixA.VertexCount > 0)
                    {
                        generateCompleteRandomButton.Enabled = false;
                        generateRandomButton.Enabled = false;
                    }
                    else
                    {
                        generateCompleteRandomButton.Enabled = true;
                        generateRandomButton.Enabled = true;
                    }
                    matrixOutput.Text = GenerateAdjacencyString(CurrentMatrixA);
                    break;
                case "incidenceWeighted":
                    IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                    graphTypeLabel.Text = String.Format("Macierz incydencji z wagami - {0}", CurrentMatrixIW.IsDirected ? "skierowana" : "nieskierowana");
                    vertexCountLabel.Text = CurrentMatrixIW.VertexCount.ToString();
                    edgeCountLabel.Text = CurrentMatrixIW.EdgeCount.ToString();
                    for (int i = 0; i < CurrentMatrixIW.VertexCount; i++)
                    {
                        for (int j = 0; j < CurrentMatrixIW.VertexCount; j++)
                        {
                            if (CurrentMatrixIW.FindEdge(i, j) == true)
                            {
                                edgeList.Items.Add(String.Format("{0}--{1}", i, j));
                            }
                        }
                    }
                    if (CurrentMatrixIW.VertexCount > 0)
                    {
                        generateCompleteRandomButton.Enabled = false;
                        generateRandomButton.Enabled = false;
                    }
                    else
                    {
                        generateCompleteRandomButton.Enabled = true;
                        generateRandomButton.Enabled = true;
                    }
                    matrixOutput.Text = GenerateIncidenceString(CurrentMatrixIW);
                    break;
                case "adjacencyWeighted":
                    AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                    graphTypeLabel.Text = String.Format("Macierz sąsiedztwa z wagami - {0}", CurrentMatrixAW.IsDirected ? "skierowana" : "nieskierowana");
                    vertexCountLabel.Text = CurrentMatrixAW.VertexCount.ToString();
                    edgeCountLabel.Text = CurrentMatrixAW.EdgeCount.ToString();
                    for (int i = 0; i < CurrentMatrixAW.VertexCount; i++)
                    {
                        for (int j = 0; j < CurrentMatrixAW.VertexCount; j++)
                        {
                            if (CurrentMatrixAW.FindEdge(i, j) == true)
                            {
                                edgeList.Items.Add(String.Format("{0}--{1}", i, j));
                            }
                        }
                    }
                    if (CurrentMatrixAW.VertexCount > 0)
                    {
                        generateCompleteRandomButton.Enabled = false;
                        generateRandomButton.Enabled = false;
                    } else
                    {
                        generateCompleteRandomButton.Enabled = true;
                        generateRandomButton.Enabled = true;
                    }
                    matrixOutput.Text = GenerateAdjacencyString(CurrentMatrixAW);
                    break;
                default:
                    break;
            }
        }

        private string GenerateIncidenceString(IncidenceMatrix matrix)
        {
            string output = String.Format("{0,6}","");
            for(int i = 0; i < matrix.EdgeCount; i++)
            {
                output += String.Format("{0,-5}", "e" + i) + "|";
            }
            output += "\r\n";
            for(int i = 0; i < matrix.VertexCount; i++)
            {
                output += String.Format("{0,5}", "v" + i) + "|";
                foreach(Incidence value in matrix.GetRow(i))
                {
                    output += String.Format("{0,-5}", value) + "|";
                }
                output += "\r\n";
            }
            return output;
        }


        private string GenerateAdjacencyString(AdjacencyMatrix matrix)
        {
            string output = String.Format("{0,6}", "");
            for (int i = 0; i < matrix.VertexCount; i++)
            {
                output += String.Format("{0,-5}", "v" + i) + "|";
            }
            output += "\r\n";
            for (int i = 0; i < matrix.VertexCount; i++)
            {
                output += String.Format("{0,5}", "v" + i) + " ";
                foreach (Adjacency value in matrix.GetRow(i))
                {
                    output += String.Format("{0,-5}", value) + "|";
                }
                output += "\r\n";
            }
            return output;
        }

        private void addVertexButton_Click(object sender, EventArgs e)
        {
            switch (Graphs[CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                    CurrentMatrixI.AddVertex();
                    break;
                case "adjacency":
                    AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                    CurrentMatrixA.AddVertex();
                    break;
                case "incidenceWeighted":
                    IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                    CurrentMatrixIW.AddVertex();
                    break;
                case "adjacencyWeighted":
                    AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                    CurrentMatrixAW.AddVertex();
                    break;
                default:
                    break;
            }
            LoadGraph();
        }

        private void removeEdgeButton_Click(object sender, EventArgs e)
        {
            using (RemoveEdgeDialog dialog = new RemoveEdgeDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int vertexIndexA = (int)dialog.VertexIndexA;
                    int vertexIndexB = (int)dialog.VertexIndexB;
                    switch (Graphs[CurrentGraphKey])
                    {
                        case "incidence":
                            IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                            CurrentMatrixI.RemoveEdge(vertexIndexA, vertexIndexB);
                            break;
                        case "adjacency":
                            AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                            CurrentMatrixA.RemoveEdge(vertexIndexA, vertexIndexB);
                            break;
                        case "incidenceWeighted":
                            IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                            CurrentMatrixIW.RemoveEdge(vertexIndexA, vertexIndexB);
                            break;
                        case "adjacencyWeighted":
                            AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                            CurrentMatrixAW.RemoveEdge(vertexIndexA, vertexIndexB);
                            break;
                        default:
                            break;
                    }
                    LoadGraph();
                }
            }
        }

        private void removeVertexButton_Click(object sender, EventArgs e)
        {
            using (RemoveVertexDialog dialog = new RemoveVertexDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int vertexIndex = (int)dialog.VertexIndex;
                    switch (Graphs[CurrentGraphKey])
                    {
                        case "incidence":
                            IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                            CurrentMatrixI.RemoveVertex(vertexIndex);
                            break;
                        case "adjacency":
                            AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                            CurrentMatrixA.RemoveVertex(vertexIndex);
                            break;
                        case "incidenceWeighted":
                            IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                            CurrentMatrixIW.RemoveVertex(vertexIndex);
                            break;
                        case "adjacencyWeighted":
                            AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                            CurrentMatrixAW.RemoveVertex(vertexIndex);
                            break;
                        default:
                            break;
                    }
                    LoadGraph();
                }
            }
        }

        private void addEdgeButton_Click(object sender, EventArgs e)
        {
            int vertexIndexA;
            int vertexIndexB;
            int weight;
            switch (Graphs[CurrentGraphKey])
            {
                case "incidence":
                    using (AddEdgeDialog dialog = new AddEdgeDialog())
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            vertexIndexA = (int)dialog.VertexIndexA;
                            vertexIndexB = (int)dialog.VertexIndexB;
                            IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                            CurrentMatrixI.AddEdge(vertexIndexA, vertexIndexB);
                        }
                    }
                    break;
                case "adjacency":
                    using (AddEdgeDialog dialog = new AddEdgeDialog())
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            vertexIndexA = (int)dialog.VertexIndexA;
                            vertexIndexB = (int)dialog.VertexIndexB;
                            AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                            CurrentMatrixA.AddEdge(vertexIndexA, vertexIndexB);
                        }
                    }
                    break;
                case "incidenceWeighted":
                    using (AddEdgeDialog dialog = new AddEdgeDialog(true))
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            vertexIndexA = (int)dialog.VertexIndexA;
                            vertexIndexB = (int)dialog.VertexIndexB;
                            weight = (int)dialog.Weight;
                            IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                            CurrentMatrixIW.AddEdge(vertexIndexA, vertexIndexB, weight);
                        }
                    }
                    break;
                case "adjacencyWeighted":
                    using (AddEdgeDialog dialog = new AddEdgeDialog(true))
                    {
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            vertexIndexA = (int)dialog.VertexIndexA;
                            vertexIndexB = (int)dialog.VertexIndexB;
                            weight = (int)dialog.Weight;
                            AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                            CurrentMatrixAW.AddEdge(vertexIndexA, vertexIndexB, weight);
                        }
                    }
                    break;
                default:
                    break;
            }
            LoadGraph();
        }

        private void showNeighboursButton_Click(object sender, EventArgs e)
        {
            using(ShowListOfNeighbours dialog = new ShowListOfNeighbours(this))
            {
                dialog.ShowDialog();
            }
        }

        private void checkConnectedButton_Click(object sender, EventArgs e)
        {
            using(CheckConnectedDialog dialog = new CheckConnectedDialog(this))
            {
                dialog.ShowDialog();
            }
        }

        private void searchMSTButton_Click(object sender, EventArgs e)
        {
            using (SearchMSTDialog dialog = new SearchMSTDialog(this))
            {
                dialog.ShowDialog();
            }
        }

        private void generateCompleteRandomButton_Click(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int vertexCount = r.Next(5, 20);
            switch (Graphs[CurrentGraphKey])
            {
                case "incidence":
                    GraphsIncidence[CurrentGraphKey] = IncidenceMatrix.CompleteGraph<IncidenceMatrix, Incidence>(vertexCount);
                    break;
                case "adjacency":
                    GraphsAdjacenecy[CurrentGraphKey] = AdjacencyMatrix.CompleteGraph<AdjacencyMatrix, Adjacency>(vertexCount);
                    break;
                case "incidenceWeighted":
                    GraphsIncidenceWeighted[CurrentGraphKey] = IncidenceMatrixWeighted.CompleteGraph<IncidenceMatrixWeighted, Incidence>(vertexCount);
                    break;
                case "adjacencyWeighted":
                    GraphsAdjacencyWeighted[CurrentGraphKey] = AdjacencyMatrixWeighted.CompleteGraph<AdjacencyMatrixWeighted, Adjacency>(vertexCount);
                    break;
                default:
                    break;
            }
            LoadGraph();
        }

        private void generateRandomButton_Click(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int vertexCount = r.Next(5, 20);
            int edgeCount = r.Next(3, 30);
            switch (Graphs[CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrix CurrentMatrixI = GraphsIncidence[CurrentGraphKey];
                    for (int i = 0; i < vertexCount; i++)
                    {
                        CurrentMatrixI.AddVertex();
                    }
                    for (int i = 0; i < edgeCount; i++)
                    {
                        CurrentMatrixI.AddEdge(r.Next(0, vertexCount - 1), r.Next(0, vertexCount - 1));
                    }
                    break;
                case "adjacency":
                    AdjacencyMatrix CurrentMatrixA = GraphsAdjacenecy[CurrentGraphKey];
                    for (int i = 0; i < vertexCount; i++)
                    {
                        CurrentMatrixA.AddVertex();
                    }
                    for (int i = 0; i < edgeCount; i++)
                    {
                        CurrentMatrixA.AddEdge(r.Next(0, vertexCount - 1), r.Next(0, vertexCount - 1));
                    }
                    break;
                case "incidenceWeighted":
                    IncidenceMatrixWeighted CurrentMatrixIW = GraphsIncidenceWeighted[CurrentGraphKey];
                    for (int i = 0; i < vertexCount; i++)
                    {
                        CurrentMatrixIW.AddVertex();
                    }
                    for (int i = 0; i < edgeCount; i++)
                    {
                        CurrentMatrixIW.AddEdge(r.Next(0, vertexCount - 1), r.Next(0, vertexCount - 1), r.Next(0, 100));
                    }
                    break;
                case "adjacencyWeighted":
                    AdjacencyMatrixWeighted CurrentMatrixAW = GraphsAdjacencyWeighted[CurrentGraphKey];
                    for (int i = 0; i < vertexCount; i++)
                    {
                        CurrentMatrixAW.AddVertex();
                    }
                    for (int i = 0; i < edgeCount; i++)
                    {
                        CurrentMatrixAW.AddEdge(r.Next(0, vertexCount - 1), r.Next(0, vertexCount - 1), r.Next(0, 100));
                    }
                    break;
                default:
                    break;
            }
            LoadGraph();
        }

        private void EulerButton_Click(object sender, EventArgs e)
        {
            using(SearchEulerDialog dialog = new SearchEulerDialog(this))
            {
                dialog.ShowDialog();
            }
        }

        private void checkPathsButton_Click(object sender, EventArgs e)
        {
            using(CheckPathsDialog dialog = new CheckPathsDialog(this))
            {
                dialog.ShowDialog();
            }
        }

        private void DFSButton_Click(object sender, EventArgs e)
        {
            using(GraphSearchDialog dialog = new GraphSearchDialog(this, "dfs"))
            {
                dialog.ShowDialog();
            }
        }

        private void BFSButton_Click(object sender, EventArgs e)
        {
            using (GraphSearchDialog dialog = new GraphSearchDialog(this, "bfs"))
            {
                dialog.ShowDialog();
            }
        }
    }
}
