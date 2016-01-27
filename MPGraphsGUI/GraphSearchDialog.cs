using MPGraphs.GraphSearch;
using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPGraphsGUI
{
    public partial class GraphSearchDialog : Form
    {
        MainWindow mainRef { get; set; }
        string mode { get; set; }
        public GraphSearchDialog(MainWindow mainRef, string mode)
        {
            InitializeComponent();
            this.mainRef = mainRef;
            this.mode = mode;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchResultOutput.Clear();
            switch (mode)
            {
                case "bfs":
                    switch (mainRef.Graphs[mainRef.CurrentGraphKey])
                    {
                        case "incidence":
                            using(BFS<IncidenceMatrix, Incidence> bfs = new BFS<IncidenceMatrix, Incidence>())
                            {
                                SearchResult<IncidenceMatrix, Incidence> result = bfs.Search(mainRef.GraphsIncidence[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach(int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "adjacency":
                            using (BFS<AdjacencyMatrix, Adjacency> bfs = new BFS<AdjacencyMatrix, Adjacency>())
                            {
                                SearchResult<AdjacencyMatrix, Adjacency> result = bfs.Search(mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "incidenceWeighted":
                            using (BFS<IncidenceMatrixWeighted, Incidence> bfs = new BFS<IncidenceMatrixWeighted, Incidence>())
                            {
                                SearchResult<IncidenceMatrixWeighted, Incidence> result = bfs.Search(mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "adjacencyWeighted":
                            using (BFS<AdjacencyMatrixWeighted, Adjacency> bfs = new BFS<AdjacencyMatrixWeighted, Adjacency>())
                            {
                                SearchResult<AdjacencyMatrixWeighted, Adjacency> result = bfs.Search(mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "dfs":
                    switch (mainRef.Graphs[mainRef.CurrentGraphKey])
                    {
                        case "incidence":
                            using (DFS<IncidenceMatrix, Incidence> dfs = new DFS<IncidenceMatrix, Incidence>())
                            {
                                SearchResult<IncidenceMatrix, Incidence> result = dfs.Search(mainRef.GraphsIncidence[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "adjacency":
                            using (DFS<AdjacencyMatrix, Adjacency> dfs = new DFS<AdjacencyMatrix, Adjacency>())
                            {
                                SearchResult<AdjacencyMatrix, Adjacency> result = dfs.Search(mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "incidenceWeighted":
                            using (DFS<IncidenceMatrixWeighted, Incidence> dfs = new DFS<IncidenceMatrixWeighted, Incidence>())
                            {
                                SearchResult<IncidenceMatrixWeighted, Incidence> result = dfs.Search(mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        case "adjacencyWeighted":
                            using (DFS<AdjacencyMatrixWeighted, Adjacency> dfs = new DFS<AdjacencyMatrixWeighted, Adjacency>())
                            {
                                SearchResult<AdjacencyMatrixWeighted, Adjacency> result = dfs.Search(mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey], (int)vertexIndexInput.Value);
                                foreach (int i in result.Numbering)
                                {
                                    searchResultOutput.AppendText(String.Format("{0},", i));
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
    }
}
