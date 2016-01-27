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
    public partial class ShowListOfNeighbours : Form
    {
        MainWindow mainRef;
        public ShowListOfNeighbours(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            incidentList.Clear();
            List<int> adjacent = null;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    adjacent = mainRef.GraphsIncidence[mainRef.CurrentGraphKey].FindAdjacentVertices((int)vertexIndexInput.Value);
                    break;
                case "adjacency":
                    adjacent = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].FindAdjacentVertices((int)vertexIndexInput.Value);
                    break;
                case "incidenceWeighted":
                    adjacent = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].FindAdjacentVertices((int)vertexIndexInput.Value);
                    break;
                case "adjacencyWeighted":
                    adjacent = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].FindAdjacentVertices((int)vertexIndexInput.Value);
                    break;
                default:
                    break;
            }
            if (adjacent != null)
            {
                foreach (int a in adjacent)
                {
                    incidentList.Items.Add(a.ToString());
                }
            }
        }
    }
}
