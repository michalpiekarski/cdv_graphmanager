using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures.Tests
{
    [TestClass()]
    public class AdjacencyMatrixWeightedTests : AdjacencyMatrixWeighted
    {
        [TestMethod()]
        public void GetWeightTest()
        {
            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            Assert.IsTrue(m.GetWeight(0, 1) == null);
        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.GetRow(2)[2] == Adjacency.Loop && m.GetColumn(2)[2] == Adjacency.Loop);
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            m.AddEdge(0, 3, 5);
            Assert.IsTrue(m.GetRow(0)[3] == Adjacency.Edge && m.GetRow(3)[0] == Adjacency.Edge);
            Assert.IsTrue(m.GetWeight(0, 3) == 5);
            Assert.IsFalse(m.AddEdge(0, 6));
        }

        [TestMethod()]
        public void RemoveEdgeTest()
        {
            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            m.AddEdge(0, 3);
            m.RemoveEdge(2, 2);
            Assert.IsTrue(m.GetRow(2)[2] == Adjacency.None);
            Assert.IsTrue(m.GetWeight(2, 2) == null);
            Assert.IsFalse(m.RemoveEdge(2, 3));
        }

        [TestMethod()]
        public void MergeVerticesTest()
        {
            AdjacencyMatrixWeighted mBase = new AdjacencyMatrixWeighted();
            mBase.AddVertex();
            mBase.AddVertex();
            Assert.IsTrue(mBase.VertexCount == 2 && mBase.EdgeCount == 0);

            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted(mBase);
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

            m = new AdjacencyMatrixWeighted(mBase);
            m.AddEdge(0, 1);
            List<Adjacency> expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.None, Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 1) == 0);
            m.MergeVertices(0, 1);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 1) == null);

            m = new AdjacencyMatrixWeighted(mBase);
            m.AddVertex();
            m.AddEdge(0, 2, 10);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.None, Adjacency.None, Adjacency.Edge });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 2) == 10);
            m.MergeVertices(0, 2);
            expectedRow = new List<Adjacency>(new Adjacency[] { Adjacency.Edge, Adjacency.None });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 2) == null);
        }
    }
}