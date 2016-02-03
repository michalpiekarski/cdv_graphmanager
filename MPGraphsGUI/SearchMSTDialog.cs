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
    public partial class SearchMSTDialog : Form
    {
        public MainWindow mainRef { get; set; }
        public SearchMSTDialog(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }

        private void MSTButton_Click(object sender, EventArgs e)
        {
            IncidenceMatrixWeighted msti = null;
            AdjacencyMatrixWeighted msta = null;
            CheckBox labels = new CheckBox();
            labels.Checked = true;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrixWeighted mi = new IncidenceMatrixWeighted(mainRef.GraphsIncidence[mainRef.CurrentGraphKey]);
                    msti = mi.FindMST();
                    if (msti != null)
                    {
                        mainRef.DrawGraph<IncidenceMatrix, Incidence>(msti, true, splitContainer1.Panel2, labels, 20, 25);
                    }
                    break;
                case "adjacency":
                    AdjacencyMatrixWeighted ma = new AdjacencyMatrixWeighted(mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey]);
                    msta = ma.FindMST();
                    if (msta != null)
                    {
                        mainRef.DrawGraph<AdjacencyMatrix, Adjacency>(msta, true, splitContainer1.Panel2, labels, 20, 25);
                    }
                    break;
                case "incidenceWeighted":
                    msti = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey].FindMST();
                    if (msti != null)
                    {
                        mainRef.DrawGraph<IncidenceMatrix, Incidence>(msti, true, splitContainer1.Panel2, labels, 20, 25);
                    }
                    break;
                case "adjacencyWeighted":
                    msta = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey].FindMST();
                    if (msta != null)
                    {
                        mainRef.DrawGraph<AdjacencyMatrix, Adjacency>(msta, true, splitContainer1.Panel2, labels, 20, 25);
                    }
                    break;
                default:
                    break;
            }
            MSTResultOutput.Clear();
            if(msti != null)
            {
                string output = String.Format("{0,5}", "");
                for(int i = 0; i < msti.EdgeCount; i++)
                {
                    output += String.Format("{0,-5}", "e" + i) + "|";
                }
                output += "\r\n";
                for (int i = 0; i < msti.VertexCount; i++)
                {
                    output += String.Format("{0,-4}", "v" + i) + "|";
                    foreach(Incidence value in msti.GetRow(i))
                    {
                        output += String.Format("{0,-5}", value) + "|";
                    }
                    output += "\r\n";
                }
                MSTResultOutput.Text = output;
            }
            else if(msta != null)
            {

                string output = String.Format("{0,5}", "");
                for (int i = 0; i < msta.VertexCount; i++)
                {
                    output += String.Format("{0,-5}", "v" + i) + "|";
                }
                output += "\r\n";
                for (int i = 0; i < msta.VertexCount; i++)
                {
                    output += String.Format("{0,-4}", "v" + i) + "|";
                    foreach (Adjacency value in msta.GetRow(i))
                    {
                        output += String.Format("{0,-5}", value) + "|";
                    }
                    output += "\r\n";
                }
                MSTResultOutput.Text = output;
            }
        }
    }
}
