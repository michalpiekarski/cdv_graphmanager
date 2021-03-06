﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod()]
        public void FindMSTTest()
        {
            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 6; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(0, 1, 5);
            m.AddEdge(0, 3, 2);
            m.AddEdge(1, 2, 6);
            m.AddEdge(1, 3, 7);
            m.AddEdge(1, 4, 9);
            m.AddEdge(1, 5, 8);
            m.AddEdge(2, 5, 3);
            m.AddEdge(3, 4, 1);
            m.AddEdge(4, 5, 4);
            AdjacencyMatrixWeighted mst = m.FindMST();
            AdjacencyMatrixWeighted testM = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 6; i++)
            {
                testM.AddVertex();
            }
            testM.AddEdge(0, 1, 5);
            testM.AddEdge(0, 3, 2);
            testM.AddEdge(2, 5, 3);
            testM.AddEdge(3, 4, 1);
            testM.AddEdge(4, 5, 4);
            for (int i = 0; i < mst.RowCount; i++)
            {
                CollectionAssert.AreEqual(mst.GetRow(i), testM.GetRow(i));
            }
        }

        [TestMethod()]
        public void FloydTest()
        {
            AdjacencyMatrixWeighted m = new AdjacencyMatrixWeighted();
            for (int i = 0; i < 5; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(0, 1, 2);
            m.AddEdge(0, 4, 1);
            m.AddEdge(1, 2, 1);
            m.AddEdge(1, 3, 4);
            m.AddEdge(1, 4, 8);
            m.AddEdge(2, 3, 2);
            m.AddEdge(3, 4, 10);
            Tuple<List<List<double>>, List<List<double>>> floydResult = m.Floyd();
            List<List<double>> floydResultWTest = new List<List<double>>()
            {
                new List<double>() {0,2,3,5,1},
                new List<double>() {2,0,1,3,3},
                new List<double>() {3,1,0,2,4},
                new List<double>() {5,3,2,0,6},
                new List<double>() {1,3,4,6,0}
            };
            List<List<double>> floydResultPTest = new List<List<double>>()
            {
                new List<double>() {-1,0,1,2,0},
                new List<double>() {1,-1,1,2,0},
                new List<double>() {1,2,-1,2,0},
                new List<double>() {1,2,3,-1,0},
                new List<double>() {4,0,1,2,-1}
            };

            for (int i = 0; i < floydResult.Item1.Count; i++)
            {
                CollectionAssert.AreEqual(floydResult.Item1[i], floydResultWTest[i]);
            }

            for (int i = 0; i < floydResult.Item2.Count; i++)
            {
                CollectionAssert.AreEqual(floydResult.Item2[i], floydResultPTest[i]);
            }
        }
    }
}
