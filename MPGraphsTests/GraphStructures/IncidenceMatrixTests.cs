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
    [TestClass]
    public class IncidenceMatrixTests : IncidenceMatrix
    {
        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Vertex")]
        public void AddVertexTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 1 && m.ColumnCount.Item2 == 1);
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 2 && m.ColumnCount.Item2 == 1);
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Vertex")]
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
            Assert.IsFalse(m.RemoveVertex(10));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Edge")]
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
                if (incidence == Incidence.Loop)
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

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Edge")]
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
            Assert.IsFalse(m.FindEdge(1, 10));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Edge")]
        public void RemoveEdgeTest()
        {
            IncidenceMatrix m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.FindEdge(2, 2));
            m.RemoveEdge(2, 2);
            Assert.IsFalse(m.FindEdge(2, 2));
            Assert.IsFalse(m.RemoveEdge(2, 3));
            m.AddEdge(0, 3);
            Assert.IsTrue(m.FindEdge(0, 3));
            m.RemoveEdge(0, 3);
            Assert.IsFalse(m.FindEdge(0, 3));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix")]
        public void CompleteGraphTest()
        {
            IncidenceMatrix m = IncidenceMatrix.CompleteGraph<IncidenceMatrix>(5);
            int columnCount = m.ColumnCount.Item2;
            int rowCount = m.RowCount;
            Trace.WriteLine("Complete graph:");
            Trace.Indent();
            for (int i = 0; i < columnCount; i++)
            {
                List<Incidence> column = m.GetColumn(i);
                string colStr = "";
                foreach (Incidence incidence in column)
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
        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix")]
        public void FindAdjacentVerticesTest()
        {
            IncidenceMatrix m = IncidenceMatrix.CompleteGraph<IncidenceMatrix>(6);
            List<int> adjacentEdges = m.FindAdjacentVertices(0);
            List<int> expectedResult = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            CollectionAssert.AreEqual(expectedResult, adjacentEdges);
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Merging")]
        public void MergeValueTest()
        {
            Assert.AreEqual<Incidence>(MergeValue(Incidence.None, Incidence.None), Incidence.None);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Start, Incidence.None), Incidence.Start);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.None, Incidence.Start), Incidence.Start);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.End, Incidence.None), Incidence.End);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.None, Incidence.End), Incidence.End);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Loop, Incidence.None), Incidence.Loop);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.None, Incidence.Loop), Incidence.Loop);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Start, Incidence.Start), Incidence.Start);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.End, Incidence.End), Incidence.End);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Loop, Incidence.Loop), Incidence.Loop);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Start, Incidence.End), Incidence.Loop);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.End, Incidence.Start), Incidence.Loop);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Start, Incidence.Loop), Incidence.Start);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.End, Incidence.Loop), Incidence.End);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Loop, Incidence.Start), Incidence.Start);
            Assert.AreEqual<Incidence>(MergeValue(Incidence.Loop, Incidence.End), Incidence.End);
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Merging")]
        public void MergeVerticesTest()
        {
            IncidenceMatrix mBase = new IncidenceMatrix();
            mBase.AddVertex();
            mBase.AddVertex();
            Assert.IsTrue(mBase.VertexCount == 2 && mBase.EdgeCount == 1);

            IncidenceMatrix m = new IncidenceMatrix(mBase);
            foreach (Incidence a in m.GetRow(0))
            {
                Assert.AreEqual<Incidence>(Incidence.None, a);
            }
            foreach (Incidence a in m.GetRow(1))
            {
                Assert.AreEqual<Incidence>(Incidence.None, a);
            }
            m.MergeVertices(0, 1);
            Assert.IsTrue(m.VertexCount == 1 && m.EdgeCount == 1);
            foreach (Incidence a in m.GetRow(0))
            {
                Assert.AreEqual<Incidence>(a, Incidence.None);
            }

            m = new IncidenceMatrix(mBase);
            m.AddEdge(0, 1);
            List<Incidence> expectedRow = new List<Incidence>(new Incidence[] { Incidence.Start });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            m.MergeVertices(0, 1);
            expectedRow = new List<Incidence>();
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));

            m = new IncidenceMatrix(mBase);
            m.AddVertex();
            m.AddEdge(0, 2);
            expectedRow = new List<Incidence>(new Incidence[] { Incidence.Start });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            m.MergeVertices(0, 2);
            expectedRow = new List<Incidence>();
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("IncidenceMatrix"), TestCategory("Merging")]
        public void MergeComponentTest()
        {
            IncidenceMatrix m = IncidenceMatrix.CompleteGraph<IncidenceMatrix>(4);
            Assert.IsTrue(m.MergeComponent(0));
            m = new IncidenceMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(0, 1);
            m.AddEdge(1, 3);
            Assert.IsFalse(m.MergeComponent(0));
            Assert.IsFalse(m.MergeComponent(2));
            m.AddEdge(2, 3);
            Assert.IsTrue(m.MergeComponent(0)); /// FIXME - Fails, probably caused by a bug in vertex merging
        }
    }
}