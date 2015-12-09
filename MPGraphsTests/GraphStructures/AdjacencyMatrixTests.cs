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
    public class AdjacencyMatrixTests : AdjacencyMatrix
    {
        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Vertex")]
        public void AddVertexTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 1 && m.RowCount == m.ColumnCount.Item2);
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 2 && m.RowCount == m.ColumnCount.Item2);
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Vertex")]
        public void RemoveVertexTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            Assert.IsTrue(m.RowCount == 4 && m.ColumnCount.Item2 == m.RowCount);
            m.RemoveVertex(2);
            Assert.IsTrue(m.RowCount == 3 && m.ColumnCount.Item2 == m.RowCount);
            Assert.IsFalse(m.RemoveVertex(10));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Edge")]
        public void AddEdgeTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.GetRow(2)[2] == Adjacency.Loop && m.GetColumn(2)[2] == Adjacency.Loop);
            m.AddEdge(0, 3);
            Assert.IsTrue(m.GetRow(0)[3] == Adjacency.Edge && m.GetRow(3)[0] == Adjacency.Edge);
            Assert.IsFalse(m.AddEdge(0, 6));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Edge")]
        public void FindEdgeTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
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

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Edge")]
        public void RemoveEdgeTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            m.AddEdge(0, 3);
            m.RemoveEdge(2, 2);
            Assert.IsTrue(m.GetRow(2)[2] == Adjacency.None);
            Assert.IsFalse(m.RemoveEdge(2, 3));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix")]
        public void CompleteGraphTest()
        {
            AdjacencyMatrix m = AdjacencyMatrix.CompleteGraph<AdjacencyMatrix>(5);
            int rowCount = m.RowCount;
            Trace.WriteLine("Complete graph:");
            Trace.Indent();
            for (int i = 0; i < rowCount; i++)
            {
                List<Adjacency> row = m.GetRow(i);
                string rowStr = "";
                foreach (Adjacency adjacency in row)
                {
                    rowStr += adjacency.ToString() + ", ";
                }
                Trace.WriteLine(rowStr);
                for (int j = 0; j < rowCount; j++)
                {
                    if (i == j)
                    {
                        Assert.IsTrue(row[j] == Adjacency.None);
                    }
                    else
                    {
                        Assert.IsTrue(row[j] == Adjacency.Edge);
                    }
                }
            }
            Trace.Unindent();
        }
        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix")]
        public void FindAdjacentEdgesTest()
        {
            AdjacencyMatrix m = AdjacencyMatrix.CompleteGraph<AdjacencyMatrix>(6);
            List<int> adjacentEdges = m.FindAdjacentVertices(0);
            List<int> expectedResult = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            CollectionAssert.AreEqual(expectedResult, adjacentEdges);
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Merging")]
        public void MergeValueTest()
        {
            Assert.AreEqual<Adjacency>(Adjacency.None, MergeValue(Adjacency.None, Adjacency.None));
            Assert.AreEqual<Adjacency>(Adjacency.Edge, MergeValue(Adjacency.Edge, Adjacency.None));
            Assert.AreEqual<Adjacency>(Adjacency.Edge, MergeValue(Adjacency.None, Adjacency.Edge));
            Assert.AreEqual<Adjacency>(Adjacency.Edge, MergeValue(Adjacency.Edge, Adjacency.Edge));
            Assert.AreEqual<Adjacency>(Adjacency.Loop, MergeValue(Adjacency.Loop, Adjacency.None));
            Assert.AreEqual<Adjacency>(Adjacency.Loop, MergeValue(Adjacency.None, Adjacency.Loop));
            Assert.AreEqual<Adjacency>(Adjacency.Edge, MergeValue(Adjacency.Edge, Adjacency.Loop));
            Assert.AreEqual<Adjacency>(Adjacency.Edge, MergeValue(Adjacency.Loop, Adjacency.Edge));
            Assert.AreEqual<Adjacency>(Adjacency.Loop, MergeValue(Adjacency.Loop, Adjacency.Loop));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Merging")]
        public void MergeVerticesTest()
        {
            AdjacencyMatrix mBase = new AdjacencyMatrix();
            mBase.AddVertex();
            mBase.AddVertex();
            Assert.IsTrue(mBase.VertexCount == 2 && mBase.EdgeCount == 0);

            AdjacencyMatrix m = new AdjacencyMatrix(mBase);
            foreach (Adjacency a in m.GetRow(0))
            {
                Assert.AreEqual<Adjacency>(Adjacency.None, a);
            }
            foreach (Adjacency a in m.GetRow(1))
            {
                Assert.AreEqual<Adjacency>(Adjacency.None, a);
            }
            m.MergeVertices(0, 1);
            Assert.IsTrue(m.VertexCount == 1 && m.EdgeCount == 0);
            foreach (Adjacency a in m.GetRow(0))
            {
                Assert.AreEqual<Adjacency>(a, Adjacency.None);
            }

            m = new AdjacencyMatrix(mBase);
            m.AddEdge(0, 1);
            List<Adjacency> expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.None, Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            m.MergeVertices(0, 1);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));

            m = new AdjacencyMatrix(mBase);
            m.AddVertex();
            m.AddEdge(0, 2);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.None, Adjacency.None, Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            m.MergeVertices(0, 2);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.Edge, Adjacency.None });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
        }

        [TestMethod, TestCategory("GraphRepresentation"), TestCategory("AdjacencyMatrix"), TestCategory("Merging")]
        public void MergeComponentTest()
        {
            AdjacencyMatrix m = AdjacencyMatrix.CompleteGraph<AdjacencyMatrix>(4);
            Assert.IsTrue(m.MergeComponent(0));
            m = new AdjacencyMatrix();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(0, 1);
            m.AddEdge(1, 3);
            Assert.IsFalse(m.MergeComponent(0));
            Assert.IsFalse(m.MergeComponent(2));
            m.AddEdge(2, 3);
            Assert.IsTrue(m.MergeComponent(0));
        }
    }
}