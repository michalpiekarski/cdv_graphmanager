using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPGraphs.GraphSearch;
using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch.Tests
{
    [TestClass()]
    public class BFSTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            AdjacencyMatrix m = new AdjacencyMatrix();
            for (int i = 0; i < 7; i++)
            {
                m.AddVertex();
            }
            m.AddEdge(0, 1);
            m.AddEdge(0, 4);
            m.AddEdge(1, 2);
            m.AddEdge(1, 4);
            m.AddEdge(1, 5);
            m.AddEdge(5, 6);
            m.AddEdge(2, 3);
            Assert.IsTrue(m.EdgeCount == 7);
            using (BFS<AdjacencyMatrix> bfs = new BFS<AdjacencyMatrix>())
            {
                SearchResult<AdjacencyMatrix> bfsResult = bfs.Search(m, 0);
                List<int> expectedResult = new List<int>(new int[] { 1, 2, 4, 6, 3, 5, 7 });
                CollectionAssert.AreEqual(expectedResult, bfsResult.Numer);
                CollectionAssert.DoesNotContain(bfsResult.Numer, 0);
                Assert.IsTrue(bfsResult.Drzewo.EdgeCount == 6);

                bfs.Clear();

                bfsResult = bfs.Search(m, 1);
                expectedResult = new List<int>(new int[] { 2, 1, 3, 6, 4, 5, 7 });
                CollectionAssert.AreEqual(expectedResult, bfsResult.Numer);
                CollectionAssert.DoesNotContain(bfsResult.Numer, 0);
                Assert.IsTrue(bfsResult.Drzewo.EdgeCount == 6);
            }
        }
    }
}