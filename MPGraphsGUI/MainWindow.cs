using System;
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
            using(NewGraphDialog dialog = new NewGraphDialog(this))
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
                        graphNameLabel.Text = "Graph Name";
                        graphTypeLabel.Text = "Graph Type";
                        vertexCountLabel.Text = "---";
                        edgeCountLabel.Text = "--";
                        edgeList.Clear();
                        matrixOutput.Clear();
                        addVertexButton.Enabled = false;
                        addEdgeButton.Enabled = false;
                        removeVertexButton.Enabled = false;
                        removeEdgeButton.Enabled = false;
                        showNeighboursButton.Enabled = false;
                        generateCompleteRandomButton.Enabled = false;
                        generateRandomButton.Enabled = false;
                        checkConnectedButton.Enabled = false;
                        searchMSTButton.Enabled = false;
                        BFSButton.Enabled = false;
                        DFSButton.Enabled = false;
                        EulerButton.Enabled = false;
                        checkPathsButton.Enabled = false;
                        CurrentGraphKey = null;
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
            addVertexButton.Enabled = true;
            addEdgeButton.Enabled = true;
            removeVertexButton.Enabled = true;
            removeEdgeButton.Enabled = true;
            showNeighboursButton.Enabled = true;
            generateCompleteRandomButton.Enabled = true;
            generateRandomButton.Enabled = true;
            checkConnectedButton.Enabled = true;
            searchMSTButton.Enabled = true;
            BFSButton.Enabled = true;
            DFSButton.Enabled = true;
            EulerButton.Enabled = true;
            checkPathsButton.Enabled = true;
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
        Graphics graphDrawing;
        private void drawTab_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph();
        }

        private void DrawGraph()
        {
            if (CurrentGraphKey != null)
            {
                switch (Graphs[CurrentGraphKey])
                {
                    case "incidence":
                        IncidenceMatrix im = GraphsIncidence[CurrentGraphKey];
                        DrawGraph<IncidenceMatrix, Incidence>(im);
                        break;
                    case "adjacency":
                        AdjacencyMatrix am = GraphsAdjacenecy[CurrentGraphKey];
                        DrawGraph<AdjacencyMatrix, Adjacency>(am);
                        break;
                    case "incidenceWeighted":
                        IncidenceMatrixWeighted iwm = GraphsIncidenceWeighted[CurrentGraphKey];
                        DrawGraph<IncidenceMatrixWeighted, Incidence>(iwm);
                        break;
                    case "adjacencyWeighted":
                        AdjacencyMatrixWeighted awm = GraphsAdjacencyWeighted[CurrentGraphKey];
                        DrawGraph<AdjacencyMatrixWeighted, Adjacency>(awm);
                        break;
                    default:
                        break;
                }
            }
        }
        public void DrawGraph<T, V>(T graph, bool customDraw = false, Control control = null, CheckBox labels = null, int size = 40, int padding = 50) where T : GraphRepresentation<V> where V : struct
        {
            Graphics tmp = null;
            if(customDraw == true)
            {
                tmp = graphDrawing;
                graphDrawing = control.CreateGraphics();
            } else
            {
                control = drawTab;
                labels = showLabels;
            }

            if (graphDrawing == null)
            {
                graphDrawing = drawTab.CreateGraphics();
            }
            else
            {
                graphDrawing.Clear(SystemColors.Control);
            }

            int radius = 0;
            if (control.Width < control.Height)
            {
                radius = control.Width / 2 - padding;
            }
            else
            {
                radius = control.Height / 2 - padding;
            }
            Tuple<int, int> center = new Tuple<int, int>(control.Width / 2 - padding, control.Height / 2 - padding);
            DrawVertices(graph.VertexCount, radius, graphDrawing, center, labels.Checked, size);
            DrawEdges<V>(graph, graphDrawing, radius, center, labels.Checked, size);

            if(customDraw == true)
            {
                graphDrawing.Dispose();
                graphDrawing = tmp;
            }
        }

        private void DrawVertices(int vertexNum, int radius, Graphics g, Tuple<int,int> center, bool drawLabels = true, int size = 40, double rotateDeg = -90.0)
        {
            double angleStep = 0;
            if (vertexNum > 0) {
                angleStep = 360 / vertexNum;
            }
            for (int i = 0; i < vertexNum; i++)
            {
                double x = Math.Cos(DegToRad(angleStep * i + rotateDeg)) * radius + center.Item1;
                double y = Math.Sin(DegToRad(angleStep * i + rotateDeg)) * radius + center.Item2;
                Rectangle r = new Rectangle((int)x, (int)y, size, size);
                g.DrawEllipse(Pens.Black, r);
                if (drawLabels == true)
                {
                    Point p = new Point((int)x + size / 2, (int)y + size / 2);
                    Font f = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                    g.DrawString(String.Format("v{0}", i), f, Brushes.Black, p);
                }
            }
        }
        public double DegToRad(double deg)
        {
            return (Math.PI / 180.0) * deg;
        }
        private void DrawEdges<T>(GraphRepresentation<T> graph, Graphics g, int radius, Tuple<int,int> center, bool drawLabels = true, int size = 40, double rotateDeg = -90.0) where T : struct
        {
            int vertexNum = graph.VertexCount;
            double angleStep = 0;
            if (vertexNum > 0)
            {
                angleStep = 360 / vertexNum;
            }
            for (int i = 0; i < vertexNum; i++)
            {
                int j = 0;
                if(graph.IsDirected == false)
                {
                    j = i;
                }
                for(; j < vertexNum; j++)
                {
                    if(graph.FindEdge(i,j) == true)
                    {
                        double x1 = Math.Cos(DegToRad(angleStep * i + rotateDeg)) * radius + center.Item1 + size/2;
                        double y1 = Math.Sin(DegToRad(angleStep * i + rotateDeg)) * radius + center.Item2 + size/2;
                        double x2 = Math.Cos(DegToRad(angleStep * j + rotateDeg)) * radius + center.Item1 + size/2;
                        double y2 = Math.Sin(DegToRad(angleStep * j + rotateDeg)) * radius + center.Item2 + size/2;
                        g.DrawLine(Pens.Black, new Point((int)x1, (int)y1), new Point((int)x2, (int)y2));
                        if(graph.IsDirected == true)
                        {
                            g.FillEllipse(Brushes.Black, (int)x2-size/8, (int)y2-size/8, size / 4, size / 4);
                        }
                        if (drawLabels == true)
                        {
                            double x, y;
                            if(x1 > x2)
                            {
                                x = x2 + (x1 - x2) / 2;
                            } else
                            {
                                x = x1 + (x2 - x1) / 2;
                            }
                            if(y1 > y2)
                            {
                                y = y2 + (y1 - y2) / 2;
                            } else
                            {
                                y = y1 + (y2 - y1) / 2;
                            }
                            Point p = new Point((int)x, (int)y);
                            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                            g.DrawString(String.Format("e(v{0},v{1})", i, j), f, Brushes.Black, p);
                        }
                    }
                }
            }
        }

        private void drawTab_Resize(object sender, EventArgs e)
        {
            graphDrawing.Dispose();
            graphDrawing = null;
        }

        private void showLabels_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }
    }
}
