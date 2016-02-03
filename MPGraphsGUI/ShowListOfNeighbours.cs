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
    public partial class ShowListOfNeighbours : Form
    {
        MainWindow mainRef;
        public ShowListOfNeighbours(MainWindow mainRef)
        {
            InitializeComponent();
            this.mainRef = mainRef;
        }
        List<int> adjacent;

        private void searchButton_Click(object sender, EventArgs e)
        {
            incidentList.Clear();
            adjacent = null;
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
            DrawNeighbours();
        }
        private void DrawNeighbours()
        {
            Graphics g = neighbourDraw.CreateGraphics();
            g.Clear(SystemColors.Control);
            int radius = neighbourDraw.Width/2-10;
            Tuple<int, int> center = new Tuple<int, int>(neighbourDraw.Width / 2-10, neighbourDraw.Height / 2-10);
            bool labels = neighbourLabels.Checked;
            CheckBox cb = new CheckBox();
            cb.Checked = false;
            switch (mainRef.Graphs[mainRef.CurrentGraphKey])
            {
                case "incidence":
                    IncidenceMatrix im = mainRef.GraphsIncidence[mainRef.CurrentGraphKey];
                    mainRef.DrawGraph<IncidenceMatrix, Incidence>(im, true, neighbourDraw, cb, 10, 10);
                    DrawNeighbours(adjacent, im.VertexCount, radius, g, center, labels, 10);
                    break;
                case "adjacency":
                    AdjacencyMatrix am = mainRef.GraphsAdjacenecy[mainRef.CurrentGraphKey];
                    mainRef.DrawGraph<AdjacencyMatrix, Adjacency>(am, true, neighbourDraw, cb, 10, 10);
                    DrawNeighbours(adjacent, am.VertexCount, radius, g, center, labels, 10);
                    break;
                case "incidenceWeighted":
                    IncidenceMatrixWeighted iwm = mainRef.GraphsIncidenceWeighted[mainRef.CurrentGraphKey];
                    mainRef.DrawGraph<IncidenceMatrixWeighted, Incidence>(iwm, true, neighbourDraw, cb, 10, 10);
                    DrawNeighbours(adjacent, iwm.VertexCount, radius, g, center, labels, 10);
                    break;
                case "adjacencyWeighted":
                    AdjacencyMatrixWeighted awm = mainRef.GraphsAdjacencyWeighted[mainRef.CurrentGraphKey];
                    mainRef.DrawGraph<AdjacencyMatrix, Adjacency>(awm, true, neighbourDraw, cb, 10, 10);
                    DrawNeighbours(adjacent, awm.VertexCount, radius, g, center, labels, 10);
                    break;
                default:
                    break;
            }
        }
        private void DrawNeighbours(List<int> neighbours, int vertexNum, int radius, Graphics g, Tuple<int, int> center, bool drawLabels = true, int size = 40, double rotateDeg = -90.0)
        {
                double angleStep = 0;
                if (vertexNum > 0)
                {
                    angleStep = 360 / vertexNum;
                }
                for (int i = 0; i < vertexNum; i++)
                {
                    if (i == (int)vertexIndexInput.Value)
                    {
                        double x = Math.Cos(mainRef.DegToRad(angleStep * i + rotateDeg)) * radius + center.Item1;
                        double y = Math.Sin(mainRef.DegToRad(angleStep * i + rotateDeg)) * radius + center.Item2;
                        Rectangle r = new Rectangle((int)x, (int)y, size, size);
                        g.FillEllipse(Brushes.Red, r);
                        if (drawLabels == true)
                        {
                            Point p = new Point((int)x + size, (int)y + size);
                            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                            g.DrawString(String.Format("v{0}", i), f, Brushes.Red, p);
                        }
                    }
                    else {
                        if (neighbours != null && neighbours.Contains(i) == true)
                        {
                            double x = Math.Cos(mainRef.DegToRad(angleStep * i + rotateDeg)) * radius + center.Item1;
                            double y = Math.Sin(mainRef.DegToRad(angleStep * i + rotateDeg)) * radius + center.Item2;
                            Rectangle r = new Rectangle((int)x, (int)y, size, size);
                            g.FillEllipse(Brushes.Black, r);
                            if (drawLabels == true)
                            {
                                Point p = new Point((int)x + size, (int)y + size);
                                Font f = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                                g.DrawString(String.Format("v{0}", i), f, Brushes.Black, p);
                            }
                        }
                    }
                }
        }

        private void neighbourLabels_CheckedChanged(object sender, EventArgs e)
        {
            DrawNeighbours();
        }
    }
}
