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
    public partial class SearchEulerDialog : Form
    {
        public MainWindow mainRef { get; set; }
        public SearchEulerDialog(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }

        private void searchEulerButton_Click(object sender, EventArgs e)
        {
            List<int> result = null;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    result = mainRef.GraphsIncidence[mainRef.CurrentGraphKey].Fleury();
                    break;
                case "adjacency":
                    result = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey].Fleury();
                    break;
                case "incidenceWeighted":
                    result = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].Fleury();
                    break;
                case "adjacencyWeighted":
                    result = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].Fleury();
                    break;
                default:
                    break;
            }
            string resultOutput = "";
            if (result != null)
            {
                foreach (int i in result)
                {
                    resultOutput += String.Format("{0}, ", i);
                }
            } else
            {
                resultOutput = "Graj jest nie-eulerowski";
            }
            searchEulerResutOutput.Text = resultOutput;
        }
    }
}
