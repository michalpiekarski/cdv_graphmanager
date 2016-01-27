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
    public partial class CheckConnectedDialog : Form
    {
        public MainWindow mainRef { get; set; }
        public CheckConnectedDialog(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
            bool directedGraph = false;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    directedGraph = mainRef.GraphsIncidence[mainRef.CurrentGraphKey].IsDirected;
                    break;
                case "adjacency":
                    directedGraph = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].IsDirected;
                    break;
                case "incidenceWeighted":
                    directedGraph = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].IsDirected;
                    break;
                case "adjacencyWeighted":
                    directedGraph = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].IsDirected;
                    break;
                default:
                    break;
            }
            if(directedGraph == true)
            {
                weakConnectedButton.Enabled = true;
            }
        }

        private void strongConnectedButton_Click(object sender, EventArgs e)
        {
            bool isConnected = false;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    isConnected = mainRef.GraphsIncidence[mainRef.CurrentGraphKey].IsConnected;
                    break;
                case "adjacency":
                    isConnected = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].IsConnected;
                    break;
                case "incidenceWeighted":
                    isConnected = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].IsConnected;
                    break;
                case "adjacencyWeighted":
                    isConnected = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].IsConnected;
                    break;
                default:
                    break;
            }
            if(isConnected == true)
            {
                strongConnectedResultCheckbox.Checked = true;
                weakConnectedResultCheckbox.Checked = true;
            }
        }

        private void weakConnectedButton_Click(object sender, EventArgs e)
        {
            bool isConnected = false;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    isConnected = mainRef.GraphsIncidence[mainRef.CurrentGraphKey].ConvertToUndirected().IsConnected;
                    break;
                case "adjacency":
                    isConnected = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].ConvertToUndirected().IsConnected;
                    break;
                case "incidenceWeighted":
                    isConnected = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].ConvertToUndirected().IsConnected;
                    break;
                case "adjacencyWeighted":
                    isConnected = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].ConvertToUndirected().IsConnected;
                    break;
                default:
                    break;
            }
            if (isConnected == true)
            {
                weakConnectedResultCheckbox.Checked = true;
            }
        }
    }
}
