using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPGraphs.GraphSearch;
using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch.Tests
{
    [TestClass()]
    public class DFSTests
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
            using (DFS<AdjacencyMatrix> dfs = new DFS<AdjacencyMatrix>())
            {
                SearchResult<AdjacencyMatrix> bfsResult = dfs.Search(m, 0);
                List<int> expectedResult = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });
                CollectionAssert.AreEqual(expectedResult, bfsResult.Numer);
                CollectionAssert.DoesNotContain(bfsResult.Numer, 0);
                Assert.IsTrue(bfsResult.Drzewo.EdgeCount == 6);

                dfs.Clear();

                bfsResult = dfs.Search(m, 1);
                expectedResult = new List<int>(new int[] { 2, 1, 4, 5, 3, 6, 7 });
                CollectionAssert.AreEqual(expectedResult, bfsResult.Numer);
                CollectionAssert.DoesNotContain(bfsResult.Numer, 0);
                Assert.IsTrue(bfsResult.Drzewo.EdgeCount == 6);
            }
        }
    }
}