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
    public partial class CheckPathsDialog : Form
    {
        public MainWindow mainRef { get; set; }
        public CheckPathsDialog(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }

        private void calculatePathsButton_Click(object sender, EventArgs e)
        {
            double? diameter = null, radius = null;
            List<int> graphCenter = null;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrixWeighted mi = new IncidenceMatrixWeighted(mainRef.GraphsIncidence[mainRef.CurrentGraphKey]);
                    diameter = mi.Diameter;
                    radius = mi.Radius;
                    graphCenter = mi.GraphCenter;
                    break;
                case "adjacency":
                    AdjacencyMatrixWeighted ma = new AdjacencyMatrixWeighted(mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey]);
                    diameter = ma.Diameter;
                    radius = ma.Radius;
                    graphCenter = ma.GraphCenter;
                    break;
                case "incidenceWeighted":
                    diameter = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].Diameter;
                    radius = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].Radius;
                    graphCenter = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].GraphCenter;
                    break;
                case "adjacencyWeighted":
                    diameter = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].Diameter;
                    radius = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].Radius;
                    graphCenter = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].GraphCenter;
                    break;
                default:
                    break;
            }
            if (diameter != null)
            {
                if (double.IsInfinity((double)diameter) == false)
                {
                    dimValue.Maximum = decimal.MaxValue;
                    dimValue.Value = Convert.ToDecimal(diameter);
                } else
                {
                    dimValue.Minimum = decimal.MinValue;
                    dimValue.Value = decimal.MinValue;
                    dimValue.BackColor = Color.Red;
                }
            }
            if(radius != null)
            {
                if (double.IsInfinity((double)radius) == false)
                {
                    radValue.Maximum = decimal.MaxValue;
                    radValue.Value = Convert.ToDecimal(radius);
                }
                else
                {
                    radValue.Minimum = decimal.MinValue;
                    radValue.Value = decimal.MinValue;
                    radValue.BackColor = Color.Red;
                }
            }
            graphCenterList.Clear();
            if(graphCenter != null)
            {
                foreach(int i in graphCenter)
                {
                    graphCenterList.Items.Add(i.ToString());
                }
            }
        }
    }
}
