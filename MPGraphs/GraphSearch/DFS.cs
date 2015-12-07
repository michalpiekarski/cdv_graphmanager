using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public class DFS<T> : IGraphSearch<T>, IDisposable where T : class, IGraphRepresentation, new()
    {
        private List<int> Numbering;
        private int CurrentlyNumbered;
        private T Graph;
        private T Remaining;
        private bool FirstRun;
        public DFS()
        {
            Numbering = new List<int>();
            CurrentlyNumbered = 0;
            Graph = new T();
            Remaining = new T();
            FirstRun = true;
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Performs a search on a <paramref name="graph"/> starting from vertex == <paramref name="root"/>.
        /// </summary>
        /// <param name="graph">Graph to search.</param>
        /// <param name="root">Vertex to start the search from.</param>
        /// <returns>
        /// <c>SearchResult&lt;T&gt;</c> containing all the information about search results.
        /// </returns>
        /// <seealso cref="SearchResult{T}"/>
        public SearchResult<T> Search(T graph, int root)
        {
            int v = root;
            if (FirstRun == true)
            {
                for (int i = 0; i < graph.VertexCount; i++)
                {
                    Numbering.Add(0);
                    Graph.AddVertex();
                    Remaining.AddVertex();
                }
                CurrentlyNumbered = 1;
                Numbering[v] = 1;
                FirstRun = false;
            }
            List<int> N = graph.FindAdjacentVertices(v);
            foreach (int w in N)
            {
                if (Numbering[w] == 0)
                {
                    CurrentlyNumbered++;
                    Numbering[w] = CurrentlyNumbered;
                    Graph.AddEdge(v, w);
                    Search(graph, w);
                }
                else if (Numbering[w] < Numbering[v])
                {
                    Remaining.AddEdge(v, w);
                }
            }
            return new SearchResult<T>(Numbering, Graph, Remaining);
        }
        public void Clear()
        {
            Numbering = new List<int>();
            CurrentlyNumbered = 0;
            Graph = new T();
            Remaining = new T();
            FirstRun = true;
        }
    }
}
