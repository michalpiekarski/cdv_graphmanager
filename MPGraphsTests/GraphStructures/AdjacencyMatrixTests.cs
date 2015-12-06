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
    public class AdjacencyMatrixTests
    {
        [TestMethod()]
        public void AddVertexTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 1 && m.RowCount == m.ColumnCount.Item2);
            m.AddVertex();
            Assert.IsTrue(m.RowCount == 2 && m.RowCount == m.ColumnCount.Item2);
        }

        [TestMethod()]
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
        }

        [TestMethod()]
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

        [TestMethod()]
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
        }

        [TestMethod()]
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

        [TestMethod()]
        public void CompleteGraphTest()
        {
            AdjacencyMatrix m = AdjacencyMatrix.CompleteGraph(5);
            int rowCount = m.RowCount;
            Trace.WriteLine("Complete graph:");
            Trace.Indent();
            for (int i = 0; i < rowCount; i++)
            {
                List<Adjacency> row = m.GetRow(i);
                string rowStr = "";
                foreach(Adjacency adjacency in row)
                {
                    rowStr += adjacency.ToString() + ", ";
                }
                Trace.WriteLine(rowStr);
                for (int j = 0; j < rowCount; j++)
                {
                    if (i == j)
                    {
                        Assert.IsTrue(row[j] == Adjacency.None);
                    } else
                    {
                        Assert.IsTrue(row[j] == Adjacency.Edge);
                    }
                }
            }
            Trace.Unindent();
        }
    }
}