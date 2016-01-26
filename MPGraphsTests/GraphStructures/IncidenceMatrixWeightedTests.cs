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
    public class IncidenceMatrixWeightedTests
    {
        [TestMethod()]
        public void GetWeightTest()
        {
            IncidenceMatrixWeighted m = new IncidenceMatrixWeighted();
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
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            Assert.IsTrue(m.GetWeight(1, 0) == null);
            m.AddEdge(0, 3, 10);
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
            Assert.IsTrue(m.GetWeight(0, 3) == 10);
            Assert.IsFalse(m.AddEdge(0, 6));
        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            IncidenceMatrixWeighted m = new IncidenceMatrixWeighted();
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
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            Assert.IsTrue(m.GetWeight(1, 0) == null);
            m.AddEdge(0, 3, 10);
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
            Assert.IsTrue(m.GetWeight(0, 3) == 10);
            Assert.IsFalse(m.AddEdge(0, 6));
        }

        [TestMethod()]
        public void RemoveEdgeTest()
        {
            IncidenceMatrixWeighted m = new IncidenceMatrixWeighted();
            for (int i = 0; i < 4; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(2, 2);
            Assert.IsTrue(m.FindEdge(2, 2));
            Assert.IsTrue(m.GetWeight(2, 2) == 0);
            m.RemoveEdge(2, 2);
            Assert.IsFalse(m.FindEdge(2, 2));
            Assert.IsTrue(m.GetWeight(2, 2) == null);
            Assert.IsFalse(m.RemoveEdge(2, 3));
            m.AddEdge(0, 3, 10);
            Assert.IsTrue(m.FindEdge(0, 3));
            Assert.IsTrue(m.GetWeight(0, 3) == 10);
            m.RemoveEdge(0, 3);
            Assert.IsFalse(m.FindEdge(0, 3));
            Assert.IsTrue(m.GetWeight(0, 3) == null);
        }

        [TestMethod()]
        public void MergeVerticesTest()
        {
            IncidenceMatrixWeighted mBase = new IncidenceMatrixWeighted();
            mBase.AddVertex();
            mBase.AddVertex();
            Assert.IsTrue(mBase.VertexCount == 2 && mBase.EdgeCount == 1);

            IncidenceMatrixWeighted m = new IncidenceMatrixWeighted(mBase);
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

            m = new IncidenceMatrixWeighted(mBase);
            m.AddEdge(0, 1);
            List<Incidence> expectedRow = new List<Incidence>(new Incidence[] { Incidence.Start });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 1) == 0);
            m.MergeVertices(0, 1);
            expectedRow = new List<Incidence>();
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 1) == null);

            m = new IncidenceMatrixWeighted(mBase);
            m.AddVertex();
            m.AddEdge(0, 2, 5);
            expectedRow = new List<Incidence>(new Incidence[] { Incidence.Start });
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 2) == 5);
            m.MergeVertices(0, 2);
            expectedRow = new List<Incidence>();
            CollectionAssert.AreEqual(expectedRow, m.GetRow(0));
            Assert.IsTrue(m.GetWeight(0, 2) == null);
        }
    }
}