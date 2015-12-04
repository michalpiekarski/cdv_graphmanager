using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures.Tests
{
    [TestClass()]
    public class IncidenceMatrixTests
    {
        [TestMethod()]
        public void AddVertexTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 1 && m.ColumnCount.Item2 == 1);
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 2 && m.ColumnCount.Item2 == 1);
        }

        [TestMethod()]
        public void RemoveVertexTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            Assert.IsTrue(m.RowCount == 4 && m.ColumnCount.Item2 == 1);
            m.RemoveVertex(2);
            Assert.IsTrue(m.RowCount == 3 && m.ColumnCount.Item2 == 1);
        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            List<Incidence> vertex = m.GetRow(2);
            bool foundLoop = false;
            foreach (Incidence incidence in vertex)
            {
                if(incidence == Incidence.Loop)
                {
                    foundLoop = true;
                    break;
                }
            }
            Assert.IsTrue(foundLoop);
            m.AddEdge(0, 3);
            int columnCount = m.ColumnCount.Item2;
            List<Incidence> edge;
            bool foundEdge = false;
            for (int i = 0; i < columnCount; i++)
            {
                edge = m.GetColumn(i);
                if (edge[0] == Incidence.Start && edge[3] == Incidence.Start)
                {
                    foundEdge = true;
                    break;
                }
            }
            Assert.IsTrue(foundEdge);
            Assert.IsFalse(m.AddEdge(0, 6));
        }

        [TestMethod()]
        public void FindEdgeTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.FindEdge(2, 2));
            m.AddEdge(0, 3);
            Assert.IsTrue(m.FindEdge(3, 0));
            Assert.IsFalse(m.FindEdge(2, 1));
        }

        [TestMethod()]
        public void RemoveEdgeTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.GetRow(2)[0] == Incidence.Loop && m.ColumnCount.Item2 == 1);
            m.RemoveEdge(2, 2);
            Assert.IsTrue(m.ColumnCount.Item2 == 0);
            Assert.IsFalse(m.RemoveEdge(2, 3));
        }

        [TestMethod()]
        public void CompleteGraphTest()
        {
            IncidenceMatrix m = IncidenceMatrix.CompleteGraph(5);
            int columnCount = m.ColumnCount.Item2;
            int rowCount = m.RowCount;
            Trace.WriteLine("Complete graph:");
            Trace.Indent();
            for (int i = 0; i < columnCount; i++)
            {
                List<Incidence> column = m.GetColumn(i);
                string colStr = "";
                foreach(Incidence incidence in column)
                {
                    colStr += incidence.ToString() + ", ";
                }
                Trace.WriteLine(colStr);
                for (int j = 0; j < rowCount; j++)
                {
                    Assert.IsTrue(column[j] != Incidence.Loop);
                }
            }
            Trace.Unindent();
        }
    }
}